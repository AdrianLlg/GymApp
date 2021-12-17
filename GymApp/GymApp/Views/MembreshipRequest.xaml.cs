using GymApp.Models.Membresias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MembreshipRequest : ContentPage
    {
        public MembreshipRequest(MembresiaContent item)
        {
            InitializeComponent();

            cameraButton.Clicked += CameraButton_Clicked;

        }


        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

                if (photo != null)
                {
                    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrio un error al abrir la camara.", "Ok.");
            }
                
        }


    }
}