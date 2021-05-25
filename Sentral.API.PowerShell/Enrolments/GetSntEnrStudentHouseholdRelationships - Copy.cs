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
    [Cmdlet(VerbsCommon.Get, "SntEnrStudentHouseholdRelationship")]
    [OutputType(typeof(Flag))]
    public class GetSntEnrStudentHouseholdRelationship : SentralPSCmdlet
    {
        [Parameter(
          Position = 0,
          Mandatory = true,
          ParameterSetName = "SingularIdStudentHouseholdLinkId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentHouseholdLinkId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularIdStudentId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "SingularIdStudentId")]
        [ValidateRange(1, int.MaxValue)]
        public string[] ResidentialHouseholdTypes { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = "Multiple")]
        [ValidateRange(1, int.MaxValue)]
        public int[] StudentHouseholdLinkIds { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeHousehold { get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {

            List<StudentHouseholdRelationIncludeOptions> include = new List<StudentHouseholdRelationIncludeOptions>();
            if(IncludeStudent.IsPresent)
            {
                include.Add(StudentHouseholdRelationIncludeOptions.Student);
            }
            if(IncludeHousehold.IsPresent)
            {
                include.Add(StudentHouseholdRelationIncludeOptions.Household);
            }

            // Singular mode chosen
            if (StudentHouseholdLinkId.HasValue && StudentHouseholdLinkId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentHouseholdRelationship(StudentHouseholdLinkId.Value, include)
                    );
            }
            else if (StudentId.HasValue && StudentId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentHouseholdRelationshisByStudentId(StudentId.Value, include, ResidentialHouseholdTypes)
                    );
            }
            else
            {
                SentralApiClient.Enrolments.GetStudentHouseholdRelationship(include, StudentHouseholdLinkIds);
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
