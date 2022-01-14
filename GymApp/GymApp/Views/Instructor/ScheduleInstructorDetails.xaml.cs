using GymApp.Models.ConfiguracionesSistema;
using GymApp.Models.Instructor.CancelarSesion;
using GymApp.Models.Instructor.SesionesProximasInstructor;
using GymApp.Models.Instructor.SesionListaAsistentes;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views.Instructor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleInstructorDetails : ContentPage
    {
        public SesionesProximasInstructorContent item;
        public bool canClosePage = false;
        public List<SesionListaAsistentesContent> listAttendants = new List<SesionListaAsistentesContent>();

        public ScheduleInstructorDetails(SesionesProximasInstructorContent obj)
        {
            InitializeComponent();
            item = obj;

            LoadData();

            MessagingCenter.Subscribe<App, bool>(App.Current, "OpenPage", (snd, arg) =>
            {
                canClosePage = arg;

                if (canClosePage)
                {
                    Navigation.PopToRootAsync();
                }
            });
        }

        public async void LoadData()
        {
            try
            {
                if (item.estadoRegistro.Equals("A"))
                {
                    getAttendants(item.eventoID);

                    if (listAttendants.Count > 0)
                    {
                        asistentesLabel.Text = listAttendants.Count.ToString() + "/" + item.aforoMax.ToString();
                    }
                    else
                    {
                        asistentesLabel.Text = "0/" + item.aforoMax.ToString();
                    }

                }
                else
                {
                    QRbtn.IsVisible = false;
                    cancelarBtn.IsEnabled = false;
                    asistentesbtn.IsVisible = false;
                }

                fechaLabel.Text = item.fechaFormato;
                horarioLabel.Text = item.horario;
                claseLabel.Text = item.nombreClase;
                salaLabel.Text = item.nombreSala;
                aforoMaxLabel.Text = item.aforoMax.ToString();
                aforoMinLabel.Text = item.aforoMin.ToString();


            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrió un error al intentar cargar la información, por favor, vuelvalo a intentar más tarde.", "Ok");
            }
        }

        public async void getAttendants(int eventoID)
        {
            try
            {
                listAttendants = Functions.Services.ObtenerAsistentesEvento(eventoID);
            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrió un error al consultar los inscritos.", "Ok");
            }
        }


        private async void Cancelar_SesionClicked(object sender, EventArgs e)
        {
            try
            {
                bool resp = false;
                DateTime hoy = DateTime.Now;
                string query = string.Empty;

                ConfiguracionesSistemaRequest req = new ConfiguracionesSistemaRequest()
                {
                    flujoID = 3,
                    nombreConfiguracion = "cancelacionEventoInstructor"
                };

                var config = Functions.Services.ConsultaConfiguracionSistema(req);

                if (config != null)
                {
                    var configuration = config.First();
                    int value = int.Parse(configuration.Valor);

                    var validation = item.fechaInicioFormatoDateTime.AddHours(-value);

                    if (hoy < validation)
                    {
                        bool alertResponse = await DisplayAlert("Alerta", "Está seguro de cancelar la sesión? Recuerde que solo podrá realizar esta acción una vez. Si cancela la sesión se notificará a los asistentes y administrador del establecimiento.", "Ok", "Cancelar");

                        if (alertResponse)
                        {
                            await PopupNavigation.Instance.PushAsync(new PopUpSessionCancelDetails(item));
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Lo sentimos, no se encuentra dentro del horario permitido para cancelar la sesión. Por favor, comuníquese con el administrador del establecimiento para más información.", "Ok");
                        return;
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Ocurrió un error al intentar abrir la opción.", "Ok");
                    return;
                }

            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrió un error al intentar abrir la opción.", "Ok");
                return;
            }
            
        }

        private async void ListaAsistentes_Clicked(object sender, EventArgs e)
        {
            try
            {
                var validaHorario = Functions.Services.ValidaHoraRegistroAsistencia(item.eventoID);
                
                await Navigation.PushAsync(new ScheduleStudentsList(item, listAttendants, validaHorario));

            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrió un error al intentar abrir la opción.", "Ok");
            }
        }

        private async void QRbtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var validaHorario = Functions.Services.ValidaHoraRegistroAsistencia(item.eventoID);

                if (validaHorario)
                {
                    await PopupNavigation.Instance.PushAsync(new PopUpQR(item));
                }
                else
                {
                    await DisplayAlert("Alerta", "No se encuentra dentro del horario para acceder a esta opción. Intentelo nuevamente cuando esté dentro del horario de la sesión.", "Ok");
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrió un error al intentar abrir la opción.", "Ok");
            }
        }
    }
}