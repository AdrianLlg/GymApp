using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Instructor.RegistroFichaPersona
{
    public class RegistroFichaPersonaResponse
    {
        
        public int ResponseCode { get; set; }
        
        public string ResponseMessage { get; set; }

        public bool ContentCreate { get; set; }
    }
}
