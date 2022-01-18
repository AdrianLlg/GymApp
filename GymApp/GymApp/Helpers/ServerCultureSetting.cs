using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GymApp.Helpers
{
    public class ServerCultureSetting
    { 
        public CultureInfo SetCultureInfoServer()
        {
            CultureInfo culture = new CultureInfo("en-US", false);

            return culture;
        }
    }
}
