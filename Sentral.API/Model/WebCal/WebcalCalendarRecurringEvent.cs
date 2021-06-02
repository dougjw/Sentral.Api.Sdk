using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.WebCal.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal
{
    public class WebcalCalendarRecurringEvent : IToUpdatable<UpdateWebcalCalendarRecurringEvent>
    {

        private SentralTime _startTime;
        private SentralTime _endTime;

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Link { get; set; }

        public string Category { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


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

        public WebCalRecurrenceType Recurrence { get; set; }

        public int? RecurrenceMonth { get; set; }

        public int? RecurrenceMonthDay { get; set; }

        public int? RecurrenceWeekDay { get; set; }

        public List<DateTime> RecurrenceDates { get; set; }

        public Relationship<WebcalCalendar> Owner { get; set; }

        public UpdateWebcalCalendarRecurringEvent ToUpdatable()
        {
            return new UpdateWebcalCalendarRecurringEvent(ID)
            {
                Title = Title,
                Notes = Notes,
                Link = Link,
                StartDate = StartDate,
                EndDate = EndDate,
                StartTime = new SentralTime(StartTime),
                EndTime = new SentralTime(EndTime),
                Recurrence = Recurrence,
                ReccurenceMonthDay = RecurrenceMonthDay,
                ReccurenceWeekDay = RecurrenceWeekDay,
                RecurrenceMonth = RecurrenceMonth,
                Category = Category
            };
        }
    }
}
