using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.StaffAbsences
{
    public class StaffAbsence
    {
        private SentralTime _startTime;
        private SentralTime _endTime;

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Type { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string StartTime
        {
            get
            {
                if (_startTime == null)
                {
                    return null;
                }
                return _startTime.ToString();
            }
            set
            {
                _startTime = new SentralTime(value);
            }
        }

        
        public string EndTime
        {
            get
            {
                if (_endTime == null)
                {
                    return null;
                }
                return _endTime.ToString();
            }
            set
            {
                _endTime = new SentralTime(value);
            }
        }



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
