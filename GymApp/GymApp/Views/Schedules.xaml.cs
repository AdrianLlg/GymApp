using GymApp.Models.Horarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugin.Calendar.Models;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Schedules : ContentPage
    {
        public ICommand DayTappedCommand => new Command<DateTime>(async (date) => await DayClick(date, calendar));

        public DateTime fechaInicio;
        public DateTime fechaFin;

        public Schedules()
        {
            InitializeComponent();
            CalendarSettings();

            NavigationPage.SetHasNavigationBar(this, false);
        }


        private async Task DayClick(DateTime date, Xamarin.Plugin.Calendar.Controls.Calendar calendarControl)
        {
            try
            {
                if (date < DateTime.Now)
                {
                    if (!(date.Date == DateTime.Now.Date))
                    {
                        return;
                    }
                }

                if (DateTime.Now >= fechaInicio && DateTime.Now <= fechaFin)
                {
                    if (date.Date < fechaInicio.Date  || date.Date > fechaFin.Date)
                    {
                        await DisplayAlert("Alerta", "No se permite agendar sesiones fuera del rango de la duración de su(s) membresía(s). Lo sentimos!", "Ok");
                        return;
                    }

                    ObservableCollection<HorariosDeportistaContent> result;

                    EventCollection events = new EventCollection();

                    HorariosDeportistaRequest request = new HorariosDeportistaRequest()
                    {

                        personaID = Helpers.Settings.PersonaID,
                        fecha = date.ToString("yyyy-MM-dd")
                    };

                    result = Functions.Services.ConsultaHorarios(request);

                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            item.cupos = item.asistenciaEvento.ToString() + "/" + item.aforoMax.ToString();
                            item.horaFormatoString = item.horaInicioEvento.Insert(2, ":") + " - " + item.horaFinEvento.Insert(2, ":");
                        }

                        events.Add(date, result);

                        calendarControl.Events = events;
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "No se encontraron horarios para el día seleccionado. ", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "No se permite agendar sesiones fuera del rango de la duración de su(s) membresía(s). Lo sentimos!", "Ok");
                }

                    
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al consultar los horarios del día seleccionado.", "Ok");
            }
        }

        private void CalendarSettings()
        {

            fechaInicio = DateTime.ParseExact(Helpers.Settings.FechaInicioMembresia, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            fechaFin = DateTime.ParseExact(Helpers.Settings.FechaFinMembresia, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            CultureInfo cultureEC = new CultureInfo("es-EC", false);
            calendar.Culture = cultureEC;

            calendar.SelectedDate = DateTime.Today;
            calendar.ShowYearPicker = false;

            calendar.DayTappedCommand = DayTappedCommand;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            { 
                var obj = (ImageButton)sender;

                var content = (HorariosDeportistaContent)obj.BindingContext;

                await Navigation.PushAsync(new ScheduleDetails(content));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar el contenido.", "Ok");
                return;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            calendar.Events = new EventCollection();
        }
    }
}