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
                DateTime fechaInicio = DateTime.ParseExact(content.fecha + " " + content.horaInicioEvento, "yyyy-MM-dd HHmm", CultureInfo.InvariantCulture);

                CultureInfo cultureEC = new CultureInfo("es-EC");
                CultureInfo.CurrentCulture = cultureEC;

                DisciplinaLabel.Text = content.disciplina;
                HoraLabel.Text = content.horaFormatoString;
                InstructorLabel.Text = content.nombreInstructor;
                FechaLabel.Text = fechaInicio.ToLongDateString();
                SalaLabel.Text = content.sala;
                AsistentesLabel.Text = content.cupos;

                //Validar con hora incluida en la fecha
                if (content.asistenciaEvento == content.aforoMax || DateTime.Now >= fechaInicio)
                {
                    InscripcionButton.IsVisible = false;
                    QuitarInscripcionButton.IsVisible = false;
                    HasSpecialResources.IsVisible = false;
                    conditionsLabel.IsVisible = false;
                }
                else
                {
                    if (content.estadoInscripcion.Equals("N") || content.estadoInscripcion.Equals("C"))
                    {
                        if (content.recursosEspeciales != null)
                        {
                            InscripcionButton.IsVisible = false;
                            HasSpecialResources.IsVisible = true;
                            QuitarInscripcionButton.IsVisible = false;
                        }
                        else
                        {
                            InscripcionButton.IsVisible = true;
                            HasSpecialResources.IsVisible = false;
                            QuitarInscripcionButton.IsVisible = false;
                        }
                    }
                    else
                    {
                        InscripcionButton.IsVisible = false;
                        HasSpecialResources.IsVisible = false;
                        QuitarInscripcionButton.IsVisible = true;
                    }
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar el contenido.", "Ok");
                return;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (item.recursosEspeciales == null)
                {
                    InscripcionSesionRequest obj = new InscripcionSesionRequest()
                    {
                        eventoID = item.eventoID,
                        personaID = Helpers.Settings.PersonaID,
                        estado = "A",
                        recursoAsignado = item.recursoEspecialPersona,
                        recursosEvento = false
                    };

                    var resp = Functions.Services.InscripcionSesion(obj);

                    if (resp != null)
                    {
                        if (resp.Content)
                        {
                            await DisplayAlert("Alerta", "Se ha registrado su inscripcion a esta sesión satisfactoriamente.", "Ok");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            if (resp.ResponseMessage.Equals("IntentosCancelar"))
                            {
                                await DisplayAlert("Alerta", "No se puede registrar su cancelacion debido a que ya ha superado el limite de intentos permitidos para cancelar esta sesion.", "Ok");
                            }
                            else if (resp.ResponseMessage.Equals("HorarioCancelar"))
                            {
                                await DisplayAlert("Alerta", "No se puede anular la inscripcion debido a que ha superado la hora permitida para cancelar su sesion.", "Ok");
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Ha ocurrido un error al registrarlo en la sesión, intentelo de nuevo más tarde.", "Ok");
                    }
                }
                else
                {
                    await Navigation.PushAsync(new SpecialResourceSelection(item));
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error en el proceso.", "Ok");
                return;
            }
        }

        private async void Button_Clicked2(object sender, EventArgs e)
        {
            try
            {
                bool recEv = false;

                if (item.recursosEspeciales != null)
                {
                    recEv = true;
                }

                InscripcionSesionRequest obj = new InscripcionSesionRequest()
                {
                    eventoID = item.eventoID,
                    personaID = Helpers.Settings.PersonaID,
                    estado = "C",
                    recursosEvento = recEv,
                    recursoAsignado = item.recursoEspecialPersona
                };

                var resp = Functions.Services.InscripcionSesion(obj);

                if (resp != null)
                {
                    if (resp.Content)
                    {
                        await DisplayAlert("Alerta", "Se ha registrado su cancelación a esta sesión satisfactoriamente.", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        if (resp.ResponseMessage.Equals("IntentosCancelar"))
                        {
                            await DisplayAlert("Alerta", "No se puede registrar su cancelación debido a que ya ha superado el límite de intentos permitidos para cancelar esta sesión.", "Ok");
                        }

                        if (resp.ResponseMessage.Equals("HorarioCancelar"))
                        {
                            await DisplayAlert("Alerta", "No se puede cancelar la inscripción debido a que ha superado la hora permitida para cancelar su sesión.", "Ok");
                        }
                    }
                }
                else
                {
                    await DisplayAlert("Alerta", "Ha ocurrido un error al cancelar su inscripción, intentelo de nuevo más tarde.", "Ok");
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