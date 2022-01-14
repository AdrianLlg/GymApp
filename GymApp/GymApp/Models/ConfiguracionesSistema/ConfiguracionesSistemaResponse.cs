using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.ConfiguracionesSistema
{
    public class ConfiguracionesSistemaResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<ConfiguracionesSistemaContent> ContentParametro { get; set; }
    }
}
