using GymApp.Models.Instructor.SesionesProximasInstructor;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace GymApp.Views.Instructor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpQR : Rg.Plugins.Popup.Pages.PopupPage
    {
        ZXingBarcodeImageView qr;
        public PopUpQR(SesionesProximasInstructorContent session)
        {
            InitializeComponent();

            LoadQRCode(session);

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }


        private void LoadQRCode(SesionesProximasInstructorContent session)
        {
            qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = session.eventoID.ToString();
            QRstack.Children.Add(qr);
        }
    }
}