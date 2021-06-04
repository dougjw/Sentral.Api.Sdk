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
    [Cmdlet(VerbsCommon.Get,"SntEnrSpecialNeedsProgram", DefaultParameterSetName = _singularSpecialNeedsIdParamSet)]
    [OutputType(typeof(SpecialNeedsProgram))]
    public class GetSntEnrSpecialNeedsProgram : SentralPSCmdlet
    {
        private const string _singularSpecialNeedsIdParamSet = "SingularSpecialNeedsId";
        private const string _singularStudentIdParamSet = "SingularStudentId";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularSpecialNeedsIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? SpecialNeedsProgramId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] SpecialNeedsProgramIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] StudentIds { get; set; }
        


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudents { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {

            switch (ParameterSetName)
            {
                case _singularSpecialNeedsIdParamSet:
                    ProcessParamsSpecialNeedsIdSingular();
                    break;
                case _singularStudentIdParamSet:
                    ProcessParamsStudentIdSingular();
                    break;
                case _multipleParamSet:
                default:
                    ProcessParamsMultiple();
                    break;
            }

        }
        private void ProcessParamsSpecialNeedsIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetSpecialNeedsProgram(SpecialNeedsProgramId.Value, GetIncludeOptions())
                );
        }

        private void ProcessParamsStudentIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentSpecialNeedsProgram(StudentId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetSpecialNeedsProgram(GetIncludeOptions(), SpecialNeedsProgramIds, StudentIds)
                );
        }

        private List<SpecialNeedsProgramIncludeOptions> GetIncludeOptions()
        {
            List<SpecialNeedsProgramIncludeOptions> include = new List<SpecialNeedsProgramIncludeOptions>();
            if (IncludeStudents.IsPresent)
            {
                include.Add(SpecialNeedsProgramIncludeOptions.Students);
            }

            return include;
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
