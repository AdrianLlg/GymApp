using GymApp.Models.Horarios;
using GymApp.Models.InscripcionSesion;
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
    public partial class SpecialResourceSelection : ContentPage
    {
        public static HorariosDeportistaContent item;
        public Dictionary<int, string> items = new Dictionary<int, string>();

        public SpecialResourceSelection(HorariosDeportistaContent content)
        {
            InitializeComponent();

            item = content;

            LoadData(item);
        }


        public async void LoadData(HorariosDeportistaContent content)
        {
            try
            {
                content.recursosEspecialesDisponibles = content.recursosEspeciales.Where(x => x.personaID == 0).ToList();

                if (content.recursosEspecialesDisponibles.Count > 0)
                {
                    foreach (var item in content.recursosEspecialesDisponibles)
                    {
                        items.Add(item.eventoRecursoID, item.nombreRecurso + ": " + item.descripcionRecurso);

                        pickerPlace.Items.Add(item.nombreRecurso + ": " + item.descripcionRecurso);
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Al momento la sesión no cuenta con lugares.", "Ok");
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Al momento la sesión no cuenta con lugares.", "Ok");
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var picker = string.Empty;
            int selectedResource = 0;

            try
            {
                try
                {
                    picker = pickerPlace.SelectedItem.ToString();

                    selectedResource = items.Where(x => x.Value == picker).Select(x => x.Key).FirstOrDefault();

                }
                catch
                {
                    picker = string.Empty;
                }

                if (string.IsNullOrEmpty(picker))
                {
                    await DisplayAlert("Alerta", "Por favor, seleccione un lugar en la sesión.", "Ok");
                    return;
                }

                InscripcionSesionRequest obj = new InscripcionSesionRequest()
                {
                    eventoID = item.eventoID,
                    personaID = Helpers.Settings.PersonaID,
                    estado = "A",
                    recursoAsignado = selectedResource,
                    recursosEvento = true
                };

                var resp = Functions.Services.InscripcionSesion(obj);

                if (resp != null)
                {
                    if (resp.Content)
                    {
                        await DisplayAlert("Alerta", "Se ha registrado su inscripción a esta sesión satisfactoriamente.", "Ok");
                        await Navigation.PopToRootAsync();
                    }
                    else
                    {
                        if (resp.ResponseMessage.Equals("IntentosCancelar"))
                        {
                            await DisplayAlert("Alerta", "No se puede registrar su inscripción debido a que ya ha superado el límite de intentos permitidos para cancelar esta sesión.", "Ok");
                        }
                        else if (resp.ResponseMessage.Equals("HorarioCancelar"))
                        {
                            await DisplayAlert("Alerta", "No se puede anular la inscripción debido a que ha superado la hora permitida para cancelar su sesion.", "Ok");
                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Ocurrió un error al intentar realizar la inscripción, por favor, inténtenlo más tarde.", "Ok");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Ha ocurrido un error al registrarlo en la sesión, intentelo de nuevo más tarde.", "Ok");
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error en el proceso.", "Ok");
                return;
            }
        }


    }
}