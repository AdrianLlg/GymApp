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
            var picker = string.Empty;
            string[] mail;

            try
            {
                picker = pickerGenere.SelectedItem.ToString();

                if (picker == "Hombre")
                {
                    picker = "H";
                }
                if (picker == "Mujer")
                {
                    picker = "M";
                }
                if (picker == "Otros")
                {
                    picker = "O";
                }
            }
            catch
            {
                picker = string.Empty;
            }
            

            if (string.IsNullOrEmpty(NombresEntry.Text) || string.IsNullOrEmpty(ApellidosEntry.Text)
                || string.IsNullOrEmpty(IdentificacionEntry.Text) || string.IsNullOrEmpty(EmailEntry.Text)
                || string.IsNullOrEmpty(TelefonoEntry.Text) || string.IsNullOrEmpty(picker))
            {
                await DisplayAlert("Alerta", "Por favor, ingrese todos los campos requeridos.", "Ok");
                return;
            }

            if(IdentificacionEntry.Text.Length < 10 || IdentificacionEntry.Text.Length > 10)
            {
                await DisplayAlert("Alerta", "Por favor, ingrese una cédula de identidad válida", "Ok");
                return;
            }

            if (TelefonoEntry.Text.Length < 10 || TelefonoEntry.Text.Length > 10)
            {
                await DisplayAlert("Alerta", "Por favor, ingrese un teléfono válido", "Ok");
                return;
            }

            if (FechaNacimientoEntry.Date > DateTime.Now || FechaNacimientoEntry.Date > DateTime.Now.AddYears(-15))
            {
                await DisplayAlert("Alerta", "Por favor, ingrese una fecha de nacimiento válida", "Ok");
                return;
            }

            try
            {
                mail = EmailEntry.Text.Split('@');

                if (!mail[1].Contains(".com"))
                {
                    await DisplayAlert("Alerta", "Por favor, ingrese un correo electrónico válido", "Ok");
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Por favor, ingrese un correo electrónico válido", "Ok");
                return;
            }

            try
            {
                var nombre = NombresEntry.Text;
                var apellidos = ApellidosEntry.Text;
                var identificacion = IdentificacionEntry.Text.ToString();
                var email = EmailEntry.Text;
                var telefono = TelefonoEntry.Text;
                var fechanacimiento = FechaNacimientoEntry.Date.ToString("yyyy-MM-dd");

                Models.RegistroPersona.RegistroPersonaRequest item = new Models.RegistroPersona.RegistroPersonaRequest()
                {
                    flujoID = 1,
                    rolePID = "3",
                    nombres = nombre,
                    apellidos = apellidos,
                    identificacion = identificacion,
                    email = email,
                    telefono = telefono,
                    sexo = picker,
                    fechaNacimiento = fechanacimiento
                };

                bool response = Functions.Services.RegistroUsuario(item);

                if (response)
                {
                    await DisplayAlert("Alerta", "Registro exitoso", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alerta", "Registro fallido", "Ok");
                }

            }
            catch {
                await DisplayAlert("Alerta", "Registro fallido", "Ok");
            }
        }

        private async void AlreadyAccountClick(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}