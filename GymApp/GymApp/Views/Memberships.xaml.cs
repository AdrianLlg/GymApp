using GymApp.Models.Membresias;
using GymAppV2.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Memberships : ContentPage
    {

        public ObservableCollection<MembresiaContent> MembresiasCollection;
        public Memberships(ObservableCollection<MembresiaContent> listCollection)
        {
            InitializeComponent();
            this.Title = "Membresías";

            MembresiasCollection = listCollection;

            NavigationPage.SetHasNavigationBar(this, false);
            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                DateTime hoy = DateTime.Now;
                hoy = hoy.AddMonths(-5);

                if (MembresiasCollection != null)
                {
                    foreach (var item in MembresiasCollection)
                    {
                        DateTime fechaInicio = DateTime.ParseExact(item.fechaInicioMembresia, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);
                        DateTime fechaFin = DateTime.ParseExact(item.fechaFinMembresia, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);
                        DateTime fechaPago = DateTime.ParseExact(item.fechaPago, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        item.fechaInicioMembresiaDate = fechaInicio;
                        item.fechaFinMembresiaDate = fechaFin;
                        item.fechaPagoMembresiaDate = fechaPago;
                    }

                    var list = MembresiasCollection.Where(x => x.fechaInicioMembresiaDate > hoy.Date).ToList();

                    MembresiasCollection = new ObservableCollection<MembresiaContent>(list);

                    collectionView.ItemsSource = MembresiasCollection;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error.", "Ok");
                return;
            }


        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (ImageButton)sender;

                var membership = (MembresiaContent)obj.BindingContext;               
                
                await Navigation.PushAsync(new MembershipDetails(membership));
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error.", "Ok");
                return;
            }

        }
    }
}