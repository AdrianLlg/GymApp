using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Instructor.CancelarSesion
{
    public class CancelarSesionRequest
    {
        public int eventoID { get; set; }
        public int personaID { get; set; }
        public string motivo { get; set; }
        public string posibleHorarioRecuperacion { get; set; }
    }
}
