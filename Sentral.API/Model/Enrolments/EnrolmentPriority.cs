using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class EnrolmentPriority
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "code")]
        public string Code { get; set; }

        [JsonProperty(propertyName: "description")]
        public string Description { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }

    }
}
