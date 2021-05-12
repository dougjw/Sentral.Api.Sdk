using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class PersonIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        public PersonIncludeOptions(
                bool primaryHousehold = false, bool studentPrimaryEnrolment = false, bool staff = false, bool student = false,
                bool contactDetails = false, bool otherHouseholds = false, bool studentContacts = false, 
                bool studentTenants = false, bool prescribedMedication = false, bool emails = false, bool phoneNumbers = false, 
                bool givenConsents = false, bool givenConsentLinks = false, bool emergencyContactLinks = false, 
                bool abilities = false, bool additionalFields = false
            ) : base(GetIncludeOptionList(
                    primaryHousehold, studentPrimaryEnrolment, staff, student,
                    contactDetails, otherHouseholds, studentContacts,
                    studentTenants, prescribedMedication, emails, phoneNumbers,
                    givenConsents, givenConsentLinks, emergencyContactLinks,
                    abilities, additionalFields
                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool primaryHousehold, bool studentPrimaryEnrolment, bool staff, bool student,
                bool contactDetails, bool otherHouseholds, bool studentContacts,
                bool studentTenants, bool prescribedMedication, bool emails, bool phoneNumbers,
                bool givenConsents, bool givenConsentLinks, bool emergencyContactLinks,
                bool abilities, bool additionalFields
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (primaryHousehold)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.PrimaryHousehold);
            }

            if (studentPrimaryEnrolment)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.StudentPrimaryEnrolment);
            }
            if (staff)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Staff);
            }
            if (student)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Student);
            }
            if (contactDetails)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.ContactDetails);
            }
            if (otherHouseholds)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.OtherHouseholds);
            }
            if (studentContacts)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.StudentContacts);
            }
            if (studentTenants)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.StudentTenants);
            }
            if (prescribedMedication)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.PrescribedMedication);
            }
            if (emails)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Emails);
            }
            if (phoneNumbers)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.PhoneNumbers);
            }
            if (givenConsents)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.GivenConsents);
            }
            if (givenConsentLinks)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.GivenConsentLinks);
            }
            if (emergencyContactLinks)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.EmergencyContactLinks);
            }
            if (abilities)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Abilities);
            }
            if (additionalFields)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.AdditionalFields);
            }
            return inclOptions.ToArray();
        }
    }
}
