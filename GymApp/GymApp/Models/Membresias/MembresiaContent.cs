using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Membresias
{
    public class MembresiaContent
    {

        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public double precio { get; set; }
        public int numClasesDisponibles { get; set; }
        public DateTime fechaPago { get; set; }
        public DateTime fechaLimite { get; set; }
        public string nombreMembresia { get; set; }

    }
}
