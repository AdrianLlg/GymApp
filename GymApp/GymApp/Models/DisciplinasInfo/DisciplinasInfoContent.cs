using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.DisciplinasInfo
{
    public class DisciplinasInfoContent
    {
        public int DisciplinaID { get; set; }
        public string NombreDisciplina { get; set; }
        public string DescripcionDisciplina { get; set; }
        public List<ClaseDisciplina> clases { get; set; }
    }
}
