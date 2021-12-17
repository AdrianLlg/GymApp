using GymApp.Models.Horarios;
using GymApp.Models.InscripcionSesion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleDetails : ContentPage
    {
        public static HorariosDeportistaContent item;
        public ScheduleDetails(HorariosDeportistaContent content)
        {
            InitializeComponent();
            this.Title = "Detalles Horario";

            item = content;

            LoadData(item);
        }

        public async void LoadData(HorariosDeportistaContent content)
        {
            try
            {
                DateTime fecha = DateTime.ParseExact(content.fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                CultureInfo cultureEC = new CultureInfo("es-EC");
                CultureInfo.CurrentCulture = cultureEC;

                DisciplinaLabel.Text = content.disciplina;
                HoraLabel.Text = content.horaFormatoString;
                InstructorLabel.Text = "Nombre del instructor";
                FechaLabel.Text = fecha.ToLongDateString();
                SalaLabel.Text = content.sala;
                AsistentesLabel.Text = content.asistencia.ToString() + "/" + content.aforoMax.ToString();

                if (string.IsNullOrEmpty(item.estadoInscripcion) || item.estadoInscripcion.Equals("I"))
                {
                    InscripcionButton.Text = "Inscribirme";
                }
                else
                {
                    InscripcionButton.Text = "Quitar Inscripcion";
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar el contenido.", "Ok");
                return;
            }           
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                InscripcionSesionRequest obj = new InscripcionSesionRequest()
                {
                    eventoID = item.eventoID,
                    personaID = Helpers.Settings.PersonaID,
                    estado = item.estadoInscripcion
                };

                var resp = Functions.Services.InscripcionSesion(obj);

                if (resp)
                {
                    if (string.IsNullOrEmpty(item.estadoInscripcion))
                    {
                        await DisplayAlert("Alerta", "Se ha registrado su inscripcion de esta sesión satisfactoriamente.", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        if (item.estadoInscripcion.Equals("A"))
                        {
                            await DisplayAlert("Alerta", "Se ha registrado su retiro de esta sesión satisfactoriamente.", "Ok");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert("Alerta", "Se ha registrado su inscripcion de esta sesión satisfactoriamente.", "Ok");
                            await Navigation.PopAsync();
                        }                        
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Ha ocurrido un error al registrarlo en la sesión, intentelo de nuevo mas tarde.", "Ok");
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