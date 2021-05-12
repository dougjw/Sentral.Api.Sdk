using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class PersonContactDetail
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "educationLevel")]
        public string EducationLevel { get; set; }

        [JsonProperty(propertyName: "tertiaryEducationLevel")]
        public string TertiaryEducationLevel { get; set; }

        [JsonProperty(propertyName: "occupation")]
        public string Occupation { get; set; }

        [JsonProperty(propertyName: "employer")]
        public string Employer { get; set; }

        [JsonProperty(propertyName: "employmentType")]
        public string EmploymentType { get; set; }

        [JsonProperty(propertyName: "workplaceLocation")]
        public string WorkplaceLocation { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }


        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }
    }
}
