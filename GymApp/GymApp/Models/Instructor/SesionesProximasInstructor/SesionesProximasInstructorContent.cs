﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Instructor.SesionesProximasInstructor
{
    public class SesionesProximasInstructorContent
    {
        public int eventoID { get; set; }
        public string fecha { get; set; }
        public string fechaFormato { get; set; }
        public int horarioMID { get; set; }
        public string horario { get; set; }
        public int claseID { get; set; }
        public string nombreClase { get; set; }
        public int disciplinaID { get; set; }
        public string nombreDisciplina { get; set; }
        public int salaID { get; set; }
        public string nombreSala { get; set; }
        public int aforoMax { get; set; }
        public int aforoMin { get; set; }
        public int personaID { get; set; }
        public string estadoRegistro { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public DateTime fechaInicioFormatoDateTime { get; set; }
        public DateTime fechaFinFormatoDateTime { get; set; }
        //agregar el numero de inscritos en el evento (int)

    }
}
