using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class MedicalConditionDiabetes : AbstractMedicalCondition
    {
        public bool HasInsulinInjections { get; set; }
        public bool HasInsulinPump { get; set; }
        public bool HasGlucagon { get; set; }
    }
}
