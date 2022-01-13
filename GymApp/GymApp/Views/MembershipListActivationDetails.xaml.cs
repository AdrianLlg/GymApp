using GymApp.Models.Membresias.MembresiasList;
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
    public partial class MembershipListActivationDetails : ContentPage
    {
        public MembresiasListContent content;
        public MembershipListActivationDetails(MembresiasListContent obj)
        {
            InitializeComponent();

            content = obj;

            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                nombreMembLabel.Text = content.Nombre;
                precioMembLabel.Text = content.Precio.ToString();
                periodicidadMembLabel.Text = content.Periodicidad;

                if (content.membresiaDisciplinas != null)
                {
                    collectionViewDisciplines.ItemsSource = new ObservableCollection<MembresiasListDisciplines>(content.membresiaDisciplinas);
                }
                else
                {
                    collectionViewDisciplines.IsVisible = false;
                }

            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar la información.", "Ok");
                return;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MembreshipRequest(content.MembresiaID));
        }
    }
}