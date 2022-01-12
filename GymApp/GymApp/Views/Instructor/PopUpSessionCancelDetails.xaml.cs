using GymApp.Models.Instructor.CancelarSesion;
using GymApp.Models.Instructor.SesionesProximasInstructor;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views.Instructor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpSessionCancelDetails : Rg.Plugins.Popup.Pages.PopupPage
    {
        public SesionesProximasInstructorContent content; 

        public PopUpSessionCancelDetails(SesionesProximasInstructorContent value)
        {
            InitializeComponent();
            this.CloseWhenBackgroundIsClicked = true;
            content = value;
        }

        private async void Enviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(motivoEntry.Text))
                {
                    await DisplayAlert("Alerta", "Por favor, rellene todos los campos. Son obligatorios.", "Ok");
                    return;
                }

                if (string.IsNullOrEmpty(posibleFechaEntry.Text))
                {
                    await DisplayAlert("Alerta", "Por favor, rellene todos los campos. Son obligatorios.", "Ok");
                    return;
                }

                CancelarSesionRequest request = new CancelarSesionRequest()
                {
                    eventoID = content.eventoID,
                    personaID = Helpers.Settings.PersonaID,
                    motivo = motivoEntry.Text,
                    posibleHorarioRecuperacion = posibleFechaEntry.Text
                };

                var response = Functions.Services.CancelarSesionInstructor(request);

                if (response)
                {
                    await DisplayAlert("Alerta", "La sesión se ha cancelado con éxito.", "Ok");

                    MessagingCenter.Send<App, bool>(App.Current as App, "OpenPage", true);

                    await PopupNavigation.Instance.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alerta", "Ha ocurrido un error al cancelar esta sesión. Intentelo nuevamente más tarde.", "Ok");

                    MessagingCenter.Send<App, bool>(App.Current as App, "OpenPage", false);

                    await PopupNavigation.Instance.PopAsync();
                }

            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cancelar esta sesión.", "Ok");
                await PopupNavigation.Instance.PopAsync();
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // ### Methods for supporting animations in your popup page ###

        // Invoked before an animation appearing
        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        // Invoked after an animation appearing
        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        // Invoked before an animation disappearing
        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            return base.OnDisappearingAnimationEndAsync();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return base.OnBackgroundClicked();
        }
    }
}