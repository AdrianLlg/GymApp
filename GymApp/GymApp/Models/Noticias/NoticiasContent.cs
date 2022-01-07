using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Noticias
{
    public class NoticiasContent
    {
        public int noticiaID { get; set; }
        public string titulo { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string estadoRegistro { get; set; }

        public Xamarin.Forms.ImageSource DisplayImage { get; set; }
    }
}
