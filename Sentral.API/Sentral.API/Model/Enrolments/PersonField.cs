using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class PersonField
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "valueType")]
        public string ValueType { get; set; }

        [JsonProperty(propertyName: "area")]
        public string Area { get; set; }

        [JsonProperty(propertyName: "minLength")]
        public int? MinLength { get; set; }

        [JsonProperty(propertyName: "maxLength")]
        public int? MaxLength { get; set; }


        [JsonProperty(propertyName: "school")]
        public Relationship<School> School { get; set; }
    }
}
