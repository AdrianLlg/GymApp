using GymApp.Models.FichasEntrenamiento;
using GymApp.Models.Instructor.RegistroFichaEntrenamiento;
using GymApp.Views.Instructor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPersonalProgressByDisciplines : ContentPage
    {
        public Dictionary<int, string> dictionaryList = new Dictionary<int, string>();
        public int personaID = 0;
        public int disciplinaID = 0;
        public int fichaPersonaID = 0;

        public UserPersonalProgressByDisciplines(int personID, int discipID, int fichaPersonID)
        {
            InitializeComponent();

            personaID = personID;
            disciplinaID = discipID;
            fichaPersonaID = fichaPersonID;

            LoadData(personaID, disciplinaID);
        }

        public async void LoadData(int personaID, int disciplinaID)
        {
            try
            {
                //Rol Deportista
                if (Helpers.Settings.RoleID == 3)
                {

                    fichaEntrenamientobtn.IsVisible = false;

                    dictionaryList = new Dictionary<int, string>();

                    List<string> disciplinesList = new List<string>();

                    if (Helpers.Settings.MembresiasActivas.Count > 0)
                    {
                        foreach (var item in Helpers.Settings.MembresiasActivas)
                        {
                            foreach (var i in item.disciplinasMemb)
                            {
                                if (!dictionaryList.ContainsKey(i.disciplinaID))
                                {
                                    dictionaryList.Add(i.disciplinaID, i.nombreDisciplina);
                                }

                            }
                        }

                        disciplinesList = dictionaryList.Values.Distinct().ToList();

                    }

                    if (disciplinesList.Count > 0)
                    {
                        foreach (var discipline in disciplinesList)
                        {
                            pickerDiscipline.Items.Add(discipline);
                        }

                        btn_info.IsVisible = true;
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Ocurrió un error al cargar las disciplinas.", "Ok");
                    }
                }
                //Rol Instructor
                else
                {
                    fichaEntrenamientobtn.IsVisible = true;
                    btn_info.IsVisible = false;
                    pickerDiscipline.IsVisible = false;

                    FichasEntrenamientoRequest request = new FichasEntrenamientoRequest()
                    {
                        personaID = personaID,
                        disciplinaID = disciplinaID
                    };

                    var list = Functions.Services.ConsultaFichasEntrenamiento(request);

                    if (list != null)
                    {
                        collectionView.ItemsSource = new ObservableCollection<FichasEntrenamientoContent>(list);
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "No se encontraron fichas para la disciplina escogida.", "Ok");
                    }
                }                
            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrió un error al cargar la información.", "Ok");
            }
        }

        private async void btn_info_Clicked(object sender, EventArgs e)
        {
            var picker = string.Empty;
            int selectedResource = 0;

            try
            {
                picker = pickerDiscipline.SelectedItem.ToString();

                selectedResource = dictionaryList.Where(x => x.Value == picker).Select(x => x.Key).FirstOrDefault();

            }
            catch
            {
                picker = string.Empty;
            }

            if (string.IsNullOrEmpty(picker))
            {
                await DisplayAlert("Alerta", "Por favor, seleccione una disciplina para filtrar.", "Ok");
                return;
            }

            FichasEntrenamientoRequest request = new FichasEntrenamientoRequest()
            {
                personaID = Helpers.Settings.PersonaID,
                disciplinaID = selectedResource
            };

            var list = Functions.Services.ConsultaFichasEntrenamiento(request);

            if (list != null)
            {
                collectionView.ItemsSource = new ObservableCollection<FichasEntrenamientoContent>(list);
            }
            else
            {
                await DisplayAlert("Alerta","No se encontraron fichas para la disciplina escogida.","Ok");
            }
        }

        private async void fichaEntrenamientobtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new TrainingDetailsForms(personaID, disciplinaID, fichaPersonaID));
            }
            catch
            {
                await DisplayAlert("Alerta", "Ocurrió un error al abrir la opción, por favor, intentelo más tarde.", "Ok");
                return;
            }
        }
    }
}