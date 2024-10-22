﻿using GymApp.Models.Perfil;
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

            NavigationPage.SetHasNavigationBar(this, false);
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
                nameUser.Text = response.nombres + " " + response.apellidos;
                Helpers.Settings.NombrePersona = response.nombres;
                Helpers.Settings.NombreCompleto = response.nombres + " " + response.apellidos;

                phoneUser.Text = response.telefono;
                Helpers.Settings.Celular = response.telefono;

                identificationUser.Text = response.identificacion;
                Helpers.Settings.Cedula = response.identificacion;

                emailUser.Text = response.email;
                Helpers.Settings.Correo = response.email;

                ageUser.Text = response.edad;
                Helpers.Settings.Edad = response.edad;

                BirthUser.Text = response.fechaNacimiento;
                Helpers.Settings.FechaNacimiento = response.fechaNacimiento;
            }
            else
            {
                await DisplayAlert("Alerta","Ha ocurrido un error al consultar la información del perfil.","Ok");
            }


            if (Helpers.Settings.RoleID == 2)
            {
                fichasBtnStack.IsVisible = false;
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int id = Helpers.Settings.PersonaID;
            await Navigation.PushAsync(new UserPersonalProgress(id, 0));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SessionsHistory());
        }
    }
}