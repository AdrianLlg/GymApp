using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GymApp.Models.SesionesAgendadas
{
    public class SesionesAgendadasResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public ObservableCollection<SesionesAgendadasContent> Content { get; set; }


    }
}
