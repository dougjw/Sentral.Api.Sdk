using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using System.Collections.Generic;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Get,"SntEnrSpecialNeedsProgram", DefaultParameterSetName = "Singular")]
    [OutputType(typeof(SpecialNeedsProgram))]
    public class GetSntEnrSpecialNeedsProgram : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularSpecialNeedsId")]
        [ValidateRange(1, int.MaxValue)]
        public int? SpecialNeedsProgramId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularStudentId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] SpecialNeedsProgramIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] StudentIds { get; set; }
        


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudents { get; set; }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            List<SpecialNeedsProgramIncludeOptions> include = new List<SpecialNeedsProgramIncludeOptions>();
            if (IncludeStudents.IsPresent)
            {
                include.Add(SpecialNeedsProgramIncludeOptions.Students);
            }

            // Singular mode chosen
            if(SpecialNeedsProgramId.HasValue && SpecialNeedsProgramId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetSpecialNeedsProgram(SpecialNeedsProgramId.Value, include)
                    );
            }
            // Singular mode chosen
            else if (StudentId.HasValue && StudentId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentSpecialNeedsProgram(StudentId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetSpecialNeedsProgram(include, SpecialNeedsProgramIds, StudentIds)
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
