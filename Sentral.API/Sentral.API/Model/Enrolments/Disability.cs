using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Disability
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "details")]
        public string Details { get; set; }

        [JsonProperty(propertyName: "receivesFunding")]
        public bool ReceivesFunding { get; set; }

        [JsonProperty(propertyName: "hasCarePlanProvided")]
        public bool HasCarePlanProvided { get; set; }

        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

    }
}
