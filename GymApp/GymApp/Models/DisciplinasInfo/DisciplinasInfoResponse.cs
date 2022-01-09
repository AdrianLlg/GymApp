using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.DisciplinasInfo
{
    public class DisciplinasInfoResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<DisciplinasInfoContent> Content { get; set; }
    }
}
