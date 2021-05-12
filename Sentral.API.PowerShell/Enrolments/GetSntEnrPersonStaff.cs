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
    [Cmdlet(VerbsCommon.Get,"SntEnrPersonStaff")]
    [OutputType(typeof(Staff))]
    public class GetSntEnrPersonStaff : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularId")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        // bool person = false, bool qualifications = false, bool employments = false


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeQualification { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeEmployments { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            StaffIncludeOptions include = new StaffIncludeOptions(
                    IncludePerson.IsPresent,
                    IncludeQualification.IsPresent,
                    IncludeEmployments.IsPresent
                );

            // Singular mode chosen
            if(PersonId.HasValue && PersonId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonStaff(PersonId.Value, include)
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
