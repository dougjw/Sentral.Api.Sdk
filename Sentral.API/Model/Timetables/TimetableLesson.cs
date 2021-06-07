using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;

namespace Sentral.API.Model.Timetables
{
    public class TimetableLesson
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string ClassName { get; set; }

        public string Subject { get; set; }

        public string RoomName { get; set; }

        public string TeacherName { get; set; }

        public int[] TeacherIds { get; set; }

        public DateTime Date { get; set; }

        public string DayName { get; set; }

        public int DayOrder { get; set; }

        public string PeriodName { get; set; }

        public int PeriodOrder { get; set; }

        public SentralTime StartTime { get; set; }

        public SentralTime EndTime { get; set; }

        public SentralColour Colour { get; set; }

        public string ClassType { get; set; }

        public Relationship<Enrolments.Staff> RelatedStaff { get; set; }
        public Relationship<Enrolments.Student> RelatedStudent { get; set; }
    }
}