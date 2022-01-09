using GymApp.Models.Instructor.SesionesProximasInstructor;
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
    public partial class SchedulesInstructor : ContentPage
    {
        public SchedulesInstructor()
        {
            InitializeComponent();
        }

        public async void LoadData()
        {
            try
            {
                var response = Functions.Services.ObtenerSesionesProximasInstructor(Helpers.Settings.PersonaID);





            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar las disciplinas del establecimiento.", "Ok");
            }
        }
    }
}