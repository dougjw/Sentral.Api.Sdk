using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.WebCal;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.WebCal.Update;
using System.Collections.Generic;
using Sentral.API.Model.Common;

namespace Sentral.API.PowerShell.WebCal
{
    [Cmdlet(VerbsCommon.Set, "SntCalCalendarRecurringEvent", DefaultParameterSetName = _idBasicParmSet)]
    [OutputType(typeof(WebcalCalendarRecurringEvent))]
    public class SetSntCalCalendarRecurringEvent : SentralPSCmdlet
    {
        private const string _idBasicParmSet = "BasicById";
        private const string _idRecurringDailyParmSet = "RecurrenceDailyById";
        private const string _idRecurringDay1ParmSet = "RecurrenceDay1ById";
        private const string _idRecurringDay2ParmSet = "RecurrenceDay2ById";
        private const string _idRecurringDay3ParmSet = "RecurrenceDay3ById";
        private const string _idRecurringDay4ParmSet = "RecurrenceDay4ById";
        private const string _idRecurringDay5ParmSet = "RecurrenceDay5ById";
        private const string _idRecurringWeekParamSet = "RecurrenceWeekById";
        private const string _idRecurringFortnightEvenParamSet = "RecurrenceFortnightEvenById";
        private const string _idRecurringFortnightOddParamSet = "RecurrenceFortnightOddById";
        private const string _idRecurringMonthParamSet = "RecurrenceMonthById";
        private const string _idRecurringYearParamSet = "RecurrenceYearById";



