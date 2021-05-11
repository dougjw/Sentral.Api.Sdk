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
    [Cmdlet(VerbsCommon.Get,"SntEnrSchool")]
    [OutputType(typeof(School))]
    public class GetSntEnrSchool : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? SchoolId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeTenant { get; set; }
        

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            SchoolIncludeOptions include = new SchoolIncludeOptions(
                    IncludeTenant.IsPresent
            );

            // Singular mode chosen
            if(SchoolId.HasValue && SchoolId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetSchool(SchoolId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetSchool(include)
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
