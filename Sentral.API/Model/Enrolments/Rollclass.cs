using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class Rollclass
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "pastoralCare")]
        public bool PastoralCare { get; set; }

        [JsonProperty(propertyName:"refId")]
        public Guid RefIf { get; set; }

        [JsonProperty(propertyName: "createdAt")]
        public SentralDateTime CreatedAt { get; set; }

        [JsonProperty(propertyName: "updatedAt")]
        public SentralDateTime UpdatedAt { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }


        // Related Records
        [JsonProperty(propertyName: "teacher")]
        public Relationship<Staff> Teacher { get; set; }


        [JsonProperty(propertyName: "school")]
        public Relationship<School> School { get; set; }
    }
}
