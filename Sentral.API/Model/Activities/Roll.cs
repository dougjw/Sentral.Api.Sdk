using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Activities
{
    public class Roll
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime? RollDate { get; set; }

        [JsonProperty(propertyName: "isSubmitted")]
        public DateTime? SubmittedDate { get; set; }

        public bool IsRollSubmitted()
        {
            return SubmittedDate.HasValue && SubmittedDate.Value > DateTime.MinValue;
        }

        public Relationship<ActivityInstance> ActivityInstance { get; set; }
    }
}