using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Common
{
    public class SentralDateTime
    {
        [JsonProperty(propertyName:"timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty(propertyName: "iso8601")]
        public DateTime Iso8601 { get; set; }
    }
}
