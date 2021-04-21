using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Sentral.API.Model.Common
{
    public class APILinks
    {
        [JsonProperty(propertyName: "first")]
        public string First { get; set; }

        [JsonProperty(propertyName: "prev")]
        public string Prev { get; set; }

        [JsonProperty(propertyName: "next")]
        public string Next { get; set; }

        [JsonProperty(propertyName: "last")]
        public string Last { get; set; }
    }
}
