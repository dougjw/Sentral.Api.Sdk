using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public enum PersonIncludeOptions
    {
        PrimaryHousehold ,
        StudentPrimaryEnrolment,
        Staff,
        Student ,
        ContactDetails,
        OtherHouseholds,
        StudentContacts,
        StudentTenants,
        PrescribedMedication,
        Emails,
        PhoneNumbers,
        GivenConsents,
        GivenConsentLinks,
        EmergencyContactLinks,
        Abilities,
        AdditionalFields 
    }
}
