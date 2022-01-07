using GymApp.Models.FichaPersonal;
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

        public UserPersonalProgress()
        {
            InitializeComponent();
            LoadData();
        }


        public async void LoadData()
        {
            try
            {
                FichaPersonalRequest request = new FichaPersonalRequest()
                {
                    personaID = Helpers.Settings.PersonaID
                };

                item = Functions.Services.ConsultaFichaPersonalUsuario(request);

                if (item != null)
                {
                    mesotipoLabel.Text = item.MesoTipo;
                    lvlActividadLabel.Text = item.NivelActualActividadFisica;
                    antecendentesLabel.Text = item.AntecendesMedicos;
                    alergiasLabel.Text = item.Alergias;
                    enfermedadesLabel.Text = item.Enfermedades;

                    disciplinaButton.IsVisible = true;
                }
                else
                {
                    await DisplayAlert("Alerta", "Al momento no cuenta con una ficha personal, por favor comuníquese con un administrador o instructor del establecimiento para más información.", "Ok");
                    return;
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
            await Navigation.PushAsync(new UserPersonalProgressByDisciplines());
        }
    }
}