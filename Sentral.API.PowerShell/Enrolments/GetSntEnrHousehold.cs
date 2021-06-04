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
    [Cmdlet(VerbsCommon.Get, "SntEnrHousehold", DefaultParameterSetName = _singularHouseholdIdParamSet)]
    [OutputType(typeof(Household))]
    public class GetSntEnrHousehold : SentralPSCmdlet
    {
        private const string _singularHouseholdIdParamSet = "SingularHouseholdId";
        private const string _singularStudentHouseholdIdParamSet = "SingularStudendHouseholdId";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = _singularHouseholdIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? HouseholdId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = _singularStudentHouseholdIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentHouseholdId { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularHouseholdIdParamSet:
                    ProcessParamsHouseholdId();
                    break;
                case _singularStudentHouseholdIdParamSet:
                    ProcessParamsStudentHouseholdId();
                    break;
                default:
                    ProcessParamsMultiple();
                    break;
            }
        }

        private void ProcessParamsHouseholdId()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetHousehold(HouseholdId.Value)
                );
        }
        private void ProcessParamsStudentHouseholdId()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentHouseholdDetails(StudentHouseholdId.Value)
                );
        }
        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetHousehold()
                );
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
