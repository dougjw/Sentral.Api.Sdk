using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Doctor
    {
        [JsonProperty(propertyName:"id")]
        public int ID { get; set; }

        [JsonProperty(propertyName:"name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "practiceName")]
        public string PracticeName { get; set; }

        [JsonProperty(propertyName: "address")]
        public string Address { get; set; }

        [JsonProperty(propertyName: "phone")]
        public string Phone { get; set; }

        [JsonProperty(propertyName: "consentToContact")]
        public bool ConsentToContact { get; set; }

        [JsonProperty(propertyName:"patient")]
        public Relationship<Person> Patient { get; set; }


    }
}
