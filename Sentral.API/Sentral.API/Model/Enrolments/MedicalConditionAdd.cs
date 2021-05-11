using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class MedicalConditionAdd : AbstractMedicalCondition
    {
        public string AllergyName { get; set; }
        public string Severity { get; set; }
        public bool IsPrescribedAntihistamine { get; set; }
        public bool IsPrescribedEpiPen { get; set; }
        public bool HasEpiPenRegistered { get; set; }
    }
}
