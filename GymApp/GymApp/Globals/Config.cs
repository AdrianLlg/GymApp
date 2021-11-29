using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Globals
{
    public class Config
    {
        public static string BaseUrl = "https://5e5e-190-130-226-20.ngrok.io";
        public static string ApiLogin = $"{BaseUrl}/api/Login";
        public static string ApiRegistro = $"{BaseUrl}/api/Registro";
        public static string ApiMembresias = $"{BaseUrl}/api/MembresiasUsuario";
    }
}
