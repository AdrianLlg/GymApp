using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.DisciplinasInfo
{
    public class DisciplinasInfoModel: List<ClaseDisciplina>
    {
        public string NombreDisciplina { get; set; }

        public DisciplinasInfoModel(string disciplina, List<ClaseDisciplina> ObjectContent) : base(ObjectContent)
        {
            NombreDisciplina = "Disciplina: " + disciplina;

        }
    }
}
