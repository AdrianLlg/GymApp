using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using GymApp.Models;
using System.Collections.ObjectModel;
using GymApp.Models.Instructor.RegistroAsistenciaInscritos;

namespace GymApp.Functions
{
    public class Services
    {

        public static bool RegistroUsuario(Models.RegistroPersona.RegistroPersonaRequest value)
        {
            bool res = false;

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiRegistro)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.RegistroPersona.RegistroPersonaResponse>(response.Content).contentCreate;

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Models.Login.LoginResponseContent LoginUser(Models.Login.LoginRequest value)
        {
            Models.Login.LoginResponseContent res = new Models.Login.LoginResponseContent();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiLogin)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Login.LoginResponse>(response.Content).Content;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static ObservableCollection<Models.Membresias.MembresiaContent> ConsultarMembresias(Models.Membresias.MembresiaRequest value)
        {
            ObservableCollection<Models.Membresias.MembresiaContent> res = new ObservableCollection<Models.Membresias.MembresiaContent>();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiMembresias)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Membresias.MembresiaResponse>(response.Content).content;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Models.Perfil.PerfilResponseContent ConsultarInfoPerfil(Models.Perfil.PerfilRequest value)
        {
            Models.Perfil.PerfilResponseContent res = new Models.Perfil.PerfilResponseContent();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiInformacionPerfil)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Perfil.PerfilResponse>(response.Content).contentIndex;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ObservableCollection<Models.Horarios.HorariosDeportistaContent> ConsultaHorarios(Models.Horarios.HorariosDeportistaRequest value)
        {
            ObservableCollection<Models.Horarios.HorariosDeportistaContent> res = new ObservableCollection<Models.Horarios.HorariosDeportistaContent>();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiConsultaHorariosDeportista)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                if (!string.IsNullOrEmpty(response.Content))
                {
                    res = JsonConvert.DeserializeObject<Models.Horarios.HorariosDeportistaResponse>(response.Content).Content;
                }
                else
                {
                    return null;
                }

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Models.InscripcionSesion.InscripcionSesionResponse InscripcionSesion(Models.InscripcionSesion.InscripcionSesionRequest value)
        {
            Models.InscripcionSesion.InscripcionSesionResponse res = new Models.InscripcionSesion.InscripcionSesionResponse();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiInscripcionUsuarioSesion)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.InscripcionSesion.InscripcionSesionResponse>(response.Content);

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool RegistroSolicitudMembresia(Models.RegistroPersona.RegistroPersonaRequest value)
        {
            bool res = false;

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiRegistro)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.RegistroPersona.RegistroPersonaResponse>(response.Content).contentCreate;

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static ObservableCollection<Models.SesionesAgendadas.SesionesAgendadasContent> ConsultarSesionesAgendadas(Models.SesionesAgendadas.SesionesAgendadasRequest value)
        {
            ObservableCollection<Models.SesionesAgendadas.SesionesAgendadasContent> res = new ObservableCollection<Models.SesionesAgendadas.SesionesAgendadasContent>();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiSesionesAgendadas)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.SesionesAgendadas.SesionesAgendadasResponse>(response.Content).Content;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static Models.SolicitudMembresia.SolicitudMembresiaResponse SolicitudMembresia(Models.SolicitudMembresia.SolicitudMembresiaRequest value)
        {
            Models.SolicitudMembresia.SolicitudMembresiaResponse res = new Models.SolicitudMembresia.SolicitudMembresiaResponse();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiRenovacionMembresiaUsuario)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.SolicitudMembresia.SolicitudMembresiaResponse>(response.Content);

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Models.FichaPersonal.FichaPersonalContent ConsultaFichaPersonalUsuario(Models.FichaPersonal.FichaPersonalRequest value)
        {
            Models.FichaPersonal.FichaPersonalContent res = new Models.FichaPersonal.FichaPersonalContent();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiConsultaFichaPersona)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.FichaPersonal.FichaPersonalResponse>(response.Content).ContentIndex;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Models.FichasEntrenamiento.FichasEntrenamientoContent> ConsultaFichasEntrenamiento(Models.FichasEntrenamiento.FichasEntrenamientoRequest value)
        {
            List<Models.FichasEntrenamiento.FichasEntrenamientoContent> res = new List<Models.FichasEntrenamiento.FichasEntrenamientoContent>();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiConsultaFichaEntrenamiento)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.FichasEntrenamiento.FichasEntrenamientoResponse>(response.Content).ContentIndex;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Models.Noticias.NoticiasResponse ConsultarNoticias()
        {
            Models.Noticias.NoticiasResponse res = new Models.Noticias.NoticiasResponse();

            try
            {
                var client = new RestClient(Globals.Config.ApiConsultaNoticias)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\"flujoID\":" + 0 + "}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Noticias.NoticiasResponse>(response.Content);

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Models.HistorialSesiones.HistorialSesionesContent> ObtenerHistorialDeSesiones(Models.HistorialSesiones.HistorialSesionesRequest value)
        {
            List<Models.HistorialSesiones.HistorialSesionesContent> res = new List<Models.HistorialSesiones.HistorialSesionesContent>();

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiConsultaHistorialAsistenciaCliente)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.HistorialSesiones.HistorialSesionesResponse>(response.Content).Content;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Models.DisciplinasInfo.DisciplinasInfoContent> ObtenerDisciplinas()
        {
            List<Models.DisciplinasInfo.DisciplinasInfoContent> res = new List<Models.DisciplinasInfo.DisciplinasInfoContent>();

            try
            {
                //string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiConsultaDisciplinasDeportista)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\"flujoID\":" + 0 + "}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.DisciplinasInfo.DisciplinasInfoResponse>(response.Content).Content;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Models.Instructor.SesionesProximasInstructor.SesionesProximasInstructorContent> ObtenerSesionesProximasInstructor(int value)
        {
            List<Models.Instructor.SesionesProximasInstructor.SesionesProximasInstructorContent> res = new List<Models.Instructor.SesionesProximasInstructor.SesionesProximasInstructorContent>();

            try
            {
                //string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiConsultaClasesPendientesInstructor)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\"personaID\":" + value + "}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Instructor.SesionesProximasInstructor.SesionesProximasInstructorResponse>(response.Content).ContentIndex;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool ValidaHoraRegistroAsistencia(int value)
        {
            bool res = false;

            try
            {
                //string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiGenerarQRInstructor)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\"eventoID\":" + value + "}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Instructor.PermitirTomarAsistencia.TomarAsistencia.TomarAsistenciaResponse>(response.Content).content;

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool CancelarSesionInstructor(Models.Instructor.CancelarSesion.CancelarSesionRequest value)
        {
            bool res = false;

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiGenerarCancelarEventoApp)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Instructor.CancelarSesion.CancelarSesionResponse>(response.Content).Content;

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static List<Models.Instructor.SesionListaAsistentes.SesionListaAsistentesContent> ObtenerAsistentesEvento(int value)
        {
            List<Models.Instructor.SesionListaAsistentes.SesionListaAsistentesContent> res = new List<Models.Instructor.SesionListaAsistentes.SesionListaAsistentesContent>();

            try
            {
                //string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiConsultaListaAsistencia)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\"eventoID\":" + value + "}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Instructor.SesionListaAsistentes.SesionListaAsistentesResponse>(response.Content).ContentIndex;

                if (res == null)
                {
                    return new List<Models.Instructor.SesionListaAsistentes.SesionListaAsistentesContent>();
                }

                return res;
            }
            catch (Exception ex)
            {
                return res;

            }
        }

        public static bool RegistrarAsistenciaManual(RegistroAsistenciaInscritosRequest value)
        {
            bool res = false;

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiRegistrarAsistenciaManual)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<RegistroAsistenciaInscritosResponse>(response.Content).content;

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool RegistroFichaPersonaInstructor(Models.Instructor.RegistroFichaPersona.RegistroFichaPersonaRequest value)
        {
            bool res = false;

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiCrearFichaPersona)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Instructor.RegistroFichaPersona.RegistroFichaPersonaResponse>(response.Content).ContentCreate;

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool RegistroFichaEntrenamientoInstructor(Models.Instructor.RegistroFichaEntrenamiento.RegistroFichaEntrenamientoRequest value)
        {
            bool res = false;

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiCrearFichaEntrenamiento)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Instructor.RegistroFichaEntrenamiento.RegistroFichaEntrenamientoResponse>(response.Content).ContentCreate;

                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<Models.Membresias.MembresiasList.MembresiasListContent> GetMembresiasEstablecimiento(int value)
        {
            List<Models.Membresias.MembresiasList.MembresiasListContent> res = new List<Models.Membresias.MembresiasList.MembresiasListContent>();

            try
            {
                //string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiMembresiaAdmin)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", "{\"flujoID\":" + value + "}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.Membresias.MembresiasList.MembresiasListResponse>(response.Content).ContentIndex;

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string RegistroAsistenciaDeportista(Models.RegistroAsistenciaQR.RegistroAsistenciaQRRequest value)
        {
            string res = string.Empty;

            try
            {
                string body = JsonConvert.SerializeObject(value);

                var client = new RestClient(Globals.Config.ApiRegistrarAsistenciaEventoPersona)
                {
                    Timeout = -1
                };

                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", body, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                res = JsonConvert.DeserializeObject<Models.RegistroAsistenciaQR.RegistroAsistenciaQRResponse>(response.Content).ResponseMessage;

                return res;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
