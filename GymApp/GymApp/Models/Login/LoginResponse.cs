﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Login
{
    public class LoginResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public LoginResponseContent Content { get; set; }

    }
}
