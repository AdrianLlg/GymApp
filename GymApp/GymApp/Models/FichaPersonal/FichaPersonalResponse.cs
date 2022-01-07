using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.FichaPersonal
{
    public class FichaPersonalResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public FichaPersonalContent ContentIndex { get; set; }
    }
}
