using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Timetables
{
    public class TimetableClassLesson
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public Relationship<TimetableClass> Class { get; set; }
        public Relationship<TimetableRoom> Room { get; set; }
        public Relationship<TimetablePeriodInDay> PeriodInDay { get; set; }
        public Relationship<List<TimetableStudent>> TimetableStudents { get; set; }
        public Relationship<List<TimetableTeacher>> TimetableTeachers { get; set; }

        public Relationship<List<Core.CoreStudent>> CoreStudents { get; set; }
        public Relationship<List<Core.CoreStaff>> CoreStaff { get; set; }


    }
}