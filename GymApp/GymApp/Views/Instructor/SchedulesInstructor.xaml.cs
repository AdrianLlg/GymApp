using GymApp.Models.Instructor.SesionesProximasInstructor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views.Instructor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulesInstructor : ContentPage
    {
        public SchedulesInstructor()
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

                var response = Functions.Services.ObtenerSesionesProximasInstructor(Helpers.Settings.PersonaID);

                if (response != null)
                {
                    foreach (var item in response)
                    {

                        item.fechaInicioFormatoDateTime = DateTime.ParseExact(item.fecha + " " + item.horaInicio, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);
                        item.fechaFinFormatoDateTime = DateTime.ParseExact(item.fecha + " " + item.horaFin, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);

                        item.fechaFormato = item.fechaInicioFormatoDateTime.ToLongDateString();
                    }

                    response = response.OrderBy(x => x.fecha).ToList();

                    collectionViewSchedules.ItemsSource = new ObservableCollection<SesionesProximasInstructorContent>(response);

                }
                else
                {
                    collectionViewSchedules.IsVisible = false;
                    noSessions.IsVisible = true;
                    noSessions.Text = "Actualmente no tiene sesiones agendadas.";
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar las agendas. Intentelo nuevamente más tarde.", "Ok");
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (ImageButton)sender;

                var session = (SesionesProximasInstructorContent)obj.BindingContext;

                await Navigation.PushAsync(new ScheduleInstructorDetails(session));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error.", "Ok");
                return;
            }

        }
    }
}