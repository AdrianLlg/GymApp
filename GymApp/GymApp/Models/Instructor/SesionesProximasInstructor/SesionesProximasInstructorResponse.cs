using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.Instructor.SesionesProximasInstructor
{
    public class SesionesProximasInstructorResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<SesionesProximasInstructorContent> ContentIndex { get; set; }
    }
}
