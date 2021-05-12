using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class MedicalConditionsIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        public MedicalConditionsIncludeOptions(
                bool person = false

            ) : base(GetIncludeOptionList(
                    person

                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool person = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (person)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Person);
            }
            return inclOptions.ToArray();
        }
    }
}
