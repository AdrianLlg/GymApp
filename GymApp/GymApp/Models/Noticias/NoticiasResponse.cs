using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Noticias
{
    public class NoticiasResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public int count { get; set; }
        public List<NoticiasContent> ContentIndex { get; set; }
    }
}
