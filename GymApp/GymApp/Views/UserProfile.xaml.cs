using GymApp.Models.Perfil;
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
    public partial class UserProfile : ContentPage
    {
        public UserProfile()
        {
            InitializeComponent();
            LoadDataView();
        }


        public async void LoadDataView()
        {
            PerfilRequest request = new PerfilRequest()
            {
                personaID = Helpers.Settings.PersonaID
            };

            var response = Functions.Services.ConsultarInfoPerfil(request);

            if (response != null)
            {
                nameUser.Text = response.nombres;
                lastNameUser.Text = response.apellidos;
                phoneUser.Text = response.telefono;
                identificationUser.Text = response.identificacion;
                emailUser.Text = response.email;
                ageUser.Text = response.edad;
                BirthUser.Text = response.fechaNacimiento;
            }
            else
            {
                await DisplayAlert("Alerta","Ha Ocurrido un error al consultar la información del perfil.","Ok");
            }

        }
    }
}