using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.SolicitudMembresia
{
    public class SolicitudMembresiaRequest
    {
        public int personaID { get; set; }

        public int membresiaID { get; set; }
        public string imagen { get; set; }
    }
}
