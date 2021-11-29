using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var nombre = NombresEntry.Text;
            var apellidos = ApellidosEntry.Text;
            var identificacion = IdentificacionEntry.Text.ToString();
            var email = EmailEntry.Text;
            var telefono = TelefonoEntry.Text;
            var edad = EdadEntry.Text;
            var fechanacimiento = FechaNacimientoEntry.Date.ToString("yyyy-mm-dd");
            var sexo = SexoEntry.Text;
            var password = PasswordEntry.Text;

            try
            {

                Models.RegistroPersona.RegistroPersonaRequest item = new Models.RegistroPersona.RegistroPersonaRequest()
                {
                    rolePID = "3",
                    Nombres = nombre,
                    Apellidos = apellidos,
                    Identificacion = identificacion,
                    Email = email,
                    Telefono = telefono,
                    Edad = edad,
                    Sexo = sexo,
                    FechaNacimiento = fechanacimiento,
                    Password = password

                };

                bool response = Functions.Services.RegistroUsuario(item);

                if (response)
                {
                    await DisplayAlert("Alerta", "Registro exitoso", "Ok");
                }
                else
                {
                    await DisplayAlert("Alerta", "Registro fallido", "Ok");
                }


                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            catch { }
        }
    }
}