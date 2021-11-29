using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

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

                res = JsonConvert.DeserializeObject<Models.Login.LoginResponseContent>(response.Content);

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
