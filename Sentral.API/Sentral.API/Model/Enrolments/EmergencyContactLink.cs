using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class EmergencyContactLink
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "phone")]
        public string Phone { get; set; }

        [JsonProperty(propertyName: "altPhone")]
        public string AltPhone { get; set; }

        [JsonProperty(propertyName: "address")]
        public string Address { get; set; }

        [JsonProperty(propertyName: "relationship")]
        public string Relationship { get; set; }

        [JsonProperty(propertyName:"person")]
        public Relationship<Person> Person { get; set; }


    }

}
