using GymApp.Helpers;
using GymApp.Models.Membresias;
using GymAppV2.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Memberships : ContentPage
    {

        public ObservableCollection<MembresiaContent> MembresiasCollection { get; set; }
        public CultureInfo serverCulture;
        public ICommand RefreshCommand { get; }

        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        public Memberships(ObservableCollection<MembresiaContent> listCollection)
        {
            InitializeComponent();
            this.Title = "Membresías";

            LoadServerCulture();

            IsRefreshing = false;

            MembresiasCollection = new ObservableCollection<MembresiaContent>();

            LoadData(listCollection);

            NavigationPage.SetHasNavigationBar(this, false);

            RefreshCommand = new Command(ExecuteRefreshCommand);

            this.BindingContext = this;
        }

        public void LoadServerCulture()
        {
            ServerCultureSetting helper = new ServerCultureSetting();

            serverCulture = helper.SetCultureInfoServer();
        }

        public async void LoadData(ObservableCollection<MembresiaContent> listCollection)
        {
            try
            {
                DateTime hoy = DateTime.Now;
                hoy = hoy.AddMonths(-5);

                if (listCollection != null)
                {

                    foreach (var item in listCollection)
                    {
                        DateTime fechaInicio = DateTime.ParseExact(item.fechaInicioMembresia, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);
                        DateTime fechaFin = DateTime.ParseExact(item.fechaFinMembresia, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);

                        item.fechaInicioMembresiaDate = fechaInicio;
                        item.fechaFinMembresiaDate = fechaFin;

                        if (!string.IsNullOrEmpty(item.fechaPago))
                        {
                            DateTime f = DateTime.Parse(item.fechaPago, serverCulture);
                            item.fechaPagoMembresiaDate = f;
                        }

                        MembresiasCollection.Add(item);
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Actualmente no dispone de membresias.", "Ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar las membresias.", "Ok");
                return;
            }

        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var obj = (ImageButton)sender;

                var membership = (MembresiaContent)obj.BindingContext;

                await Navigation.PushAsync(new MembershipDetails(membership));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error.", "Ok");
                return;
            }

        }

        async void ExecuteRefreshCommand()
        {
            try
            {
                IsRefreshing = true;

                DateTime hoy = DateTime.Now;
                hoy = hoy.AddMonths(-5);
                MembresiasCollection.Clear();

                MembresiaRequest request = new MembresiaRequest()
                {

                    personaID = Helpers.Settings.PersonaID.ToString()
                };

                var response = Functions.Services.ConsultarMembresias(request);

                if (response != null)
                {
                    Helpers.Settings.MembresiasActivas = response.Where(x => x.estado.Equals("A")).ToList();

                    foreach (var item in response)
                    {
                        DateTime fechaInicio = DateTime.ParseExact(item.fechaInicioMembresia, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);
                        DateTime fechaFin = DateTime.ParseExact(item.fechaFinMembresia, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);
                        
                        if (!string.IsNullOrEmpty(item.fechaPago))
                        {
                            DateTime f = DateTime.Parse(item.fechaPago, serverCulture);
                            item.fechaPagoMembresiaDate = f;
                        }

                        item.fechaInicioMembresiaDate = fechaInicio;
                        item.fechaFinMembresiaDate = fechaFin;

                        MembresiasCollection.Add(item);
                    }
                }

                // Stop refreshing
                IsRefreshing = false;
            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al refrescar la información, por favor, intentelo nuevamente más tarde.", "Ok");
                return;
            }

        }
    }
}