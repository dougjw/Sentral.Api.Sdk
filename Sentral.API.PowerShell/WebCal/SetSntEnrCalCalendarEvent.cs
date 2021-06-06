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
    [Cmdlet(VerbsCommon.Set, "SntCalCalendarEvent")]
    [OutputType(typeof(WebcalCalendarEvent))]
    public class SetSntCalCalendarEvent : SentralPSCmdlet
    {
        private string _title;
        private string _notes;
        private string _link;
        private string _category;
        private DateTime _date;
        private string _startTime;
        private string _endTime;
        private ICollection<DateTime> _otherDates;

        private bool _titleProvided;
        private bool _notesProvided;
        private bool _linkProvided;
        private bool _categoryProvided;
        private bool _dateProvided;
        private bool _startTimeProvided;
        private bool _endTimeProvided;
        private bool _otherDatesProvided;


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Id")]
        [ValidateRange(1, int.MaxValue)]
        public int CalendarEventId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Object")]
        public WebcalCalendarEvent CalendarEvent { get; set; }

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
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                _dateProvided = true;
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

        [Parameter(Mandatory = false)]
        public ICollection<DateTime> OtherDates
        {
            get
            {
                return _otherDates;
            }
            set
            {
                _otherDates = value;
                _otherDatesProvided = true;
            }
        }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateWebcalCalendarEvent GetInitUpdateModel()
        {
            if (CalendarEvent != null)
            {
                return new UpdateWebcalCalendarEvent(CalendarEvent.ID);
            }
            return new UpdateWebcalCalendarEvent(CalendarEventId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateWebcalCalendarEvent updateRecord = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_notesProvided)
            {
                updateRecord.Notes = _notes;
            }
            if (_titleProvided)
            {
                updateRecord.Title = _title;
            }
            if (_linkProvided)
            {
                updateRecord.Link = Link;
            }
            if (_categoryProvided)
            {
                updateRecord.Category = _category;
            }
            if (_dateProvided)
            {
                updateRecord.Date = Date;
            }
            if (_startTimeProvided)
            {
                updateRecord.StartTime = new SentralTime(_startTime);
            }
            if (_endTimeProvided)
            {
                updateRecord.EndTime = new SentralTime(_endTime);
            }
            if (_otherDatesProvided)
            {
                updateRecord.OtherDates = _otherDates;
            }

            var response = SentralApiClient.WebCal.UpdateWebcalCalendarEvent(updateRecord);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
