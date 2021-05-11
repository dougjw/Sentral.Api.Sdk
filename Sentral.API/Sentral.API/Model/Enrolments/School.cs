using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class School
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "schoolCode")]
        public string SchoolCode { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }



        [JsonProperty(propertyName: "tenant")]
        public Relationship<Tenant> Tenant { get; set; }

    }
}
