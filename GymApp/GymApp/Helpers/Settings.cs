using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static bool IsLoged
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLoged), false);

            set => AppSettings.AddOrUpdateValue(nameof(IsLoged), value);
        }

        public static int PersonaID
        {
            get => AppSettings.GetValueOrDefault(nameof(PersonaID), 0);

            set => AppSettings.AddOrUpdateValue(nameof(PersonaID), value);
        }
        public static int RoleID
        {
            get => AppSettings.GetValueOrDefault(nameof(roleID), 0);

            set => AppSettings.AddOrUpdateValue(nameof(roleID), value);
        }
    }
}
