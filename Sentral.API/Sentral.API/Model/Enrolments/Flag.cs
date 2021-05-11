using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Flag
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "internalName")]
        public string InternalName { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "color")]
        public string Color { get; set; }

        [JsonProperty(propertyName: "showInSentral")]
        public bool ShowInSentral { get; set; }

        [JsonProperty(propertyName: "showInFees")]
        public bool ShowInFees { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }

    }
}
