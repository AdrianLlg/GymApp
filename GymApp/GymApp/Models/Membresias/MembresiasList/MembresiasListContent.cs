using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Membresias.MembresiasList
{
    public class MembresiasListContent
    {
        public int MembresiaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Periodicidad { get; set; }

        public List<MembresiasListDisciplines> membresiaDisciplinas { get; set; }
    }
}
