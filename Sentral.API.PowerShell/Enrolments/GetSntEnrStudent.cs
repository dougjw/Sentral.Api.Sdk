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
    [Cmdlet(VerbsCommon.Get,"SntEnrStudent", DefaultParameterSetName = "SingularStudentId")]
    [OutputType(typeof(Student))]
    public class GetSntEnrStudent : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularStudentId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularStudentContactId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentContactId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularStudentHouseholdId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentHouseholdId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularPersonId")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = "SingularPersonId")]
        public SwitchParameter WithPortalAccess { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ParameterSetName = "SingularPersonId")]
        public SwitchParameter WithPastEnrolment { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = false,
            ParameterSetName = "SingularPersonId")]
        public SwitchParameter WithCurrentEnrolment { get; set; }


        [Parameter(
            Position = 4,
            Mandatory = false,
            ParameterSetName = "SingularPersonId")]
        public SwitchParameter WithFutureEnrolment { get; set; }

        [Parameter(
            Position = 5,
            Mandatory = false,
            ParameterSetName = "SingularPersonId")]
        [ValidateRange(1, int.MaxValue)]
        public SwitchParameter WithOtherEnrolment { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] StudentIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] StudentCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] ExamCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] RefIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] ContactCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] ExternalIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] AcademicPeriodIds { get; set; }



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
        protected override void ProcessRecord()
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

            // Singular mode Student ID chosen
            if (StudentId.HasValue && StudentId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudent(StudentId.Value, include)
                    );
            }
            // Singular mode Student Contact ID chosen
            else if (StudentContactId.HasValue && StudentContactId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentContactStudent(StudentContactId.Value, include)
                    );
            }

            // Singular mode Student Household ID chosen
            else if (StudentHouseholdId.HasValue && StudentHouseholdId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudentHouseholdStudents(StudentHouseholdId.Value, include)
                    );
            }
            // Singular mode, Person ID chosen
            else if (PersonId.HasValue && PersonId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonAssociatedStudentsByPersonId(
                            PersonId.Value,
                            WithPortalAccess.IsPresent,
                            WithPastEnrolment.IsPresent,
                            WithCurrentEnrolment.IsPresent,
                            WithFutureEnrolment.IsPresent,
                            WithOtherEnrolment.IsPresent
                        )
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetStudent(include, StudentIds, StudentCodes, ExamCodes, RefIds,
                            ContactCodes, ExternalIds, AcademicPeriodIds)
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
