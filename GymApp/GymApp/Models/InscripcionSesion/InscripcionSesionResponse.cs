using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.InscripcionSesion
{
    public class InscripcionSesionResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool Content { get; set; }
    }
}
