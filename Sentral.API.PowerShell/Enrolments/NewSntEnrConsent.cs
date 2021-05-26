using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.New,"SntEnrConsent")]
    [OutputType(typeof(Consent))]
    public class NewSntEnrConsent : SentralPSCmdlet
    {
                  
        [Parameter(Mandatory = true)]
        public string ConsentType { get; set; }

        [Parameter(Mandatory = true)]
        public string Details { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }
        
        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateConsent consent = new UpdateConsent()
            {

                Details = Details,
                ConsentType = ConsentType
            };

            // Populate from student object if object was used.
 

            var response = SentralApiClient.Enrolments.CreateConsent(consent);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
