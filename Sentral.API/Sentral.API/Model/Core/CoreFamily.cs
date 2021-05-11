using System;

namespace Sentral.API.Model.Core
{
    public class CoreFamily
    {
        public int ID { get; set; }
        public string AddressTitle { get; set; }
        public string AddressPoBox { get; set; }
        public string AddressStreetNo { get; set; }
        public string AddressStreet { get; set; }
        public string AddressSuburb { get; set; }
        public string AddressState { get; set; }
        public string AddressPostCode { get; set; }
        public bool IsOutOfArea { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string Contact1Title { get; set; }
        public string Contact1Gender { get; set; }
        public string Contact1Surname { get; set; }
        public string Contact1GivenNames { get; set; }
        public string Contact1HomePhone { get; set; }
        public string Contact1WorkPhone { get; set; }
        public string Contact1Mobile { get; set; }
        public string Contact1Email { get; set; }
        public string Contact1Occupation { get; set; }
        public string Contact1OccupationGroup { get; set; }
        public string Contact1CountryOfBirth { get; set; }
        public string Contact1Nationality { get; set; }
        public string Contact1LanguageHome { get; set; }
        public string Contact1LanguageOther1 { get; set; }
        public string Contact1LanguageOther2 { get; set; }
        public bool Contact1InterpreterRequired { get; set; }
        public string Contact1SchoolEducation { get; set; }
        public string Contact1NonschoolEducation { get; set; }
        public string Contact2Title { get; set; }
        public string Contact2Gender { get; set; }
        public string Contact2Surname { get; set; }
        public string Contact2GivenNames { get; set; }
        public string Contact2HomePhone { get; set; }
        public string Contact2WorkPhone { get; set; }
        public string Contact2Mobile { get; set; }
        public string Contact2Email { get; set; }
        public string Contact2Occupation { get; set; }
        public string Contact2OccupationGroup { get; set; }
        public string Contact2CountryOfBirth { get; set; }
        public string Contact2Nationality { get; set; }
        public string Contact2LanguageHome { get; set; }
        public string Contact2LanguageOther1 { get; set; }
        public string Contact2LanguageOther2 { get; set; }
        public bool Contact2InterpreterRequired { get; set; }
        public string Contact2SchoolEducation { get; set; }
        public string Contact2NonschoolEducation { get; set; }
        public string EmergencyContact1Name { get; set; }
        public string EmergencyContact1Phone { get; set; }
        public string EmergencyContact1Mobile { get; set; }
        public string EmergencyContact1Email { get; set; }
        public string EmergencyContact1Relationship { get; set; }
        public string EmergencyContact2Name { get; set; }
        public string EmergencyContact2Phone { get; set; }
        public string EmergencyContact2Mobile { get; set; }
        public string EmergencyContact2Email { get; set; }
        public string EmergencyContact2Relationship { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }
        public Guid RefId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}