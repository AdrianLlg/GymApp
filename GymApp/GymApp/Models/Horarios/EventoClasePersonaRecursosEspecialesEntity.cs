using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Horarios
{
    public class EventoClasePersonaRecursosEspecialesEntity
    {
        public int eventoRecursoID { get; set; }
        public int eventoID { get; set; }
        public int recursoEspecialID { get; set; }
        public string nombreRecurso { get; set; }
        public string descripcionRecurso { get; set; }
        public int? personaID { get; set; }

    }
}
