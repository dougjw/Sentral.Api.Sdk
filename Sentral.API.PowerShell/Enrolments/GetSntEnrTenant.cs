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
    [Cmdlet(VerbsCommon.Get,"SntEnrSchoolTenant", DefaultParameterSetName = "SingularSchoolId")]
    [OutputType(typeof(Tenant))]
    public class GetSntEnrTenant : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularSchoolId")]
        [ValidateRange(1, int.MaxValue)]
        public int? SchoolId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularStudentId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            // Singular mode chosen
            if(SchoolId.HasValue && SchoolId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetSchoolTenant(SchoolId.Value)
                    );
            }
            // Singular mode chosen
            else if (StudentId.HasValue && StudentId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetSchoolTenant(SchoolId.Value)
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
