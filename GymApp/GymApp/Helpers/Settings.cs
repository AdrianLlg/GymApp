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
            get => AppSettings.GetValueOrDefault(nameof(RoleID), 0);

            set => AppSettings.AddOrUpdateValue(nameof(RoleID), value);
        }

        public static string NombreCompleto
        {
            get => AppSettings.GetValueOrDefault(nameof(NombreCompleto), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(NombreCompleto), value);
        }

        public static string Celular
        {
            get => AppSettings.GetValueOrDefault(nameof(Celular), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Celular), value);
        }

        public static string Cedula
        {
            get => AppSettings.GetValueOrDefault(nameof(Cedula), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Cedula), value);
        }

        public static string Correo
        {
            get => AppSettings.GetValueOrDefault(nameof(Correo), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Correo), value);
        }

        public static string Edad
        {
            get => AppSettings.GetValueOrDefault(nameof(Edad), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Edad), value);
        }

        public static string FechaNacimiento
        {
            get => AppSettings.GetValueOrDefault(nameof(FechaNacimiento), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(FechaNacimiento), value);
        }
    }
}
