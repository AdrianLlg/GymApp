using GymApp.Models.Membresias;
using GymApp.Views;
using GymApp.Views.Instructor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace GymApp
{
    public partial class AppShell : TabbedPage
    {
        public List<MembresiaContent> MembresiasActivas = new List<MembresiaContent>();
        public AppShell()
        {
            InitializeComponent();

            if (Helpers.Settings.RoleID == 3)
            {
                ObservableCollection<MembresiaContent> MembresiasCollection = GetMemberships();

                if (MembresiasCollection.Count > 0)
                {
                    this.Children.Add(new NavigationPage(new Memberships(MembresiasCollection)) { Title = "Membresías", IconImageSource = "icon_feed.png" });
                }

                this.Children.Add(new NavigationPage(new UserProfile()) { Title = "Perfil", IconImageSource = "icon_home.png" });
                this.Children.Add(new NavigationPage(new Main()) { Title = "Inicio", IconImageSource = "icon_star.png" });

                if (Helpers.Settings.MembresiasActivas.Count > 0)
                {
                    this.Children.Add(new NavigationPage(new Schedules()) { Title = "Agendamiento", IconImageSource = "icon_about.png" });
                }

                this.Children.Add(new DisciplinesInfo() { Title = "Disciplinas", IconImageSource = "icon_about.png" });

                if (Helpers.Settings.MembresiasActivas.Count > 0)
                {
                    this.CurrentPage = this.Children[2];
                }

            }
            else if (Helpers.Settings.RoleID == 2)
            {
                this.Children.Add(new NavigationPage(new UserProfile()) { Title = "Perfil", IconImageSource = "icon_home.png" });
                this.Children.Add(new NavigationPage(new MainInstructor()) { Title = "Agendas", IconImageSource = "icon_star.png" });
            }
        }


        public ObservableCollection<MembresiaContent> GetMemberships()
        {
            try
            {
                MembresiaRequest request = new MembresiaRequest()
                {

                    personaID = Helpers.Settings.PersonaID.ToString()
                };

                var response = Functions.Services.ConsultarMembresias(request);

                if (response != null)
                {
                    Helpers.Settings.MembresiasActivas = response.Where(x => x.estado.Equals("A")).ToList();

                    return response;
                }
                else
                {
                    return new ObservableCollection<MembresiaContent>();
                }
            }
            catch
            {
                return new ObservableCollection<MembresiaContent>();
            }

        }

    }
}
