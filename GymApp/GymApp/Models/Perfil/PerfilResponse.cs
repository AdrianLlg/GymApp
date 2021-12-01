using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Perfil
{
    public class PerfilResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public PerfilResponseContent contentIndex { get; set; }
    }
}
