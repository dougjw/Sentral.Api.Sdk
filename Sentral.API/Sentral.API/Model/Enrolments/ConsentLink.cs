using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class ConsentLink
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "consentDate")]
        public DateTime? ConsentDate { get; set; }

        [JsonProperty(propertyName: "consentGiven")]
        public string ConsentGiven { get; set; }


        [JsonProperty(propertyName: "createdAt")]
        public SentralDateTime CreatedAt { get; set; }

        [JsonProperty(propertyName: "updatedAt")]
        public SentralDateTime UpdatedAt { get; set; }

        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

        [JsonProperty(propertyName: "consent")]
        public Relationship<Consent> Consent { get; set; }
    }
}
