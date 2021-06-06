using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Timetables
{
    public class TimetableDailyLesson 
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }

        public SentralTime StartTime { get; set; }

        public SentralTime EndTime { get; set; }

        public Relationship<TimetableClass> Class { get; set; }
        public Relationship<TimetableRoom> Room { get; set; }
        public Relationship<TimetablePeriodInDay> PeriodInDay { get; set; }
        public Relationship<List<TimetableStudent>> TimetableStudents { get; set; }
        public Relationship<List<TimetableTeacher>> TimetableTeachers { get; set; }

        public Relationship<List<Core.CoreStudent>> CoreStudents { get; set; }
        public Relationship<List<Core.CoreStaff>> CoreStaff { get; set; }



    }
}