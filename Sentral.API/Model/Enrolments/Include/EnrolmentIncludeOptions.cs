using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class EnrolmentIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        //student, house, rollclass, classes, campus
        public EnrolmentIncludeOptions(
                bool student = false, bool house = false, bool rollclass = false,
                bool classes = false, bool campus = false

            ) : base(GetIncludeOptionList(
                    student, house, rollclass, classes, campus

                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool student = false, bool house = false, bool rollclass = false,
                bool classes = false, bool campus = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (student)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Student);
            }

            if (house)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.House);
            }
            if (rollclass)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Rollclass);
            }
            if (classes)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Classes);
            }
            if (campus)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Campus);
            }
            return inclOptions.ToArray();
        }
    }
}
