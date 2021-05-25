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
    [Cmdlet(VerbsCommon.Get,"SntEnrPersonStudent")]
    [OutputType(typeof(Student))]
    [CmdletBinding(DefaultParameterSetName = "Singular")]
    public class GetSntEnrPersonStudent : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        // bool person = false, bool qualifications = false, bool employments = false



        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePrimaryEnrolment { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeActivities { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeActivityInstances { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeTenants { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeFlags { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeFlagLinks { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeContacts { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeHolidays { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeSpecialNeedsPrograms { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeSchoolHistory { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            List<StudentIncludeOptions> include = new List<StudentIncludeOptions>();

            if(IncludePrimaryEnrolment.IsPresent)
            {
                include.Add(StudentIncludeOptions.PrimaryEnrolment);
            }
            if(IncludePerson.IsPresent)
            {
                include.Add(StudentIncludeOptions.Person);
            }
            if (IncludeActivities.IsPresent)
            {
                include.Add(StudentIncludeOptions.Activities);
            }
            if (IncludeActivityInstances.IsPresent)
            {
                include.Add(StudentIncludeOptions.ActivityInstances);
            }
            if (IncludeTenants.IsPresent)
            {
                include.Add(StudentIncludeOptions.Tenants);
            }
            if (IncludeFlags.IsPresent)
            {
                include.Add(StudentIncludeOptions.Flags);
            }
            if (IncludeFlagLinks.IsPresent)
            {
                include.Add(StudentIncludeOptions.FlagLinks);
            }
            if (IncludeContacts.IsPresent)
            {
                include.Add(StudentIncludeOptions.Contacts);
            }
            if (IncludeHolidays.IsPresent)
            {
                include.Add(StudentIncludeOptions.Holidays);

            }
            if (IncludeSpecialNeedsPrograms.IsPresent)
            {
                include.Add(StudentIncludeOptions.SpecialNeedsPrograms);
            }
            if (IncludeSchoolHistory.IsPresent)
            {
                include.Add(StudentIncludeOptions.SchoolHistory);
            }
            // Singular mode chosen
            if (PersonId.HasValue && PersonId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonStudent(PersonId.Value, include)
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
