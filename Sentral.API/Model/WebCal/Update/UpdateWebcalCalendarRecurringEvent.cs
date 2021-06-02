using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal.Update
{
    public class UpdateWebcalCalendarRecurringEvent : AbstractUpdatable
    {
        
        private const string _type = "webcalCalendarRecurringEvent";

        private string _title;
        private string _notes;
        private string _link;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private SentralTime _startTime;
        private SentralTime _endTime;
        private string _category;
        private WebCalRecurrenceType? _recurrence;
        private int? _recurrenceMonth;
        private int? _reccurenceMonthDay;
        private int? _reccurenceWeekDay;


        private Relationship<SimpleWebCalCalendarLink> _calendar;


        private bool _titleIncludeInSerialize;
        private bool _notesIncludeInSerialize;
        private bool _linkIncludeInSerialize;
        private bool _startDateIncludeInSerialize;
        private bool _endDateIncludeInSerialize;
        private bool _startTimeIncludeInSerialize;
        private bool _endTimeIncludeInSerialize;
        private bool _categoryIncludeInSerialize;
        private bool _calendarIncludeInSerialize;
        private bool _recurrenceIncludeInSerialize;
        private bool _recurrenceMonthIncludeInSerialize;
        private bool _reccurenceMonthDayIncludeInSerialize;
        private bool _reccurenceWeekDayIncludeInSerialize;

        // Patch model
        public UpdateWebcalCalendarRecurringEvent(int id) :base(id, _type)
        {}

        // Post Model
        public UpdateWebcalCalendarRecurringEvent() : base(_type)
        { }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Title {
            get
            {
                return _title;
            } 
            
            set
            {
                _title = value;
                _titleIncludeInSerialize = true;
            } 
        }


        public bool ShouldSerializeTitle()
        {
            return _titleIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Notes
        {
            get
            {
                return _notes;
            }

            set
            {
                _notes = value;
                _notesIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeNotes()
        {
            return _notesIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Link
        {
            get
            {
                return _link;
            }

            set
            {
                _link = value;
                _linkIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeLink()
        {
            return _linkIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? StartDate
        {
            get
            {
                return _startDate;
            }

            set
            {
                _startDate = value;
                _startDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeStartDate()
        {
            return _startDateIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? EndDate
        {
            get
            {
                return _endDate;
            }

            set
            {
                _endDate = value;
                _endDateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEndDate()
        {
            return _endDateIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public SentralTime StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                _startTime = value;
                _startTimeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeStartTime()
        {
            return _startTimeIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public SentralTime EndTime
        {
            get
            {
                return _endTime;
            }

            set
            {
                _endTime = value;
                _endTimeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEndTime()
        {
            return _endTimeIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
                _categoryIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeCategory()
        {
            return _categoryIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public WebCalRecurrenceType? Recurrence
        {
            get
            {
                return _recurrence;
            }

            set
            {
                _recurrence = value;
                _recurrenceIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeRecurrence()
        {
            return _recurrenceIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public int? RecurrenceMonth
        {
            get
            {
                return _recurrenceMonth;
            }

            set
            {
                _recurrenceMonth = value;
                _recurrenceMonthIncludeInSerialize = true;
            }
        }

        public bool ShouldSerializeRecurrenceMonth()
        {
            return _recurrenceMonthIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public int? ReccurenceMonthDay
        {
            get
            {
                return _reccurenceMonthDay;
            }

            set
            {
                _reccurenceMonthDay = value;
                _reccurenceMonthDayIncludeInSerialize = true;
            }
        }

        public bool ShouldSerializeReccurenceMonthDay()
        {
            return _reccurenceMonthDayIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public int? ReccurenceWeekDay
        {
            get
            {
                return _reccurenceWeekDay;
            }

            set
            {
                _reccurenceWeekDay = value;
                _reccurenceWeekDayIncludeInSerialize = true;
            }
        }

        public bool ShouldSerializeRecurrenceWeekDay()
        {
            return _reccurenceWeekDayIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<SimpleWebCalCalendarLink> Calendar
        {
            get
            {
                return _calendar;
            }

            set
            {
                _calendar = value;
                _calendarIncludeInSerialize = IsPostModel();
            }
        }


        public bool ShouldSerializeCalendar()
        {
            return _calendarIncludeInSerialize;
        }

        public UpdateWebcalCalendarEvent ToUpdatable()
        {
            throw new NotImplementedException();
        }
    }
}