        private const string _objBasicParmSet = "BasicByObj";
        private const string _objRecurringDailyParmSet = "RecurrenceDailyByObj";
        private const string _objRecurringDay1ParmSet = "RecurrenceDay1ByObj";
        private const string _objRecurringDay2ParmSet = "RecurrenceDay2ByObj";
        private const string _objRecurringDay3ParmSet = "RecurrenceDay3ByObj";
        private const string _objRecurringDay4ParmSet = "RecurrenceDay4ByObj";
        private const string _objRecurringDay5ParmSet = "RecurrenceDay5ByObj";
        private const string _objRecurringWeekParamSet = "RecurrenceWeekByObj";
        private const string _objRecurringFortnightEvenParamSet = "RecurrenceFortnightEvenByObj";
        private const string _objRecurringFortnightOddParamSet = "RecurrenceFortnightOddByObj";
        private const string _objRecurringMonthParamSet = "RecurrenceMonthByObj";
        private const string _objRecurringYearParamSet = "RecurrenceYearByObj";


        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringDailyParmSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringDailyParmSet)]
        public SwitchParameter RecurranceDaily { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringDay1ParmSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringDay1ParmSet)]
        public SwitchParameter RecurranceDay1 { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringDay2ParmSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringDay2ParmSet)]
        public SwitchParameter RecurranceDay2 { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringDay3ParmSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringDay3ParmSet)]
        public SwitchParameter RecurranceDay3 { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringDay4ParmSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringDay4ParmSet)]
        public SwitchParameter RecurranceDay4 { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringDay5ParmSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringDay5ParmSet)]
        public SwitchParameter RecurranceDay5 { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = _idRecurringWeekParamSet)]
        [Parameter(Mandatory = true, ParameterSetName = _objRecurringWeekParamSet)]
        public SwitchParameter RecurranceWeek { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringFortnightEvenParamSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringFortnightEvenParamSet)]
        public SwitchParameter RecurranceFortnightEven { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringFortnightOddParamSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringFortnightOddParamSet)]
        public SwitchParameter RecurranceFortnightOdd { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringMonthParamSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringMonthParamSet)]
        public SwitchParameter RecurranceMonth { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _idRecurringYearParamSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = _objRecurringYearParamSet)]
        public SwitchParameter RecurranceYear { get; set; }


        private string _title;
        private string _notes;
        private string _link;
        private string _category;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private string _startTime;
        private string _endTime;
        private int? _recurrenceWeekDay;
        private int? _recurrenceMonthDay;


        private bool _titleProvided;
        private bool _notesProvided;
        private bool _linkProvided;
        private bool _categoryProvided;
        private bool _startDateProvided;
        private bool _endDateProvided;
        private bool _startTimeProvided;
        private bool _endTimeProvided;
        private bool _recurrenceWeekDayProvided;
        private bool _recurrenceMonthDayProvided;



        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringDailyParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringDay1ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringDay2ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringDay3ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringDay4ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringDay5ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringWeekParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringFortnightEvenParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringFortnightOddParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringMonthParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idRecurringYearParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _idBasicParmSet)]
        [ValidateRange(1, int.MaxValue)]
        public int CalendarRecurringEventId { get; set; }



        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringDailyParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringDay1ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringDay2ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringDay3ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringDay4ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringDay5ParmSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringWeekParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringFortnightEvenParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringFortnightOddParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringMonthParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objRecurringYearParamSet)]
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _objBasicParmSet)]
        public WebcalCalendarRecurringEvent CalendarRecurringEvent { get; set; }

        [Parameter(Mandatory = false)]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                _titleProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                _notes = value;
                _notesProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string Link
        {
            get
            {
                return _link;
            }
            set
            {
                _link = value;
                _linkProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                _categoryProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public DateTime? StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                _startDateProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public DateTime? EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                _endDateProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        [ValidatePattern(TimePattern)]
        public string StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
                _startTimeProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        [ValidatePattern(TimePattern)]
        public string EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
                _endTimeProvided = true;
            }
        }

        [Parameter(Mandatory = false, ParameterSetName = _idRecurringDailyParmSet)]
        [Parameter(Mandatory = true, ParameterSetName =  _idRecurringDay1ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName =  _idRecurringDay2ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName =  _idRecurringDay3ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName =  _idRecurringDay4ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName =  _idRecurringDay5ParmSet)]
        [Parameter(Mandatory = false, ParameterSetName = _idRecurringWeekParamSet)]
        [Parameter(Mandatory = false, ParameterSetName = _idBasicParmSet)]
        [Parameter(Mandatory = false, ParameterSetName = _objRecurringDailyParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _objRecurringDay1ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _objRecurringDay2ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _objRecurringDay3ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _objRecurringDay4ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _objRecurringDay5ParmSet)]
        [Parameter(Mandatory = false, ParameterSetName = _objRecurringWeekParamSet)]
        [Parameter(Mandatory = false, ParameterSetName = _objBasicParmSet)]
        [ValidateRange(1, 7)]
        public int? RecurrenceWeekDay
        {
            get
            {
                return _recurrenceWeekDay;
            }
            set
            {
                _recurrenceWeekDay = value;
                _recurrenceWeekDayProvided = true;
            }
        }

        [Parameter(Mandatory = false, ParameterSetName = _idRecurringMonthParamSet)]
        [Parameter(Mandatory = false, ParameterSetName = _objRecurringMonthParamSet)]
        [ValidateRange(1, 31)]
        public int? RecurrenceMonthDay
        {
            get
            {
                return _recurrenceMonthDay;
            }
            set
            {
                _recurrenceMonthDay = value;
                _recurrenceMonthDayProvided = true;
            }
        }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateWebcalCalendarRecurringEvent GetInitUpdateModel()
        {

            if (CalendarRecurringEvent != null)
            {
                return new UpdateWebcalCalendarRecurringEvent(CalendarRecurringEvent.ID);
            }
            return new UpdateWebcalCalendarRecurringEvent(CalendarRecurringEventId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateWebcalCalendarRecurringEvent updateRecord = GetRecurringEvent();
            var response = SentralApiClient.WebCal.UpdateWebcalCalendarRecurringEvent(updateRecord);

            WriteObject(response);
        }

        private UpdateWebcalCalendarRecurringEvent GetRecurringEvent()
        {
            UpdateWebcalCalendarRecurringEvent updateRecord = GetInitUpdateModel();
            SetCommonProperties(updateRecord);

            switch (ParameterSetName)
            {
                case _idBasicParmSet:
                case _objBasicParmSet:
                    break;
                case _idRecurringDailyParmSet:
                case _objRecurringDailyParmSet:
                    SetRecurringPropertiesDaily(updateRecord);
                    break;
                case _idRecurringDay1ParmSet:
                case _idRecurringDay2ParmSet:
                case _idRecurringDay3ParmSet:
                case _idRecurringDay4ParmSet:
                case _idRecurringDay5ParmSet:
                case _idRecurringWeekParamSet:
                case _idRecurringFortnightEvenParamSet:
                case _idRecurringFortnightOddParamSet:
                case _objRecurringDay1ParmSet:
                case _objRecurringDay2ParmSet:
                case _objRecurringDay3ParmSet:
                case _objRecurringDay4ParmSet:
                case _objRecurringDay5ParmSet:
                case _objRecurringWeekParamSet:
                case _objRecurringFortnightEvenParamSet:
                case _objRecurringFortnightOddParamSet:
                    SetRecurringPropertiesDayWeekFortnight(updateRecord);
                    break;
                case _idRecurringMonthParamSet:
                case _objRecurringMonthParamSet:
                    SetRecurringPropertiesMonth(updateRecord);
                    break;
                case _idRecurringYearParamSet:
                case _objRecurringYearParamSet:
                    throw new NotImplementedException("Yearly recurrence is not yet implemented in the Sentral API");
            }
            return updateRecord;
        }

        private void SetCommonProperties(UpdateWebcalCalendarRecurringEvent updateRecord)
        {
            // Populate from student object if object was used.
            if (_notesProvided)
            {
                updateRecord.Notes = Notes;
            }
            if (_titleProvided)
            {
                updateRecord.Title = Title;
            }
            if (_linkProvided)
            {
                updateRecord.Link = Link;
            }
            if (_categoryProvided)
            {
                updateRecord.Category = Category;
            }
            if (_startDateProvided)
            {
                updateRecord.StartDate = StartDate;
            }
            if (_endDateProvided)
            {
                updateRecord.EndDate = EndDate;
            }
            if (_startTimeProvided)
            {
                updateRecord.StartTime = new SentralTime(StartTime);
            }
            if (_endTimeProvided)
            {
                updateRecord.EndTime = new SentralTime(EndTime);
            }
            if(ParameterSetName != _idBasicParmSet && ParameterSetName != _objBasicParmSet)
            {
                updateRecord.Recurrence = RecurrenceType;
            }
        }

        private void SetRecurringPropertiesDaily(UpdateWebcalCalendarRecurringEvent updateRecord)
        {
            if (_recurrenceWeekDayProvided)
            {
                updateRecord.RecurrenceWeekDay = RecurrenceWeekDay;
            }
        }

        private void SetRecurringPropertiesMonth(UpdateWebcalCalendarRecurringEvent updateRecord)
        {
            if (_recurrenceMonthDayProvided)
            {
                updateRecord.RecurrenceMonthDay = RecurrenceMonthDay;
            }
        }

        private void SetRecurringPropertiesDayWeekFortnight(UpdateWebcalCalendarRecurringEvent updateRecord)
        {
            if (_recurrenceWeekDayProvided)
            {
                updateRecord.RecurrenceWeekDay = RecurrenceWeekDay;
            }
        }

        private WebCalRecurrenceType? RecurrenceType
        {
            get
            {
                switch (ParameterSetName)
                {
                    case _idRecurringDailyParmSet:
                    case _idRecurringMonthParamSet:
                    case _objRecurringDailyParmSet:
                    case _objRecurringMonthParamSet:
                        return null;
                    case _idRecurringDay1ParmSet:
                    case _objRecurringDay1ParmSet:
                        return WebCalRecurrenceType.day1;
                    case _idRecurringDay2ParmSet:
                    case _objRecurringDay2ParmSet:
                        return WebCalRecurrenceType.day2;
                    case _idRecurringDay3ParmSet:
                    case _objRecurringDay3ParmSet:
                        return WebCalRecurrenceType.day3;
                    case _idRecurringDay4ParmSet:
                    case _objRecurringDay4ParmSet:
                        return WebCalRecurrenceType.day4;
                    case _idRecurringDay5ParmSet:
                    case _objRecurringDay5ParmSet:
                        return WebCalRecurrenceType.day5;
                    case _idRecurringWeekParamSet:
                    case _objRecurringWeekParamSet:
                        return WebCalRecurrenceType.week;
                    case _idRecurringFortnightEvenParamSet:
                    case _objRecurringFortnightEvenParamSet:
                        return WebCalRecurrenceType.fortnight_even;
                    case _idRecurringFortnightOddParamSet:
                    case _objRecurringFortnightOddParamSet:
                        return WebCalRecurrenceType.fortnight_odd;
                    default:
                        throw new ArgumentException("Recurrence type invalid.");
                }

            }
        }


        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
