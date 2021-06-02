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
    [Cmdlet(VerbsCommon.Get, "SntEnrHouseholdRelatedAddresses", DefaultParameterSetName = "Singular")]
    [OutputType(typeof(Address))]
    public class GetSntEnrHouseholdRelatedAddresses : SentralPSCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? HouseholdId { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {

            // Singular mode chosen
            if(HouseholdId.HasValue && HouseholdId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetHouseholdRelatedAddresses(HouseholdId.Value)
                    );
            }


        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void BeginProcessing()
        {
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
