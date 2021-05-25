using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Get, "SntEnrDisabilityOthers")]
    [OutputType(typeof(Disability))]
    [CmdletBinding(DefaultParameterSetName = "Singular")]
    public class GetSntEnrDisabilityOthers : SentralPSCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? DisabilityId { get; set; }


        
        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Multiple")]
        public int[] DisabilityIds { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Multiple")]
        public int[] PersonIds { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {

            // Singular mode chosen
            if(DisabilityId.HasValue && DisabilityId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetDisabilityOthers(DisabilityId.Value)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetDisabilityOthers(DisabilityIds, PersonIds)
                    );
            }
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
