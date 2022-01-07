using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.SesionesAgendadas
{
    public class SesionesAgendadasContent
    {
        public int EventoID { get; set; }
        public string Disciplina { get; set; }
        public string Sala { get; set; }
        public string NombreInstructor { get; set; }
        public string Descripcion { get; set; }
        public string fecha { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public int Asistentes { get; set; }
        public int AforoMaximoClase { get; set; }
        public int AforoMinimoClase { get; set; }
        public string recursoEspecial { get; set; }
        public string horaFormatoString {get; set;}
        public string cupos { get; set; }
        public bool recursoAsignado { get; set; }
        public string nombreRecurso { get; set; }
        public string descripcionRecurso { get; set; }

        public DateTime fechaSesion { get; set; }
        public string formatoFechaSesion { get; set; }
    }
}
