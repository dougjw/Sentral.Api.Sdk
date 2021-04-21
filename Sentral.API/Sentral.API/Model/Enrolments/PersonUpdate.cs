using System;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;

namespace Sentral.API.Model.Enrolments
{
    public class PersonUpdate
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }
   
        [JsonProperty(propertyName: "contactCode")]
        public string ContactCode { get; set; }

        [JsonProperty(propertyName: "title")]
        public string Title { get; set; }
        
        [JsonProperty(propertyName: "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(propertyName: "middleNames")]
        public string MiddleNames { get; set; }

        [JsonProperty(propertyName: "lastName")]
        public string LastName { get; set; }

        [JsonProperty(propertyName: "legalLastName")]
        public string LegalLastName { get; set; }

        [JsonProperty(propertyName: "preferredName")]
        public string PreferredName { get; set; }

        [JsonProperty(propertyName: "genderCode")]
        public string GenderCode { get; set; }

        [JsonProperty(propertyName: "crn")]
        public string CRN { get; set; }
        
        [JsonProperty(propertyName: "LanguageSpokenAtHomeCode")]
        public string LanguageSpokenAtHomeCode { get; set; }
        
    }
}
