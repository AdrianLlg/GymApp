using GymApp.Models.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GymApp.Models.Membresias
{
    public class MembresiaResponse
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public ObservableCollection<MembresiaContent> content { get; set; }
    }
}
