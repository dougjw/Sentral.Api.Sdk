using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JsonApiSerializer.JsonApi;

namespace Sentral.API.Model.Enrolments
{
    public class PersonEmail
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "email")]
        public string Email { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "typeName")]
        public string TypeName { get; set; }

        [JsonProperty(propertyName: "canContact")]
        public bool CanContact { get; set; }

        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }
    }
}
