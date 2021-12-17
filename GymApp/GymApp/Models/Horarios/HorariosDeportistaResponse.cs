using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GymApp.Models.Horarios
{
    public class HorariosDeportistaResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public ObservableCollection<HorariosDeportistaContent> Content { get; set; }
    }
}
