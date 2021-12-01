using GymApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GymApp
{
    public partial class AppShell : TabbedPage
    {
        public AppShell()
        {
            InitializeComponent();

            if (Helpers.Settings.RoleID == 3)
            {
                this.Children.Add(new Main() { Title = "Inicio", IconImageSource = "icon_home.png" });
                this.Children.Add(new Memberships() { Title = "Membresías", IconImageSource = "icon_feed.png" });
                this.Children.Add(new Schedules() { Title = "Horarios", IconImageSource = "icon_about.png" });
                this.Children.Add(new UserProfile() { Title = "Perfil", IconImageSource = "icon_home.png" });
            }
        }

    }
}
