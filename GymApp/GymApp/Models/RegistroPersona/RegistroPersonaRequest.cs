using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.RegistroPersona
{

    public class RegistroPersonaRequest
    {
        public string rolePID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string FechaNacimiento { get; set; }
        public string Password { get; set; }

    }
}
