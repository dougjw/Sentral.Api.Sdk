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
    [Cmdlet(VerbsCommon.Get,"SntEnrSchoolHistory", DefaultParameterSetName = "Singular")]
    [OutputType(typeof(StudentHistory))]
    public class GetSntEnrSchoolHistory : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? SchoolHistoryId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Multiple")]
        [ValidateRange(1, int.MaxValue)]
        public int[] SchoolHistoryIds { get; set; }


        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = "Multiple")]
        [ValidateRange(1, int.MaxValue)]
        public int[] StudentIds { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            // Singular mode chosen
            if(SchoolHistoryId.HasValue && SchoolHistoryId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentSchoolHistory(SchoolHistoryId.Value)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentSchoolHistory(SchoolHistoryIds, StudentIds)
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
