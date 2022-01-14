using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.ConfiguracionesSistema
{
    public class ConfiguracionesSistemaContent
    {
        public int ConfiguracionSistemaID { get; set; }
        public string TipoConfiguracion { get; set; }
        public string NombreConfiguracion { get; set; }
        public string DescripcionConfiguracion { get; set; }
        public string Estado { get; set; }
        public string Valor { get; set; }

    }
}
