using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.DisciplinasInfo
{
    public class ClaseDisciplina
    {
        public int claseID { get; set; }
        public string NombreClase { get; set; }
        public string DescripcionClase { get; set; }

        public bool VisibleClases { get; set; }

        public bool VisibleNoClases { get; set; }
    }
}
