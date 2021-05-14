using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;

namespace Sentral.API.Model.Attendance
{
    public class FutureAbsence
    {
        private SentralTime _startTime;
        private SentralTime _endTime;

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "type")]
        public string FutureAbsenceType { get; set; }
        public DateTime? Date { get; set; }

        [JsonProperty(propertyName: "start")]
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


        [JsonProperty(propertyName: "end")]
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

        public string Comment { get; set; }
        public string Explainer { get; set; }
        public string ExplainerSource { get; set; }

        [JsonProperty(propertyName: "letterSent")]
        public string IsLetterSent { get; set; }
        public bool Submitted { get; set; }

        public Relationship<Enrolments.Student> EnrolmentStudent { get; set; }
    }
}