using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.StaffAbsences
{
    public class StaffAbsence
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(propertyName: "endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty(propertyName: "startTime")]
        public DateTime? StartTime { get; set; }

        [JsonProperty(propertyName: "endTime")]
        public DateTime? EndTime { get; set; }

        [JsonProperty(propertyName: "leaveType")]
        public string LeaveTypeName { get; set; }

        [JsonProperty(propertyName: "reason")]
        public DateTime Reason { get; set; }

        [JsonProperty(propertyName: "hasReceivedMedicalCertificate")]
        public bool HasReceivedMedicalCertificate { get; set; }

        [JsonProperty(propertyName: "externalSource")]
        public string ExternalSource { get; set; }

        [JsonProperty(propertyName: "externalId")]
        public string ExternalId { get; set; }

        [JsonProperty(propertyName: "isApproved")]
        public bool IsApproved { get; set; }

        // Related Entities

        [JsonProperty(propertyName:"staff")]
        public Relationship<Model.Enrolments.Staff> Staff { get; set; }

        [JsonProperty(propertyName: "leaveType")]
        public Relationship<StaffAbsenceLeaveType> LeaveType { get; set; }

    }
}
