using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.RegistroPersona
{
    public class RegistroPersonaResponse
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public bool contentCreate { get; set; }

    }
}
