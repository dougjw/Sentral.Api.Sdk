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

        public string Type { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public SentralTime StartTime { get; set; }

        public SentralTime EndTime { get; set; }

        [JsonProperty(propertyName: "leaveType")]
        public string LeaveTypeName { get; set; }

        public DateTime Reason { get; set; }

        public bool HasReceivedMedicalCertificate { get; set; }

        [JsonProperty(propertyName: "externalSource")]        public string ExternalSource { get; set; }

        public string ExternalId { get; set; }

        public bool IsApproved { get; set; }

        // Related Entities
        public Relationship<Model.Enrolments.Staff> Staff { get; set; }

        public Relationship<StaffAbsenceLeaveType> LeaveType { get; set; }

    }
}
