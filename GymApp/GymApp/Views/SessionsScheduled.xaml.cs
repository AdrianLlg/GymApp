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
    }
}