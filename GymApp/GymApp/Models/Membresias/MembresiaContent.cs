using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Membresias
{
    public class MembresiaContent
    {

        public int membresia_persona_pagoID { get; set; }
        public int membresiaID { get; set; }
        public string nombreMembresia { get; set; }
        public decimal precioMembresia { get; set; }
        public string periodicidadMembresia { get; set; }
        public string fechaInicioMembresia { get; set; }
        public string fechaFinMembresia { get; set; }
        public string formaPago { get; set; }
        public string nroDocumento { get; set; }
        public string Banco { get; set; }
        public string fechaPago { get; set; }
        public string fechaLimite { get; set; }
        public string estado { get; set; }

        public DateTime fechaInicioMembresiaDate { get; set; }
        public DateTime fechaFinMembresiaDate { get; set; }
        public DateTime fechaPagoMembresiaDate { get; set; }
        public List<DisciplinasMembresiasPersona> disciplinasMemb { get; set; }
    }
}
