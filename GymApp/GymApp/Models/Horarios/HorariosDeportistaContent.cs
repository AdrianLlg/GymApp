using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Horarios
{
    public class HorariosDeportistaContent
    {
        public int eventoID { get; set; }
        public string disciplina { get; set; }
        public string horaInicioEvento { get; set; }
        public string horaFinEvento { get; set; }
        public string fecha { get; set; }
        public string sala { get; set; }
        public int aforoMax { get; set; }
        public int aforoMin { get; set; }
        public int asistencia { get; set; }
        public string cupos { get; set; }
        public string horaFormatoString { get; set; }
        public string estadoInscripcion { get; set; }

    }
}
