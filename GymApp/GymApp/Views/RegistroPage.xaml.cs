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
            
            if (VerificaIdentificacion(IdentificacionEntry.Text) == false)
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

        internal static bool VerificaIdentificacion(string identificacion)
        {
            bool estado = false;
            char[] valced = new char[13];
            int provincia;
            if (identificacion.Length >= 10)
            {
                valced = identificacion.Trim().ToCharArray();
                provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
                if (provincia > 0 && provincia < 25)
                {
                    if (int.Parse(valced[2].ToString()) < 6)
                    {
                        estado = VerificaCedula(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 6)
                    {
                        estado = VerificaSectorPublico(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 9)
                    {

                        estado = VerificaPersonaJuridica(valced);
                    }
                }
            }
            return estado;
        }

        public static bool VerificaCedula(char[] validarCedula)
        {
            int aux = 0, par = 0, impar = 0, verifi;
            for (int i = 0; i < 9; i += 2)
            {
                aux = 2 * int.Parse(validarCedula[i].ToString());
                if (aux > 9)
                    aux -= 9;
                par += aux;
            }
            for (int i = 1; i < 9; i += 2)
            {
                impar += int.Parse(validarCedula[i].ToString());
            }

            aux = par + impar;
            if (aux % 10 != 0)
            {
                verifi = 10 - (aux % 10);
            }
            else
                verifi = 0;
            if (verifi == int.Parse(validarCedula[9].ToString()))
                return true;
            else
                return false;
        }

        public static bool VerificaPersonaJuridica(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[9] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                for (int i = 0; i < 9; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }
                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[9].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private static bool VerificaSectorPublico(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[9].ToString()) + int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[8] { 3, 2, 7, 6, 5, 4, 3, 2 };

                for (int i = 0; i < 8; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }

                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[8].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}