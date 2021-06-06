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
    [Cmdlet(VerbsCommon.Get,"SntEnrEnrolment", DefaultParameterSetName = _singularEnrolmentIdParamSet)]
    [OutputType(typeof(Enrolment))]
    public class GetSntEnrEnrolment : SentralPSCmdlet
    {
        private const string _singularEnrolmentIdParamSet = "SingularEnrolmentId";
        private const string _singularStudentIdParamSet = "SingularStudentId";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularEnrolmentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]

        public int? EnrolmentId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]

        public int? StudentId { get; set; }
        

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] EnrolmentIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] StudentIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] RollclassIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] YearLevelIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] HouseIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] Statuses { get; set; }


       
        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeHouse { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeRollclass { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeClasses { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeCampus { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularEnrolmentIdParamSet:
                    ProcessParamsEnrolmentIdSingular();
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

        private void ProcessParamsEnrolmentIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetEnrolment(EnrolmentId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsStudentIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentPrimaryEnrolment(StudentId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetEnrolment(GetIncludeOptions(), EnrolmentIds, StudentIds, RollclassIds, YearLevelIds,
                        HouseIds, Statuses)
                );
        }

        private List<EnrolmentIncludeOptions> GetIncludeOptions()
        {
            List<EnrolmentIncludeOptions> include = new List<EnrolmentIncludeOptions>();

            if (IncludeStudent.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Student);
            }

            if (IncludeHouse.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.House);
            }

            if (IncludeRollclass.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Rollclass);
            }

            if (IncludeClasses.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Classes);
            }

            if (IncludeCampus.IsPresent)
            {
                include.Add(EnrolmentIncludeOptions.Campus);
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
