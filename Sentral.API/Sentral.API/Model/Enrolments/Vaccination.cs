using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Vaccination
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "dateOfVaccination")]
        public DateTime? DateOfVaccination { get; set; }

        [JsonProperty(propertyName: "comment")]
        public string Comment { get; set; }


        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

    }
}
