using GymApp.Models.Membresias;
using GymApp.Models.Noticias;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {

        public Main()
        {
            InitializeComponent();
            LoadData();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await(Application.Current as App).LogOut();

        }

        private void LoadData()
        {
            welcomeLabel.Text = "Hola " + Helpers.Settings.NombrePersona + "!";
        }


        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SessionsScheduled());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new News());
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MembershipListActivation());
        }
    }
}