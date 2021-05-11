using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class StudentContactIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        public StudentContactIncludeOptions(
                bool student = false, bool person = false, bool studentPerson = false

            ) : base(GetIncludeOptionList(
                    student, person, studentPerson

                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool student = false, bool person = false, bool studentPerson = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (student)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Student);
            }

            if (person)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Person);
            }
            if (studentPerson)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.StudentPerson);
            }
            return inclOptions.ToArray();
        }
    }
}
