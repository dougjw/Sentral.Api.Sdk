using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Activities
{
    public class Activity
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "reportName")]
        public string ReportName { get; set; }

        [JsonProperty(propertyName: "description")]
        public string Description { get; set; }

        [JsonProperty(propertyName: "startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(propertyName: "endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty(propertyName: "startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty(propertyName: "endTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty(propertyName: "permissionFormDueDate")]
        public DateTime? PermissionFormDueDate { get; set; }

        [JsonProperty(propertyName: "isRestrictedByTerm")]
        public bool IsRestrictedByTerm { get; set; }

        [JsonProperty(propertyName: "isRestrictedByYear")]
        public bool IsRestrictedByYear { get; set; }

        [JsonProperty(propertyName: "showReports")]
        public bool ShowReports { get; set; }

        [JsonProperty(propertyName: "showAttendance")]
        public bool ShowAttendance { get; set; }

        [JsonProperty(propertyName: "showPortal")]
        public bool ShowPortal { get; set; }

        [JsonProperty(propertyName: "selfRegistration")]
        public bool SelfRegistration { get; set; }

        [JsonProperty(propertyName: "approvalRequired")]
        public bool ApprovalRequired { get; set; }

        [JsonProperty(propertyName: "maximumPlaces")]
        public int MaximumPlaces { get; set; }

        [JsonProperty(propertyName: "waitingListPlaces")]
        public int WaitingListPlaces { get; set; }

        [JsonProperty(propertyName: "archived")]
        public DateTime? Archived { get; set; }

        [JsonProperty(propertyName: "riskAssessment")]
        public bool RiskAssessment { get; set; }

        [JsonProperty(propertyName: "registrationType")]
        public string RegistrationType { get; set; }

        [JsonProperty(propertyName: "portalDescription")]
        public string PortalDescription { get; set; }

        [JsonProperty(propertyName: "availableTerms")]
        public List<string> AvailableTerms { get; set; }

        [JsonProperty(propertyName: "availableYears")]
        public List<string> AvailableYears { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }
    }
}