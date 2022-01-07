using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.FichasEntrenamiento
{
    public class FichasEntrenamientoResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<FichasEntrenamientoContent> ContentIndex { get; set; }
    }
}
