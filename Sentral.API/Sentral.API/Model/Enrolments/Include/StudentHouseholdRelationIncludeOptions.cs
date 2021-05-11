using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class StudentHouseholdRelationIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        //student, house, rollclass, classes, campus
        public StudentHouseholdRelationIncludeOptions(
                bool student = false, bool household = false

            ) : base(GetIncludeOptionList(
                    student, household
                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool student, bool household
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (student)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Person);
            }
            if (household)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Household);
            }


            return inclOptions.ToArray();
        }
    }
}
