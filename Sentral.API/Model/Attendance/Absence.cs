using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Attendance
{
    public class Absence
    {
        [JsonProperty(propertyName:"id")]
        public int ID { get; set; }

        public string Type { get; set; }
        public DateTime? Date { get; set; }

        [JsonProperty(propertyName: "start")]
        public SentralTime StartTime { get; set; }

        [JsonProperty(propertyName: "end")]
        public SentralTime EndTime { get; set; }
        public string Comment { get; set; }
        public string Explainer { get; set; }
        public string ExplainerSource { get; set; }
        public bool LetterSent { get; set; }
        public bool Submitted { get; set; }

        public Relationship<Enrolments.Student> EnrolmentStudent { get; set; }

        public Relationship<Core.CoreStudent> CoreStudent { get; set; }
        public Relationship<FutureAbsence> MatchingFutureAbsence { get; set; }


    }
}
