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
    [Cmdlet(VerbsCommon.New, "SntCalCalendarEvent")]
    [OutputType(typeof(WebcalCalendarEvent))]
    public class NewSntCalCalendarEvent : SentralPSCmdlet
    {
                  
        [Parameter(Mandatory = true)]
        public string Title { get; set; }

        [Parameter(Mandatory = false)]
        public string Notes { get; set; }

        [Parameter(Mandatory = false)]
        public string Link { get; set; }

        [Parameter(Mandatory = false)]
        public string Category { get; set; }

        [Parameter(Mandatory = true)]
        public DateTime Date { get; set; }

        [Parameter(Mandatory = false)]
        [ValidatePattern(TimePattern)]
        public string StartTime { get; set; }

        [Parameter(Mandatory = false)]
        [ValidatePattern(TimePattern)]
        public string EndTime { get; set; }

        [Parameter(Mandatory = false)]
        public ICollection<DateTime> OtherDates { get; set; }


        [Parameter(Mandatory = true)]
        public WebcalCalendar Calendar { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }
        
        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            if(Calendar == null)
            {
                throw new ArgumentException("The Calendar property cannot be null");
            }

            UpdateWebcalCalendarEvent newRecord = new UpdateWebcalCalendarEvent()
            {

                Title = Title,
                Notes = Notes,
                Link = Link,
                Category = Category,
                Date = Date,
                StartTime = new SentralTime(StartTime),
                EndTime = new SentralTime(EndTime),
                OtherDates = OtherDates,
                Calendar = new Relationship<SimpleWebCalCalendarLink>()
                {
                    Data = new SimpleWebCalCalendarLink()
                    {
                        ID = Calendar.ID
                    }
                }
            };

            var response = SentralApiClient.WebCal.CreateWebcalCalendarEvent(newRecord);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
