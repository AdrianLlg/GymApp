using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Globals
{
    public class Config
    {
        public static string BaseUrl = "http://21a3-186-69-101-83.ngrok.io";
        public static string ApiLogin = $"{BaseUrl}/api/Login";
        public static string ApiRegistro = $"{BaseUrl}/api/CRUDRegistroAdmin";
        public static string ApiMembresias = $"{BaseUrl}/api/MembresiasUsuario";
        public static string ApiInformacionPerfil = $"{BaseUrl}/api/ConsultaPerfil";
        public static string ApiConsultaHorariosDeportista = $"{BaseUrl}/api/ConsultaHorariosDeportista";
        public static string ApiInscripcionUsuarioSesion = $"{BaseUrl}/api/InscripcionUsuarioSesion";
        public static string ApiSesionesAgendadas = $"{BaseUrl}/api/EventoClasePersona";
        public static string ApiRenovacionMembresiaUsuario = $"{BaseUrl}/api/RenovacionMembresiaUsuario";
        public static string ApiConsultaFichaPersona = $"{BaseUrl}/api/ConsultaFichaPersona";
        public static string ApiConsultaFichaEntrenamiento = $"{BaseUrl}/api/ConsultaFichaEntrenamiento";
        public static string ApiConsultaNoticias = $"{BaseUrl}/api/ConsultaNoticias";
        public static string ApiConsultaHistorialAsistenciaCliente = $"{BaseUrl}/api/ConsultaHistorialAsistenciaCliente";
        public static string ApiConsultaDisciplinasDeportista = $"{BaseUrl}/api/ConsultaDisciplinasDeportista";
        public static string ApiConsultaClasesPendientesInstructor = $"{BaseUrl}/api/ConsultaClasesPendientesInstructor";

    }
}
