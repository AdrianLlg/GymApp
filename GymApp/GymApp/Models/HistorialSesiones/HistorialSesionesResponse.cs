using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.HistorialSesiones
{
    public class HistorialSesionesResponse
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public List<HistorialSesionesContent> Content { get; set; }
    }
}
