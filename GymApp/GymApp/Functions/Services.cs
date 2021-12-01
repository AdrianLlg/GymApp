using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using GymApp.Models;

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

                res = JsonConvert.DeserializeObject<Models.RegistroPersona.RegistroPersonaResponse>(response.Content).content;

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
        public static List<Models.Membresias.MembresiaContent> ConsultarMembresia(Models.Membresias.MembresiaRequest value)
        {
            List<Models.Membresias.MembresiaContent> res = new List<Models.Membresias.MembresiaContent>();

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
                return res;
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
    }
}
