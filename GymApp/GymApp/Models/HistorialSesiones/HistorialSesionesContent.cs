using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.HistorialSesiones
{
    public class HistorialSesionesContent
    {
        public string Cliente { get; set; }
        public string Clase { get; set; } 
        public string Disciplina { get; set; }
        public string Profesor { get; set; }
        public string Horario { get; set; }
        public string Fecha { get; set; }
        public string Sala { get; set; } 
        public string Asistencia { get; set; }
        public string Estado { get; set; }

        public string estadoText { get; set; }
        public string fechaFormato { get; set; }
    }
}
