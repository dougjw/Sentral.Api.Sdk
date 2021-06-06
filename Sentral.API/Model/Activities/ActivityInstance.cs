using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Activities
{
    public class ActivityInstance
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Status { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public SentralTime StartTime { get; set; }

        public SentralTime EndTime { get; set; }

        public bool IsPublishedToPortal { get; set; }
        public bool IsPaymentRequired { get; set; }
        public bool IsPermissionRequired { get; set; }
        public bool IsActive { get; set; }

        public Relationship<Activity> Activity { get; set; }

        public Relationship<List<Roll>> Rolls { get; set; }
    }
}