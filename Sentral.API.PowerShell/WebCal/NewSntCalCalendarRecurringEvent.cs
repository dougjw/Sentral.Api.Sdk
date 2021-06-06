using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.WebCal;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.WebCal.Update;
using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Core.Update;
using Sentral.API.Model.Common;
using System.Collections.Generic;

namespace Sentral.API.PowerShell.WebCal
{
    [Cmdlet(VerbsCommon.New, "SntCalCalendarRecurringEvent")]
    [OutputType(typeof(WebcalCalendarRecurringEvent))]
    public class NewSntCalCalendarRecurringEvent : SentralPSCmdlet
    {
        private const string _recurringDailyParmSet = "Daily";
        private const string _recurringDay1ParmSet = "Day1";
        private const string _recurringDay2ParmSet = "Day2";
        private const string _recurringDay3ParmSet = "Day3";
        private const string _recurringDay4ParmSet = "Day4";
        private const string _recurringDay5ParmSet = "Day5";
        private const string _recurringWeekParamSet = "Week";
        private const string _recurringFortnightEvenParamSet = "FortnightEven";
        private const string _recurringFortnightOddParamSet = "fortnightOdd";
        private const string _recurringMonthParamSet = "Month";
        private const string _recurringYearParamSet = "Year";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringDailyParmSet)]
        public SwitchParameter RecurranceDaily { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringDay1ParmSet)]
        public SwitchParameter RecurranceDay1 { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringDay2ParmSet)]
        public SwitchParameter RecurranceDay2 { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringDay3ParmSet)]
        public SwitchParameter RecurranceDay3 { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringDay4ParmSet)]
        public SwitchParameter RecurranceDay4 { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringDay5ParmSet)]
        public SwitchParameter RecurranceDay5 { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringWeekParamSet)]
        public SwitchParameter RecurranceWeek { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringFortnightEvenParamSet)]
        public SwitchParameter RecurranceFortnightEven { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringFortnightOddParamSet)]
        public SwitchParameter RecurranceFortnightOdd { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringMonthParamSet)]
        public SwitchParameter RecurranceMonth { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = _recurringYearParamSet)]
        public SwitchParameter RecurranceYear { get; set; }

        [Parameter(Mandatory = true)]
        public string Title { get; set; }

        [Parameter(Mandatory = false)]
        public string Notes { get; set; }

        [Parameter(Mandatory = false)]
        public string Link { get; set; }

        [Parameter(Mandatory = false)]
        public string Category { get; set; }

        [Parameter(Mandatory = true)]
        public DateTime StartDate { get; set; }

        [Parameter(Mandatory = true)]
        public DateTime EndDate { get; set; }

        [Parameter(Mandatory = false)]
        [ValidatePattern(TimePattern)]
        public string StartTime { get; set; }

        [Parameter(Mandatory = false)]
        [ValidatePattern(TimePattern)]
        public string EndTime { get; set; }


        [Parameter(Mandatory = true, ParameterSetName = _recurringDay1ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _recurringDay2ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _recurringDay3ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _recurringDay4ParmSet)]
        [Parameter(Mandatory = true, ParameterSetName = _recurringDay5ParmSet)]
        [Parameter(Mandatory = false, ParameterSetName = _recurringWeekParamSet)]
        [Parameter(Mandatory = false, ParameterSetName = _recurringDailyParmSet)]
        [ValidateRange(1,7)]
        public int? RecurrenceWeekDay { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _recurringMonthParamSet)]
        [ValidateRange(1, 31)]
        public int? RecurrenceMonthDay { get; set; }

        [Parameter(Mandatory = true)]
        public WebcalCalendar Calendar { get; set; }

        private WebCalRecurrenceType? RecurrenceType {
            get
            {
                switch (ParameterSetName)
                {
                    case _recurringDailyParmSet:
                    case _recurringMonthParamSet:
                        return null;
                    case _recurringDay1ParmSet:
                        return WebCalRecurrenceType.day1;
                    case _recurringDay2ParmSet:
                        return WebCalRecurrenceType.day2;
                    case _recurringDay3ParmSet:
                        return WebCalRecurrenceType.day3;
                    case _recurringDay4ParmSet:
                        return WebCalRecurrenceType.day4;
                    case _recurringDay5ParmSet:
                        return WebCalRecurrenceType.day5;
                    case _recurringWeekParamSet:
                        return WebCalRecurrenceType.week;
                    case _recurringFortnightEvenParamSet:
                        return WebCalRecurrenceType.fortnight_even;
                    case _recurringFortnightOddParamSet:
                        return WebCalRecurrenceType.fortnight_odd;
                    default:
                        throw new ArgumentException("Recurrence type invalid.");
                }

            }
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            if (Calendar == null)
            {
                throw new ArgumentException("The Calendar property cannot be null");
            }

            UpdateWebcalCalendarRecurringEvent newRecord = GetRecurringEvent();

            var response = SentralApiClient.WebCal.CreateWebcalCalendarRecurringEvent(newRecord);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }


        private UpdateWebcalCalendarRecurringEvent GetRecurringEvent()
        {
            switch(ParameterSetName)
            {
                case _recurringDailyParmSet:
                    return GetRecurringEventDaily();
                case _recurringDay1ParmSet:
                case _recurringDay2ParmSet:
                case _recurringDay3ParmSet:
                case _recurringDay4ParmSet:
                case _recurringDay5ParmSet:
                case _recurringWeekParamSet:
                case _recurringFortnightEvenParamSet:
                case _recurringFortnightOddParamSet:
                    return GetRecurringEventDayWeekFortnight();
                case _recurringMonthParamSet:
                    return GetRecurringEventMonth();
                case _recurringYearParamSet:
                    throw new NotImplementedException("Yearly recurrence is not yet implemented in the Sentral API");
                default:
                    return null;
            }
        }

        private UpdateWebcalCalendarRecurringEvent GetRecurringEventDaily()
        {
            return new UpdateWebcalCalendarRecurringEvent()
            {

                Title = Title,
                Notes = Notes,
                Link = Link,
                Category = Category,
                StartDate = StartDate,
                EndDate = EndDate,
                StartTime = new SentralTime(StartTime),
                EndTime = new SentralTime(EndTime),
                Recurrence = RecurrenceType,
                RecurrenceWeekDay = RecurrenceWeekDay,
                Calendar = new Relationship<SimpleWebCalCalendarLink>()
                {
                    Data = new SimpleWebCalCalendarLink()
                    {
                        ID = Calendar.ID
                    }
                }
            };
        }

        private UpdateWebcalCalendarRecurringEvent GetRecurringEventMonth()
        {
            return new UpdateWebcalCalendarRecurringEvent()
            {

                Title = Title,
                Notes = Notes,
                Link = Link,
                Category = Category,
                StartDate = StartDate,
                EndDate = EndDate,
                StartTime = new SentralTime(StartTime),
                EndTime = new SentralTime(EndTime),
                Recurrence = RecurrenceType,
                RecurrenceMonthDay = RecurrenceMonthDay,
                Calendar = new Relationship<SimpleWebCalCalendarLink>()
                {
                    Data = new SimpleWebCalCalendarLink()
                    {
                        ID = Calendar.ID
                    }
                }
            };
        }

        private UpdateWebcalCalendarRecurringEvent GetRecurringEventDayWeekFortnight()
        {
            return new UpdateWebcalCalendarRecurringEvent()
            {

                Title = Title,
                Notes = Notes,
                Link = Link,
                Category = Category,
                StartDate = StartDate,
                EndDate = EndDate,
                StartTime = new SentralTime(StartTime),
                EndTime = new SentralTime(EndTime),
                Recurrence = RecurrenceType,
                RecurrenceWeekDay = RecurrenceWeekDay,
                Calendar = new Relationship<SimpleWebCalCalendarLink>()
                {
                    Data = new SimpleWebCalCalendarLink()
                    {
                        ID = Calendar.ID
                    }
                }
            };
        }
    }
}
