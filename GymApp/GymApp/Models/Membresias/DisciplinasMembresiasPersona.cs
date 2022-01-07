using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Membresias
{
    public class DisciplinasMembresiasPersona
    {
        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public int numClases { get; set; }
        public int numClasesTomadas { get; set; }
    }
}
