using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.Enrolments.Update;

namespace Sentral.API.Model.Enrolments
{
    public class Person : IToUpdatable<UpdatePerson>
    {
        public int ID { get; set; }

        public string ContactCode { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string MiddleNames { get; set; }
        public string LastName { get; set; }

        public string LegalLastName { get; set; }

        public string PreferredName { get; set; }

        public string GenderCode { get; set; }

        [JsonProperty(propertyName: "crn")]
        public string CRN { get; set; }

        public string LanguageSpokenAtHomeCode { get; set; }

        public string ExternalId { get; set; }

        public string RefID { get; set; }
        
        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string LanguageSpokenAtHome { get; set; }
   
        public string CountryOfCitizenship { get; set; }

        public string Religion { get; set; }

        public string ResidentialStatus { get; set; }

        public bool IsDeceased { get; set; }

        public SentralDateTime CreatedAt { get; set; }

        public SentralDateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        /*
         * Extended Related Data
         */ 
        
        public List<PersonEmail> Emails { get; set; }

        public List<PersonPhone> PhoneNumbers { get; set; }

        public Household PrimaryHousehold { get; set; }

        public List<Household> OtherHouseholds { get; set; }

        public Enrolment StudentPrimaryEnrolment { get; set; }

        public Staff Staff { get; set; }

        public Student Student { get; set; }

        public PersonContactDetail ContactDetails { get; set; }

        public StudentPersonRelationship StudentContacts { get; set; }

        public PrescribedMedication prescribedMedication { get; set; }

        public Tenant StudentTenants { get; set; }

        public List<Consent> GivenConsents { get; set; }

        public List<ConsentLink> GivenConsentLinks { get; set; }

        public List<Ability> Abilities { get; set; }
        public List<EmergencyContactLink> EmergencyContactLinks { get; set; }

        public List<PersonFieldValue> AdditionalFields { get; set; }

        public UpdatePerson ToUpdatable()
        {
            return new UpdatePerson(ID)
            {
                ContactCode = ContactCode,
                Title = Title,
                FirstName = FirstName,
                MiddleNames = MiddleNames,
                LastName = LastName,
                LegalLastName = LegalLastName,
                PreferredName = PreferredName,
                GenderCode = GenderCode,
                CRN = CRN,
                LanguageSpokenAtHomeCode = LanguageSpokenAtHomeCode,
            };
        }
    }
}
