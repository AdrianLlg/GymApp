using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.SolicitudMembresia
{
    public class SolicitudMembresiaResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool Content { get; set; }
    }
}
