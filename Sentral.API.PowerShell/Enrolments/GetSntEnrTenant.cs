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
    [Cmdlet(VerbsCommon.Get,"SntEnrSchoolTenant", DefaultParameterSetName = _singularSchoolIdParamSet)]
    [OutputType(typeof(Tenant))]
    public class GetSntEnrTenant : SentralPSCmdlet
    {
        private const string _singularSchoolIdParamSet = "SingularSchoolId";
        private const string _singularStudentIdParamSet = "SingularStudentId";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularSchoolIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? SchoolId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _singularSchoolIdParamSet:
                    ProcessParamsSchoolIdSingular();
                    break;
                case _singularStudentIdParamSet:
                    ProcessParamsStudentIdSingular();
                    break;
            }
        }
        private void ProcessParamsSchoolIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetSchoolTenant(SchoolId.Value)
                );
        }

        private void ProcessParamsStudentIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetSchoolTenant(SchoolId.Value)
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
