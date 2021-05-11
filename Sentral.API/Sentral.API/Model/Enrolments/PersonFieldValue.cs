using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class PersonFieldValue
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "value")]
        public string Value { get; set; }



        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

        [JsonProperty(propertyName: "field")]
        public Relationship<PersonField> Field { get; set; }
    }
}
