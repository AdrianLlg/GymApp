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
    public partial class News : ContentPage
    {
        public News()
        {
            InitializeComponent();
            LoadData();
        }

        public async void LoadData()
        {
            try
            {
                var response = Functions.Services.ConsultarNoticias();

                if (response != null)
                {
                    //Esta trayendo null cuando no hay noticias
                    if (response.ContentIndex != null)
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