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

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Link { get; set; }

        public string Category { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public SentralTime StartTime { get; set; }

        public SentralTime EndTime { get; set; }

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
                StartTime = StartTime,
                EndTime = EndTime,
                Recurrence = Recurrence,
                RecurrenceMonthDay = RecurrenceMonthDay,
                RecurrenceWeekDay = RecurrenceWeekDay,
                RecurrenceMonth = RecurrenceMonth,
                Category = Category
            };
        }
    }
}
