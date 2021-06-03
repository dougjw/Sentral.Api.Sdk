using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Activities
{
    public class Activity
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string ReportName { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [JsonProperty(propertyName: "startTime")]
        public SentralTime StartTime { get; set; }

        public SentralTime EndTime  { get; set;  }

        public DateTime? PermissionFormDueDate { get; set; }

        public bool IsRestrictedByTerm { get; set; }

        public bool IsRestrictedByYear { get; set; }

        public bool ShowReports { get; set; }

        public bool ShowAttendance { get; set; }

        public bool ShowPortal { get; set; }

        public bool SelfRegistration { get; set; }

        public bool ApprovalRequired { get; set; }

        public int MaximumPlaces { get; set; }

        public int? WaitingListPlaces { get; set; }

        public DateTime? Archived { get; set; }

        public bool RiskAssessment { get; set; }

        public string RegistrationType { get; set; }

        public string PortalDescription { get; set; }

        public List<int> AvailableTerms { get; set; }

        public List<int> AvailableYears { get; set; }

        public bool IsActive { get; set; }

        public Relationship<List<CycleInstance>>  Cycles { get; set; }

        public Relationship<ActivityInstance> Instances { get; set; }

    }
}