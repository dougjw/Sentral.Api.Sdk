using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal
{
    public class WebcalCalendarRecurringEvent
    {

        private SentralTime _startTime;
        private SentralTime _endTime;

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }

        public string Link { get; set; }

        public string Category { get; set; }

        DateTime StartDate { get; set; }

        DateTime EndDate { get; set; }


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

        List<DateTime> RecurrenceDates { get; set; }

        Relationship<WebcalCalendar> Owner { get; set; }
    }
}
