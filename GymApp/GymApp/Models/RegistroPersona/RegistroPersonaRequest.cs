﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.RegistroPersona
{

    public class RegistroPersonaRequest
    {
        public int flujoID { get; set; }
        public string rolePID { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string sexo { get; set; }
        public string fechaNacimiento { get; set; }
    }
}
