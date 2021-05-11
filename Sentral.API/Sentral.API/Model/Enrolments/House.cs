using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class House
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }


        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "sequence")]
        public int Sequence { get; set; }
    }
}
