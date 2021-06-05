using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.WebCal;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.WebCal.Update;

namespace Sentral.API.PowerShell.WebCal
{
    [Cmdlet(VerbsCommon.Set, "SntCalCalendar")]
    [OutputType(typeof(WebcalCalendar))]
    public class SetSntCalCalendar : SentralPSCmdlet
    {

        private string _calendarName;
        private string _externalSource;

        private bool _calendarNameProvided;
        private bool _externalSourceProvided;


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Id")]
        [ValidateRange(1, int.MaxValue)]
        public int CalendarId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Object")]
        public WebcalCalendar Calendar { get; set; }

        [Parameter(Mandatory = false)]
        public string CalendarName
        {
            get
            {
                return _calendarName;
            }
            set
            {
                _calendarName = value;
                _calendarNameProvided = true;
            }
        }

        [Parameter(Mandatory = false)]
        public string ExternalSource
        {
            get
            {
                return _externalSource;
            }
            set
            {
                _externalSource = value;
                _externalSourceProvided = true;
            }

        }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateWebcalCalendar GetInitUpdateModel()
        {
            if (Calendar != null)
            {
                return new UpdateWebcalCalendar(Calendar.ID);
            }
            return new UpdateWebcalCalendar(CalendarId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateWebcalCalendar updateRecord = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_externalSourceProvided)
            {
                updateRecord.ExternalSource = _externalSource;
            };
            if (_calendarNameProvided)
            {
                updateRecord.CalendarName = _calendarName;
            }

            var response = SentralApiClient.WebCal.UpdateWebcalCalendar(updateRecord);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
