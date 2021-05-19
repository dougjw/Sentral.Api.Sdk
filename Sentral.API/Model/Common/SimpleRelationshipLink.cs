using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Common
{
    public class SimpleRelationshipLink
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Type { get; set; }
    }
}
