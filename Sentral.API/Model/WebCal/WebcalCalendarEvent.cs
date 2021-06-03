using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.WebCal.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal
{
    public class WebcalCalendarEvent : IToUpdatable<UpdateWebcalCalendarEvent>
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        public List<DateTime> OtherDates { get; set; }

        public string Category { get; set; }

        public SentralTime StartTime { get; set; }

        public SentralTime EndTime { get; set; }

        public Relationship<WebcalCalendar> Owner { get; set; }

        public UpdateWebcalCalendarEvent ToUpdatable()
        {
            return new UpdateWebcalCalendarEvent(ID)
            {
                Title = Title,
                Notes = Notes,
                Link = Link,
                Date = Date,
                OtherDates = OtherDates,
                StartTime = StartTime,
                EndTime = EndTime,
                Category = Category
            };
        }
    }
}
