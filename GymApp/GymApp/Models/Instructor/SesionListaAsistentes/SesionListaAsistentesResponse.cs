using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Instructor.SesionListaAsistentes
{
    public class SesionListaAsistentesResponse
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public List<SesionListaAsistentesContent> ContentIndex { get; set; }
    }
}
