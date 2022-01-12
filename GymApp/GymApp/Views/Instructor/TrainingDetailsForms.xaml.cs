using GymApp.Models.Instructor.RegistroFichaEntrenamiento;
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
    public partial class TrainingDetailsForms : ContentPage
    {
        public int personaID = 0;
        public int disciplinaID = 0;
        public int fichaPersonaID = 0;

        public TrainingDetailsForms(int personID, int disciplineID, int fichaPersonID)
        {
            InitializeComponent();

            personaID = personID;
            disciplinaID = disciplineID;
            fichaPersonaID = fichaPersonID;
        }

        private async void registrarFichabtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pesoEntry.Text) || string.IsNullOrWhiteSpace(estaturaEntry.Text)
                    || string.IsNullOrWhiteSpace(masaMuscularEntry.Text) || string.IsNullOrWhiteSpace(grasaCorpEntry.Text)
                    || string.IsNullOrWhiteSpace(brazosEntry.Text) || string.IsNullOrWhiteSpace(pechoEntry.Text)
                    || string.IsNullOrWhiteSpace(espaldaEntry.Text) || string.IsNullOrWhiteSpace(piernasEntry.Text)
                    || string.IsNullOrWhiteSpace(cinturaEntry.Text) || string.IsNullOrWhiteSpace(cuelloEntry.Text)
                    || string.IsNullOrWhiteSpace(observacionesEntry.Text))
                {
                    await DisplayAlert("Alerta", "Por favor, ingrese todos los campos. Son obligatorios.", "Ok");
                    return;
                }

                RegistroFichaEntrenamientoRequest request = new RegistroFichaEntrenamientoRequest()
                {
                    flujoID = 1,
                    FechaCreacion = DateTime.Today.ToString("yyyy-MM-dd"),
                    fichaPersonaID = fichaPersonaID,
                    ProfesorID = Helpers.Settings.PersonaID,
                    DiciplinaID = disciplinaID,
                    Peso = decimal.Parse(pesoEntry.Text),
                    Altura = decimal.Parse(estaturaEntry.Text),
                    IndiceMasaMuscular = decimal.Parse(masaMuscularEntry.Text),
                    IndiceGrasaCorporal = decimal.Parse(grasaCorpEntry.Text),
                    MedicionBrazos = decimal.Parse(brazosEntry.Text),
                    MedicionPecho = decimal.Parse(pechoEntry.Text),
                    MedicionEspalda = decimal.Parse(espaldaEntry.Text),
                    MedicionPiernas = decimal.Parse(piernasEntry.Text),
                    MedicionCintura = decimal.Parse(cinturaEntry.Text),
                    MedicionCuello = decimal.Parse(cuelloEntry.Text),
                    Observaciones = observacionesEntry.Text
                };

                var response = Functions.Services.RegistroFichaEntrenamientoInstructor(request);
                //var response = true;

                if (response)
                {
                    await DisplayAlert("Alerta", "Se ha registrado exitosamente la ficha de entrenamiento.", "Ok");

                    var stack = Navigation.NavigationStack;

                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
                    Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Alerta", "Ocurrio un error al enviar la información, por favor inténtelo nuevamente más tarde.", "Ok");
                    await Navigation.PopAsync();
                }

            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrio un error al enviar la información, por favor inténtelo nuevamente más tarde.", "Ok");
                return;
            }
        }
    }
}