using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class MedicalConditionAllergy : AbstractMedicalCondition
    {
        public bool IsInattentive { get; set; }
        public bool IsHyperactive { get; set; }
        public bool IsMedicationRequired { get; set; }
        public bool IsDoctorsLetterProvided { get; set; }
    }
}
