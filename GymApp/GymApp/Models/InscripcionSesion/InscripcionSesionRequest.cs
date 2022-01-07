using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.InscripcionSesion
{
    public class InscripcionSesionRequest
    {
        public int eventoID { get; set; }
        public int personaID { get; set; }
        public string estado { get; set; }
        public int recursoAsignado { get; set; }
        public bool recursosEvento { get; set; }
    }
}
