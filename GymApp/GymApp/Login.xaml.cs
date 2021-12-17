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
            NavigationPage.SetHasNavigationBar(this, false);
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

                var email = EmailEntry.Text;
                var password = PasswordEntry.Text;

                var resp = (Application.Current as App).LogIn(email, password);


                if (resp == false)
                {
                    await DisplayAlert("Alerta", "Credenciales incorrectas, por favor, verifique su correo o contraseña.", "Ok");
                    await (Application.Current as App).LogOut();
                }


            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", "Ocurrió un error al realizar Log In, intentelo nuevamente mas tarde", "Ok");
                await (Application.Current as App).LogOut();
            }
        }
        
    }
}