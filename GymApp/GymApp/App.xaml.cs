using GymApp.Services;
using GymApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();


            if (Helpers.Settings.IsLoged)
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new Login();
            }           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
