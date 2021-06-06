using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;

namespace Sentral.API.Model.Attendance
{
    public class FutureAbsence
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "type")]
        public string FutureAbsenceType { get; set; }
        public DateTime? Date { get; set; }

        [JsonProperty(propertyName: "start")]
        public SentralTime StartTime { get; set; }


        [JsonProperty(propertyName: "end")]
        public SentralTime EndTime { get; set; }

        public string Comment { get; set; }
        public string Explainer { get; set; }
        public string ExplainerSource { get; set; }

        [JsonProperty(propertyName: "letterSent")]
        public string IsLetterSent { get; set; }
        public bool Submitted { get; set; }

        public Relationship<Enrolments.Student> EnrolmentStudent { get; set; }
    }
}