using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Instructor.CancelarSesion
{
    public class CancelarSesionResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public bool Content { get; set; }
    }
}
