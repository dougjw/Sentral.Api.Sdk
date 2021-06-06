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
    [Cmdlet(VerbsCommon.Get, "SntEnrStudentHouseholdRelationship", DefaultParameterSetName = "SingularStudentHouseholdLinkId")]
    [OutputType(typeof(Flag))]
    public class GetSntEnrStudentHouseholdRelationship : SentralPSCmdlet
    {
        private const string _singularStudentHouseholdLinkIdParamSet = "SingularStudentHouseholdLinkId";
        private const string _singularStudentIdParamSet = "SingularStudentId";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
          Position = 0,
          Mandatory = true,
          ParameterSetName = _singularStudentHouseholdLinkIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentHouseholdLinkId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public string[] ResidentialHouseholdTypes { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = _multipleParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int[] StudentHouseholdLinkIds { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeHousehold { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularStudentHouseholdLinkIdParamSet:
                    ProcessParamsHouseholdLinkIdSingular();
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
        private void ProcessParamsHouseholdLinkIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentHouseholdRelationship(StudentHouseholdLinkId.Value, GetIncludeOptions())
                );
        }

        private void ProcessParamsStudentIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentHouseholdRelationshisByStudentId(StudentId.Value, GetIncludeOptions(), ResidentialHouseholdTypes)
                );
        }
        private void ProcessParamsMultiple()
        {
            SentralApiClient.Enrolments.GetStudentHouseholdRelationship(GetIncludeOptions(), StudentHouseholdLinkIds);
        }

        private List<StudentHouseholdRelationIncludeOptions> GetIncludeOptions()
        {
            List<StudentHouseholdRelationIncludeOptions> include = new List<StudentHouseholdRelationIncludeOptions>();
            if (IncludeStudent.IsPresent)
            {
                include.Add(StudentHouseholdRelationIncludeOptions.Student);
            }
            if (IncludeHousehold.IsPresent)
            {
                include.Add(StudentHouseholdRelationIncludeOptions.Household);
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
