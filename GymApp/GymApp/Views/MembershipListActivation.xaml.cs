using GymApp.Models.Membresias.MembresiasList;
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
    public partial class MembershipListActivation : ContentPage
    {
        public MembershipListActivation()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                var response = Functions.Services.GetMembresiasEstablecimiento(0);

                if (response != null)
                {
                    listviewMembresias.ItemsSource = response;
                }
                else
                {
                    await DisplayAlert("Alerta", "Al momento no hemos encontrado membresias disponibles, intentelo nuevamente más tarde.", "Ok");
                    return;
                }


            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar las membresías.", "Ok");
                return;
            }
        }


        private async void listviewMembresias_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var obj = e.Item as MembresiasListContent;

            await Navigation.PushAsync(new MembershipListActivationDetails(obj));

        }
    }
}