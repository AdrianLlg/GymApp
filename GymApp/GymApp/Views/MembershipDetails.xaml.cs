using GymApp.Models.Membresias;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembershipDetails : ContentPage
    {
        public MembresiaContent obj;

        public MembershipDetails(MembresiaContent item)
        {
            InitializeComponent();

            obj = item;

            LoadData(obj);
        }

        public async void LoadData(MembresiaContent item)
        {
            try
            {
                CultureInfo culture = new CultureInfo("es-EC");
                CultureInfo.CurrentCulture = culture;

                nombreMembLabel.Text = item.nombreMembresia;
                precioMembLabel.Text = item.precioMembresia.ToString();
                periodicidadMembLabel.Text = item.periodicidadMembresia;
                fechaInicioMembLabel.Text = item.fechaInicioMembresiaDate.ToLongDateString();
                fechaFinMembLabel.Text = item.fechaFinMembresiaDate.ToLongDateString();
                fechaPagoMembLabel.Text = item.fechaPagoMembresiaDate.ToLongDateString();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error.", "Ok");
                return;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MembreshipRequest(obj));
        }
    }
}