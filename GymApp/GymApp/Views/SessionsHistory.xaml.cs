using GymApp.Models.HistorialSesiones;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionsHistory : ContentPage
    {
        public SessionsHistory()
        {
            InitializeComponent();
            LoadData();
        }


        public async void LoadData()
        {
            try
            {
                CultureInfo culture = new CultureInfo("es-EC");
                CultureInfo.CurrentCulture = culture;

                HistorialSesionesRequest request = new HistorialSesionesRequest()
                {
                    personaID = Helpers.Settings.PersonaID
                };

                var response = Functions.Services.ObtenerHistorialDeSesiones(request).OrderBy(x => x.Fecha).ToList();

                if (response != null)
                {
                    foreach (var item in response)
                    {
                        if (item.Estado.Equals("A"))
                        {
                            item.estadoText = "Inscrito";
                        }
                        else
                        {
                            item.estadoText = "Cancelado";
                        }

                        DateTime fechaF = DateTime.ParseExact(item.Fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        item.fechaFormato = fechaF.ToLongDateString();

                    }

                    collectionViewHistory.ItemsSource = new ObservableCollection<HistorialSesionesContent>(response);
                }
                else
                {
                    await DisplayAlert("Alerta", "Al momento no cuenta con un historial de sesiones agendadas.", "Ok");
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al consultar la información.", "Ok");
            }
           

        }
    }
}