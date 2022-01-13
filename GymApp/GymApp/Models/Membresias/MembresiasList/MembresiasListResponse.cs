using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Membresias.MembresiasList
{
    public class MembresiasListResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<MembresiasListContent> ContentIndex { get; set; }


    }
}
