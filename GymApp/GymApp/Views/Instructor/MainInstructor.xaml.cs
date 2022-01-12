using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views.Instructor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainInstructor : ContentPage
    {
        public MainInstructor()
        {
            InitializeComponent();
            LoadData();
            NavigationPage.SetHasNavigationBar(this, false);
        }


        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await (Application.Current as App).LogOut();

        }
        private void LoadData()
        {
            welcomeLabel.Text = "Hola " + Helpers.Settings.NombrePersona + "!";
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SchedulesInstructor());
        }
    }
}