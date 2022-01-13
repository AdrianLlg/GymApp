using GymApp.Models.Membresias;
using GymApp.Models.SolicitudMembresia;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class MembreshipRequest : ContentPage
    {
        //public MediaFile file;
        public int membresiaID;
        public byte[] imageBytes = null;

        public MembreshipRequest(int item)
        {
            InitializeComponent();

            membresiaID = item;

        }
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                // file = null;

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Sin Cámara", ":( La cámara no se encuentra disponible.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {

                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                imageBytes = GetBytesImage(file);

                PhotoImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrió un error al abrir la cámara.", "Ok.");
            }

        }

        private async void galleryButton_Clicked(object sender, EventArgs e)
        {
            MediaFile file = null;

            try
            {
                file = null;

                file  = await CrossMedia.Current.PickPhotoAsync();

                //Not returning false here so we do not show an error if they simply hit cancel from the device's image picker
                if (file == null)
                {
                    return;
                }
                else
                {
                    imageBytes = GetBytesImage(file);

                    PhotoImage.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al obtener la imagen seleccionada.", "Ok");
                return;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (imageBytes == null)
                {
                    await DisplayAlert("Alerta", "Por favor, adjunte un comprobante del pago realizado. Caso contrario, no podrá culminar el proceso.", "Ok");
                    return;
                }

                SolicitudMembresiaRequest request = new SolicitudMembresiaRequest()
                {

                    personaID = Helpers.Settings.PersonaID,
                    membresiaID = membresiaID,
                    imagen = Convert.ToBase64String(imageBytes)

                };

                var response = Functions.Services.SolicitudMembresia(request);

                if (response.Content)
                {
                    await DisplayAlert("Alerta", "Solicitud enviada con éxito.", "Ok");
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    if (response.ResponseMessage.Equals("SolicitudPrevia"))
                    {
                        await DisplayAlert("Alerta", "Actualmente ya tiene una solicitud en proceso. Solo puede realizar una solicitud por membresía a la vez.", "Ok");
                        return;
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Ocurrió un error con el envío de su solicitud, por favor, vuelva a intentarlo más tarde.", "Ok");
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Ocurrió un error en el envío de su solicitud.", "Ok");
            }
            
        }

        private byte[] GetBytesImage(MediaFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}