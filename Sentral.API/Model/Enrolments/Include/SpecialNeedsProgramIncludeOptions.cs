using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class SpecialNeedsProgramIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        //student, house, rollclass, classes, campus
        public SpecialNeedsProgramIncludeOptions(
                bool students = false

            ) : base(GetIncludeOptionList(
                    students
                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool students = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (students)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Students);
            }

            return inclOptions.ToArray();
        }
    }
}
