using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class StaffIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        public StaffIncludeOptions(
                bool person = false, bool qualifications = false, bool employments = false
            ) : base(GetIncludeOptionList(
                    person, qualifications, employments
                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool person = false, bool qualifications = false, bool employments = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (person)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Person);
            }

            if (qualifications)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Qualifications);
            }
            if (employments)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Employments);
            }
            return inclOptions.ToArray();
        }
    }
}
