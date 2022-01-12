using GymApp.Models.FichaPersonal;
using GymApp.Models.Instructor.RegistroFichaPersona;
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
    public partial class UserPersonalProgress : ContentPage
    {
        public FichaPersonalContent item;
        public int personaID = 0;
        public int disciplinaID = 0;
        public int fichaPersonaID = 0;

        public UserPersonalProgress(int personID, int disID)
        {
            InitializeComponent();

            personaID = personID;
            disciplinaID = disID;

            LoadData(personID);
        }


        public async void LoadData(int id)
        {
            try
            {
                FichaPersonalRequest request = new FichaPersonalRequest()
                {
                    personaID = id
                };

                item = Functions.Services.ConsultaFichaPersonalUsuario(request);

                if (item != null)
                {
                    mesotipoLabel.Text = item.MesoTipo;
                    lvlActividadLabel.Text = item.NivelActualActividadFisica;
                    antecendentesLabel.Text = item.AntecendesMedicos;
                    alergiasLabel.Text = item.Alergias;
                    enfermedadesLabel.Text = item.Enfermedades;
                    fichaPersonaID = item.fichaPersonaID;

                    disciplinaButton.IsVisible = true;
                }
                else
                {

                    stackInfo.IsVisible = false;
                    noFicha.IsVisible = true;
                    disciplinaButton.IsVisible = false;

                    if (Helpers.Settings.RoleID == 2)
                    {
                        fichaRegistrobtn.IsVisible = true;
                        stackFillInfo.IsVisible = true;
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Al momento no cuenta con una ficha personal, por favor comuníquese con un administrador o instructor del establecimiento para más información.", "Ok");
                        return;
                    }                   
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar el contenido.", "Ok");
                return;
            }

        }

        private async void disciplinaButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserPersonalProgressByDisciplines(personaID, disciplinaID, fichaPersonaID));
        }

        private async void fichaRegistrobtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                var mesotipo = string.Empty;
                var actividadF = string.Empty;


                if (string.IsNullOrEmpty(antecedentesEntry.Text) || string.IsNullOrEmpty(alergiasEntry.Text)
                              || string.IsNullOrEmpty(enfermedadesEntry.Text))
                {
                    await DisplayAlert("Alerta", "Todos los campos son obligatorios, por favor verifique la información proporcionada. Tip: Si algun campo no lo dispone o no desea responder, puede colocar N/A.", "Ok");
                    return;
                }

                try
                {
                    mesotipo = pickerMesoTipo.SelectedItem.ToString();
                    actividadF = pickerActividadFisica.SelectedItem.ToString();
                }
                catch
                {
                    await DisplayAlert("Alerta", "Todos los campos son obligatorios, por favor verifique la información proporcionada. Tip: Si algun campo no lo dispone o no desea responder, puede colocar N/A.", "Ok");
                    return;
                }


                RegistroFichaPersonaRequest request = new RegistroFichaPersonaRequest()
                {
                    flujoID = 1,
                    PersonaID = personaID,
                    NivelActualActividadFisica = actividadF,
                    Alergias = alergiasEntry.Text,
                    Enfermedades = enfermedadesEntry.Text,
                    AntecendesMedicos = antecedentesEntry.Text,
                    MesoTipo = mesotipo
                };

                var response = Functions.Services.RegistroFichaPersonaInstructor(request);

                if (response)
                {
                    await DisplayAlert("Alerta", "Se ha registrado con exito la ficha de la persona.", "Ok");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alerta", "Ocurrió un error al registrar la ficha, por favor, intentelo nuevamente más tarde.", "Ok");
                    await Navigation.PopAsync();
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al registrar la ficha personal.", "Ok");
                return;
            }
          
        }
    }
}