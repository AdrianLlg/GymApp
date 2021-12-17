using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Globals
{
    public class Config
    {
        public static string BaseUrl = "http://1e6d-186-69-101-83.ngrok.io";
        public static string ApiLogin = $"{BaseUrl}/api/Login";
        public static string ApiRegistro = $"{BaseUrl}/api/CRUDRegistroAdmin";
        public static string ApiMembresias = $"{BaseUrl}/api/MembresiasUsuario";
        public static string ApiInformacionPerfil = $"{BaseUrl}/api/ConsultaPerfil";
        public static string ApiConsultaHorariosDeportista = $"{BaseUrl}/api/ConsultaHorariosDeportista";
        public static string ApiInscripcionUsuarioSesion = $"{BaseUrl}/api/InscripcionUsuarioSesion";
    }
}
