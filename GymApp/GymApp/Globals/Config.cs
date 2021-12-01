using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Globals
{
    public class Config
    {
        public static string BaseUrl = "http://4e21-186-69-101-83.ngrok.io";
        public static string ApiLogin = $"{BaseUrl}/api/Login";
        public static string ApiRegistro = $"{BaseUrl}/api/Registro";
        public static string ApiMembresias = $"{BaseUrl}/api/MembresiasUsuario";
        public static string ApiInformacionPerfil = $"{BaseUrl}/api/ConsultaPerfil";
    }
}
