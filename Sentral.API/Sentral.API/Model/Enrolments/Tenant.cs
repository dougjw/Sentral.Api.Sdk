using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class Tenant
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "code")]
        public string Code { get; set; }

        [JsonProperty(propertyName: "region")]
        public string Region { get; set; }

        [JsonProperty(propertyName: "key")]
        public string Key { get; set; }

        [JsonProperty(propertyName: "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }


    }
}
