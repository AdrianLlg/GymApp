using GymApp.Models.RegistroAsistenciaQR;
using GymApp.Models.SesionesAgendadas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionsScheduled : ContentPage
    {
        public ObservableCollection<SesionesAgendadasContent> collection;
        public SessionsScheduled()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                CultureInfo culture = new CultureInfo("es-EC");
                CultureInfo.CurrentCulture = culture;

                SesionesAgendadasRequest request = new SesionesAgendadasRequest()
                {
                    personaID = Helpers.Settings.PersonaID
                };

                collection = Functions.Services.ConsultarSesionesAgendadas(request);

                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        item.horaFormatoString = item.horaInicio.Insert(2, ":") + "-" + item.horaFin.Insert(2, ":");
                        item.cupos = item.Asistentes.ToString() + "/" + item.AforoMaximoClase;
                        item.fechaSesion = DateTime.ParseExact(item.fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        item.formatoFechaSesion = item.fechaSesion.ToLongDateString();

                        if (string.IsNullOrEmpty(item.recursoEspecial))
                        {
                            item.recursoAsignado = false;
                        }
                        else
                        {
                            var recurso = item.recursoEspecial.Split('-');
                            item.nombreRecurso = recurso[0];
                            item.descripcionRecurso = recurso[1];
                            item.recursoAsignado = true;
                        }
                    }

                    collectionView.ItemsSource = collection;
                }
                else
                {
                    collectionView.IsVisible = false;
                    noSessions.IsVisible = true;
                    noSessions.Text = "Actualmente no tiene sesiones agendadas.";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error.", "Ok");
                return;
            }


        }

        private async void btnQRScanner_Clicked(object sender, EventArgs e)
        {

            try
            {
                var obj = (ImageButton)sender;
                var session = (SesionesAgendadasContent)obj.BindingContext;

                var validaHorario = Functions.Services.ValidaHoraRegistroAsistencia(session.EventoID);

                if (validaHorario)
                {
                    var scanner = new ZXing.Mobile.MobileBarcodeScanner();

                    scanner.TopText = "Escanea el código QR para registrar tu asistencia";

                    var result = await scanner.Scan();

                    if (result != null)
                    {
                        RegistroAsistenciaQRRequest request = new RegistroAsistenciaQRRequest()
                        {
                            eventoID = int.Parse(result.Text),
                            personaID = Helpers.Settings.PersonaID
                        };

                        var response = Functions.Services.RegistroAsistenciaDeportista(request);

                        if (!string.IsNullOrWhiteSpace(response))
                        {
                            if (response.Equals("NoInscritoEnElEvento"))
                            {
                                await DisplayAlert("Alerta", "No se encuentra registrado para esta sesión, por favor, comuníquese con el administrador del establecimiento para más información.", "Ok");
                                return;
                            }
                            else if (response.Equals("RegistroExitoso"))
                            {
                                await DisplayAlert("Alerta", "Se ha registrado correctamente su asistencia a esta sesión.", "Ok");
                                return;
                            }
                            else if (response.Equals("HorarioNoValido"))
                            {
                                await DisplayAlert("Alerta", "Se encuentra dentro de un horario no válido para registrar su asistencia. El registro de asistencia por QR está disponible únicamente cuando inicia la clase.", "Ok");
                                return;
                            }
                            else
                            {
                                await DisplayAlert("Alerta", "Ha ocurrido un error al registrar la asistencia. Intentelo nuevamente más tarde.", "Ok");
                                return;
                            }
                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Ha ocurrido un error al registrar la asistencia. Intentelo nuevamente más tarde.", "Ok");
                            return;
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Se encuentra dentro de un horario no válido para registrar su asistencia. El registro de asistencia por QR está disponible únicamente cuando inicia la clase.", "Ok");
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al abrir la opción. Intentelo nuevamente más tarde.", "Ok");
                return;
            }
        }
    }
}