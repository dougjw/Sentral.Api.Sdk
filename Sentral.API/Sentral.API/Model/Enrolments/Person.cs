using System;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class Person : PersonUpdate
    {

        [JsonProperty(propertyName: "externalId")]
        public string ExternalId { get; set; }

        [JsonProperty(propertyName: "refId")]
        public string RefID { get; set; }
        
        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "gender")]
        public string Gender { get; set; }


        [JsonProperty(propertyName: "dateOfBirth")]
        public DateTime? DateOfBirth { get; set; }


        [JsonProperty(propertyName: "languageSpokenAtHome")]
        public string LanguageSpokenAtHome { get; set; }
   

        [JsonProperty(propertyName: "CountryOfCitizenship")]
        public string CountryOfCitizenship { get; set; }

        [JsonProperty(propertyName: "religion")]
        public string Religion { get; set; }

        [JsonProperty(propertyName: "residentialStatus")]
        public string ResidentialStatus { get; set; }

        [JsonProperty(propertyName: "isDeceased")]
        public bool IsDeceased { get; set; }

        [JsonProperty(propertyName: "createdAt")]
        public SentralDateTime CreatedAt { get; set; }

        [JsonProperty(propertyName: "updatedAt")]
        public SentralDateTime UpdatedAt { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }

        public Relationship<PersonEmail>[] Emails { get; set; }
    }
}
