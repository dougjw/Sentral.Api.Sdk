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

namespace Sentral.API.PowerShell.WebCal
{
    [Cmdlet(VerbsCommon.New, "SntCalCalendar")]
    [OutputType(typeof(WebcalCalendar))]
    public class NewSntCalCalendar : SentralPSCmdlet
    {
                  
        [Parameter(Mandatory = true)]
        public string CalendarName { get; set; }

        [Parameter(Mandatory = true)]
        public string ExternalSource { get; set; }

        [Parameter(Mandatory = true)]
        public SimpleCoreAdministrativeUserLink Owner { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }
        
        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            if(Owner == null)
            {
                throw new ArgumentException("The Owner property cannot be null");
            }

            UpdateWebcalCalendar newRecord = new UpdateWebcalCalendar()
            {

                CalendarName = CalendarName,
                ExternalSource = ExternalSource,
                Owner = new Relationship<SimpleCoreAdministrativeUserLink>()
                {
                    Data = new SimpleCoreAdministrativeUserLink()
                    {
                        ID = Owner.ID
                    }
                }
            };

            var response = SentralApiClient.WebCal.CreateWebcalCalendar(newRecord);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
