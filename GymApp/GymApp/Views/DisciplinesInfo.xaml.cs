using GymApp.Models.DisciplinasInfo;
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
    public partial class DisciplinesInfo : ContentPage
    {
        public ObservableCollection<DisciplinasInfoModel> ObjectCollection = new ObservableCollection<DisciplinasInfoModel>();

        public DisciplinesInfo()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                var response = Functions.Services.ObtenerDisciplinas();

                if (response != null)
                {
                    foreach (var item in response)
                    {
                        if (item.clases == null)
                        {                            

                            List<ClaseDisciplina> list = new List<ClaseDisciplina>();

                            list.Add(new ClaseDisciplina
                            {
                                claseID = 0,
                                NombreClase = "",
                                DescripcionClase = "",
                                VisibleClases = false,
                                VisibleNoClases = true
                            });

                            ObjectCollection.Add(new DisciplinasInfoModel(item.NombreDisciplina, list));
                        }
                        else
                        {
                            foreach (var i in item.clases)
                            {
                                i.VisibleClases = true;
                                i.VisibleNoClases = false;
                            }

                            ObjectCollection.Add(new DisciplinasInfoModel(item.NombreDisciplina, item.clases));
                        }

                    }

                    collectionViewDisciplines.ItemsSource = ObjectCollection;

                }
                else
                {
                    await DisplayAlert("Alerta", "Al momento no hemos encontrado disciplinas del establecimiento, por favor, intentelo más tarde.", "Ok");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar las disciplinas del establecimiento.", "Ok");
            }




        }

    }
}