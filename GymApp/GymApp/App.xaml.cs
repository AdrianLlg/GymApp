using GymApp.Services;
using GymApp.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();


            if (Helpers.Settings.IsLoged)
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new NavigationPage(new Login());
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

        public bool LogIn(string email, string password)
        {
            Models.Login.LoginRequest item = new Models.Login.LoginRequest()
            {
                email = email,
                password = password
            };

            Models.Login.LoginResponseContent response = Functions.Services.LoginUser(item);

            if (response != null)
            {
                Helpers.Settings.IsLoged = true;
                Helpers.Settings.PersonaID = response.personaID;
                Helpers.Settings.RoleID = response.role;

                MainPage = new AppShell();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task LogOut()
        {
            Helpers.Settings.IsLoged = false;
            Helpers.Settings.PersonaID = 0;
            Helpers.Settings.RoleID = 0;

            MainPage = new NavigationPage(new Login());
        }

    }
}
