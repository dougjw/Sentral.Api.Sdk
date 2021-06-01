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
    [Cmdlet(VerbsCommon.Get, "SntEnrHouseholdAddress", DefaultParameterSetName = "Singular")]
    [OutputType(typeof(Address))]
    public class GetSntEnrHouseholdAddress : SentralPSCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? HouseholdAddressId { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {

            // Singular mode chosen
            if (HouseholdAddressId.HasValue && HouseholdAddressId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetHouseholdAddress(HouseholdAddressId.Value)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetHouseholdAddress()
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
