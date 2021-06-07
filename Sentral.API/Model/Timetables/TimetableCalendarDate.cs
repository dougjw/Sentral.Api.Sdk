using Newtonsoft.Json;
using System;

namespace Sentral.API.Model.Timetables
{
    public class TimetableCalendarDate
    {
        [JsonProperty(propertyName: "id")]
        public DateTime ID { get; set; }

        public DateTime Date { get; set; }

        public int? Cycle { get; set; }
        public int? Interval { get; set; }
        public bool IsDailyTimetable { get; set; }


    }
}