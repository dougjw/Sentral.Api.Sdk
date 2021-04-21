using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class PersonEmail
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string TypeName { get; set; }
        public bool CanContact { get; set; }
    }
}
