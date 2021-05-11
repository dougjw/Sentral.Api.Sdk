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
    [Cmdlet(VerbsCommon.Get,"SntEnrYearLevel")]
    [OutputType(typeof(Tenant))]
    public class GetSntEnrYearLevel : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? YearLevelId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Multiple")]
        [ValidateRange(1, int.MaxValue)]
        public int[] YearLevelIds { get; set; }


        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = "Multiple")]
        [ValidateRange(1, int.MaxValue)]
        public int[] SchoolIds { get; set; }



        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            // Singular mode chosen
            if(YearLevelId.HasValue && YearLevelId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetYearLevel(YearLevelId.Value)
                    );
            }
            else 
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetYearLevel(YearLevelIds, SchoolIds)
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
