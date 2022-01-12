using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Instructor.SesionListaAsistentes
{
    public class SesionListaAsistentesContent
    {
        public int eventoPersonaID { get; set; }
        public int personaID { get; set; }
        public int asistencia { get; set; }
        public string nombre { get; set; }
        public string identificacion { get; set; }
        public bool asistenciaCheckbox { get; set; }
        public bool enableCheckBox { get; set; }
    }
}
