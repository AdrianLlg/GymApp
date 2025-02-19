﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.FichaPersonal
{
    public class FichaPersonalContent
    {
        public int fichaPersonaID { get; set; }
        public string Cliente { get; set; }
        public int PersonaID { get; set; }
        public string MesoTipo { get; set; }
        public string NivelActualActividadFisica { get; set; }
        public string AntecendesMedicos { get; set; }
        public string Alergias { get; set; }
        public string Enfermedades { get; set; }
    }
}
