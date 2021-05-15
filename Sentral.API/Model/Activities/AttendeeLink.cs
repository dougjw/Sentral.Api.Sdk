using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Activities
{
    public class AttendeeLink
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string AttendeeType { get; set; }

        public string ShowInReports { get; set; }

        public int? Points { get; set; }
        public string PermissionGiven { get; set; }

        public bool? Paid { get; set; }

        public decimal? PaidAmount { get; set; }

        public Relationship<Enrolments.Student> Student { get; set; }

        public Relationship<ActivityInstance> ActivityInstance { get; set; }
    }
}