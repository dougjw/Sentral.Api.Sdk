using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class YearLevel
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "code")]
        public string Code { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }


        [JsonProperty(propertyName: "school")]
        public Relationship<School> School { get; set; }

    }
}
