using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Login
{
    public class LoginResponse
    {
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
        public LoginResponseContent content { get; set; }

    }
}
