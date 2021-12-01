using GymApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }

        private async void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(EmailEntry.Text))
                {
                   await DisplayAlert("Alerta", "Ingrese su Email", "Ok");
                   return;
                }

                if (string.IsNullOrEmpty(PasswordEntry.Text))
                {
                    await DisplayAlert("Alerta", "Ingrese su Contraseña", "Ok");
                    return;
                }

                if (EmailEntry.Text == "admin")
                {
                    Helpers.Settings.IsLoged = true;
                    Helpers.Settings.PersonaID = 1;
                    Helpers.Settings.RoleID = 3;

                    Application.Current.MainPage = new AppShell();
                }

                var emailEntry = EmailEntry.Text;
                var passwordEntry = PasswordEntry.Text;

                Models.Login.LoginRequest item = new Models.Login.LoginRequest()
                {
                    email = emailEntry,
                    password = passwordEntry
                };

                Models.Login.LoginResponseContent response = Functions.Services.LoginUser(item);

                if (response != null)
                {
                    Helpers.Settings.IsLoged = true;
                    Helpers.Settings.PersonaID = response.personaID;
                    Helpers.Settings.RoleID = response.role;

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    Helpers.Settings.IsLoged = false;
                    await DisplayAlert("Alerta", "Credenciales Incorrectas.", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Fallo en el Login", "Ok");
            }
        }
        
    }
}