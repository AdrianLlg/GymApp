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
            //Task.Run(AnimateBackground);
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await(Application.Current as App).LogOut();

        }

        private void LoadData()
        {
            welcomeLabel.Text = "Hola " + Helpers.Settings.NombrePersona + "!";
        }

        //private async void AnimateBackground()
        //{
        //    Action<double> forward = input => bdGradient.AnchorY = input;
        //    Action<double> backward = input => bdGradient.AnchorY = input;

        //    while (true)
        //    {
        //        bdGradient.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 5000, easing: Easing.SinIn);
        //        await Task.Delay(5000);
        //        bdGradient.Animate(name: "backward", callback: backward, start: 1, end: 0, length: 5000, easing: Easing.SinIn);
        //        await Task.Delay(5000);
        //    }
        //}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SessionsScheduled());
        }


        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var response = Functions.Services.ConsultarNoticias();

                if (response != null)
                {
                    if (response.ContentIndex.Count > 0)
                    {
                        NoticiasLabel.Text = "Noticias: ";

                        foreach (var item in response.ContentIndex)
                        {
                            item.DisplayImage = ImageSource.FromStream(
                                () => new MemoryStream(Convert.FromBase64String(item.imagen)));
                        }

                        collectionViewNoticias.ItemsSource = new ObservableCollection<NoticiasContent>(response.ContentIndex);
                    }
                    else
                    {
                        NoticiasLabel.Text = "Al momento no hay noticias! ";
                    }                   

                }
                else
                {
                    await DisplayAlert("Alerta", "Ha ocurrido un error al cargar las noticias.", "Ok");
                }

            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar las noticias.", "Ok");
                return;
            }
           
        }

        


    }
}