using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using GymApp.Models;
using System.Collections.ObjectModel;

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
    }
}
