using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class StudentFlagLinkIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        //student, house, rollclass, classes, campus
        public StudentFlagLinkIncludeOptions(
                bool student = false, bool flag = false

            ) : base(GetIncludeOptionList(
                    student, flag
                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool student = false, bool flag = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (student)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Student);
            }

            if (flag)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Flag);
            }
            return inclOptions.ToArray();
        }
    }
}
