using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Ability
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "level")]
        public string Level { get; set; }

        [JsonProperty(propertyName:"details")]
        public string Details { get; set; }

        [JsonProperty(propertyName:"isActive")]
        public bool IsActive { get; set; }
    }
}
