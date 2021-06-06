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
    [Cmdlet(VerbsCommon.Get,"SntEnrStudentFlagLinks", DefaultParameterSetName = _multipleParamSet)]
    [OutputType(typeof(StudentFlagLink))]
    public class GetSntEnrStudentFlagLinks : SentralPSCmdlet
    {
        private const string _singularStudentFlagIdParamSet = "SingularStudentFlagId";
        private const string _singularStudentIdParamSet = "SingularStudentId";
        private const string _multipleParamSet = "Multiple";


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = _singularStudentFlagIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentFlagId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeFlag { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularStudentFlagIdParamSet:
                    ProcessParamsStudentFlagIdSingular();
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

        private void ProcessParamsStudentIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentFlagLinkByStudentId(StudentId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsStudentFlagIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentFlagLink(StudentFlagId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentFlagLink(GetIncludeOptions())
                );
        }

        private List<StudentFlagLinkIncludeOptions> GetIncludeOptions()
        {
            List<StudentFlagLinkIncludeOptions> include = new List<StudentFlagLinkIncludeOptions>();

            if (IncludeStudent.IsPresent)
            {
                include.Add(StudentFlagLinkIncludeOptions.Student);
            }
            if (IncludeFlag.IsPresent)
            {
                include.Add(StudentFlagLinkIncludeOptions.Flag);
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
