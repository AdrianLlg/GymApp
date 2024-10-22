﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Globals
{
    public class Config
    {
        public static string BaseUrl = "http://c6c7-190-130-226-20.ngrok.io";
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
        public static string ApiConsultaListaAsistencia = $"{BaseUrl}/api/ConsultaListaAsistencia";
        public static string ApiGenerarQRInstructor = $"{BaseUrl}/api/GenerarQRInstructor";
        public static string ApiGenerarCancelarEventoApp = $"{BaseUrl}/api/CancelarEventoApp";      
        public static string ApiRegistrarAsistenciaManual = $"{BaseUrl}/api/RegistrarAsistenciaManual"; 
        public static string ApiCrearFichaPersona = $"{BaseUrl}/api/FichaPersona";
        public static string ApiCrearFichaEntrenamiento = $"{BaseUrl}/api/FichaEntrenamiento";
        public static string ApiMembresiaAdmin = $"{BaseUrl}/api/CRUDMembresiaAdmin";
        public static string ApiRegistrarAsistenciaEventoPersona = $"{BaseUrl}/api/RegistrarAsistenciaEventoPersona";
        public static string ApiConfiguracionesSistema = $"{BaseUrl}/api/ConfiguracionesSistema";
        public static string ApiRegistrarAsistenciaEventoProfesor = $"{BaseUrl}/api/RegistrarAsistenciaEventoProfesor";
        
    }
}
