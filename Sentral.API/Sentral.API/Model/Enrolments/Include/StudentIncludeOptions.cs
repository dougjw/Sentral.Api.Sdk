using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class StudentIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        public StudentIncludeOptions(
                  bool primaryEnrolment = false, bool person = false, 
                  bool activities = false, bool activityInstances = false, 
                  bool tenants = false, bool flags = false, bool flagLinks = false, 
                  bool contacts = false, bool holidays = false, 
                  bool specialNeedsPrograms = false, bool schoolHistory = false
            ) : base(GetIncludeOptionList(
                     primaryEnrolment, person, activities, activityInstances, tenants, flags, 
                     flagLinks, contacts, holidays, specialNeedsPrograms, schoolHistory
                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                  bool primaryEnrolment = false, bool person = false,
                  bool activities = false, bool activityInstances = false,
                  bool tenants = false, bool flags = false, bool flagLinks = false,
                  bool contacts = false, bool holidays = false,
                  bool specialNeedsPrograms = false, bool schoolHistory = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (person)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Person);
            }

            if (primaryEnrolment)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.PrimaryEnrolment);
            }
            if (activities)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Activities);
            }
            if (activityInstances)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.ActivityInstances);
            }
            if (tenants)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Tenants);
            }
            if (flags)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Flags);
            }
            if (flagLinks)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.FlagLinks);
            }
            if (contacts)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Contacts);
            }
            if (holidays)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Holidays);
            }
            if (specialNeedsPrograms)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.SpecialNeedsPrograms);
            }
            if (schoolHistory)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.SchoolHistory);
            }
            return inclOptions.ToArray();
        }
    }
}
