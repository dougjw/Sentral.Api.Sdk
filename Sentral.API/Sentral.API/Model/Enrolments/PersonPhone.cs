using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class PersonPhone
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "number")]
        public string Number { get; set; }

        [JsonProperty(propertyName: "extension")]
        public string Extension { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "typeName")]
        public string TypeName { get; set; }

        [JsonProperty(propertyName: "isListed")]
        public bool IsListed { get; set; }

        [JsonProperty(propertyName: "canContact")]
        public bool CanContact { get; set; }
    }
}
