using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal.Update
{
    public class UpdateWebcalCalendarEvent : AbstractUpdatable
    {
        
        private const string _type = "webcalCalendarEvent";

        private string _title;
        private string _notes;
        private string _link;
        private DateTime? _date;
        private SentralTime _startTime;
        private SentralTime _endTime;
        private string _category;
        private List<DateTime> _otherDates;
        private Relationship<SimpleWebCalCalendarLink> _calendar;


        private bool _titleIncludeInSerialize;
        private bool _notesIncludeInSerialize;
        private bool _linkIncludeInSerialize;
        private bool _dateIncludeInSerialize;
        private bool _startTimeIncludeInSerialize;
        private bool _endTimeIncludeInSerialize;
        private bool _categoryIncludeInSerialize;
        private bool _otherDatesIncludeInSerialize;
        private bool _calendarIncludeInSerialize;

        // Patch model
        public UpdateWebcalCalendarEvent(int id) :base(id, _type)
        {}

        // Post Model
        public UpdateWebcalCalendarEvent() : base(_type)
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
        public DateTime? Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
                _dateIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeDate()
        {
            return _dateIncludeInSerialize;
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
        public List<DateTime> OtherDates 
        {
            get
            {
                return _otherDates;
            }

            set
            {
                _otherDates = value;
                _otherDatesIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeOtherDates()
        {
            return _otherDatesIncludeInSerialize;
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
    }
}
