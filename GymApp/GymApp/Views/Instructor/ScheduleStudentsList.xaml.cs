using GymApp.Models.Instructor.RegistroAsistenciaInscritos;
using GymApp.Models.Instructor.SesionesProximasInstructor;
using GymApp.Models.Instructor.SesionListaAsistentes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GymApp.Views.Instructor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleStudentsList : ContentPage
    {
        public List<RegistroAsistenciaInscritosEntity> asistentesList = new List<RegistroAsistenciaInscritosEntity>();
        public List<SesionListaAsistentesContent> attendantsList = new List<SesionListaAsistentesContent>();
        public SesionesProximasInstructorContent objectS;

        public ScheduleStudentsList(SesionesProximasInstructorContent objS, List<SesionListaAsistentesContent> attendants, bool validaHorario)
        {

            InitializeComponent();

            attendantsList = attendants;
            objectS = objS;

            LoadData(attendants, validaHorario);

        }

        public async void LoadData(List<SesionListaAsistentesContent> attendants, bool validaHorario)
        {
            try
            {
                if (validaHorario == false)
                {
                    registrarAsistenciaBtn.IsVisible = false;
                }

                if (attendants.Count > 0)
                {
                    foreach (var item in attendants)
                    {
                        if (item.asistencia == 1)
                        {
                            item.asistenciaCheckbox = true;
                        }
                        else
                        {
                            item.asistenciaCheckbox = false;
                        }

                        if (validaHorario)
                        {
                            item.enableCheckBox = true;
                        }
                        else
                        {
                            item.enableCheckBox = false;
                        }
                    }
                    asistentesTitleLabel.Text = "Asistentes: " + attendants.Count.ToString();
                    collectionViewListAttendants.ItemsSource = new ObservableCollection<SesionListaAsistentesContent>(attendants);
                }
                else
                {
                    asistentesTitleLabel.Text = "Asistentes: 0";
                    collectionViewListAttendants.IsVisible = false;
                    noAttendants.IsVisible = true;
                    noAttendants.Text = "Actualmente no tiene inscritos en la sesión.";
                }

            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al cargar los inscritos de la sesión.", "Ok");
                return;
            }
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var btn = (ImageButton)sender;
            var student = (SesionListaAsistentesContent)btn.BindingContext;

            await Navigation.PushAsync(new UserPersonalProgress(student.personaID, objectS.disciplinaID));
        }
        private async void ButtonAsistencia_Clicked(object sender, EventArgs e)
        {
            try
            {
                var respAlert = await DisplayAlert("Alerta", "Por favor, verifique la información antes de enviarla. Desea continuar con el registro?", "Ok", "Cancelar");

                if (respAlert)
                {
                    asistentesList = new List<RegistroAsistenciaInscritosEntity>();

                    foreach (var student in attendantsList)
                    {
                        if (student.asistenciaCheckbox)
                        {
                            student.asistencia = 1;
                        }
                        else
                        {
                            student.asistencia = 0;
                        }

                        asistentesList.Add(new RegistroAsistenciaInscritosEntity
                        {
                            evento_personaID = student.eventoPersonaID,
                            asistencia = student.asistencia
                        });
                    }

                    RegistroAsistenciaInscritosRequest request = new RegistroAsistenciaInscritosRequest()
                    {
                        listaAsistencia = asistentesList
                    };

                    var resp = Functions.Services.RegistrarAsistenciaManual(request);

                    if (resp)
                    {
                        await DisplayAlert("Alerta", "Se ha registrado exitosamente la asistencia.", "Ok");
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Alerta", "Ha ocurrido un error al registrar la asistencia, por favor, intentelo nuevamente más tarde.", "Ok");
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            catch
            {
                await DisplayAlert("Alerta", "Ha ocurrido un error al registrar la asistencia, por favor, intentelo nuevamente más tarde.", "Ok");
                return;
            }



        }
    }
}