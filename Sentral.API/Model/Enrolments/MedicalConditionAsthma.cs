using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class MedicalConditionAsthma : AbstractMedicalCondition
    {
        public string Severity { get; set; }
        public string Dosage { get; set; }
        public string Type { get; set; }
        
        public bool IsPrescribedSalbutamol { get; set; }
    }
}
