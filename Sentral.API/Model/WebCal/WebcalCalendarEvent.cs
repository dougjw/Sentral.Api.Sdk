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

        private SentralTime _startTime;
        private SentralTime _endTime;

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        public List<DateTime> OtherDates { get; set; }

        public string Category { get; set; }

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
                StartTime = new SentralTime(StartTime),
                EndTime = new SentralTime(EndTime),
                Category = Category
            };
        }
    }
}
