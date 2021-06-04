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
    [Cmdlet(VerbsCommon.Get,"SntEnrStudent", DefaultParameterSetName = _singularStudentIdParamSet)]
    [OutputType(typeof(Student))]
    public class GetSntEnrStudent : SentralPSCmdlet
    {
        private const string _singularStudentIdParamSet = "SingularStudentId";
        private const string _singularContactIdParamSet = "SingularContactId";
        private const string _singularHouseholdIdParamSet = "SingularHouseholdId";
        private const string _singularPersonIdParamSet = "SingularPersonId";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularContactIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentContactId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularHouseholdIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentHouseholdId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularPersonIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = _singularPersonIdParamSet)]
        public SwitchParameter WithPortalAccess { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ParameterSetName = _singularPersonIdParamSet)]
        public SwitchParameter WithPastEnrolment { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = false,
            ParameterSetName = _singularPersonIdParamSet)]
        public SwitchParameter WithCurrentEnrolment { get; set; }


        [Parameter(
            Position = 4,
            Mandatory = false,
            ParameterSetName = _singularPersonIdParamSet)]
        public SwitchParameter WithFutureEnrolment { get; set; }

        [Parameter(
            Position = 5,
            Mandatory = false,
            ParameterSetName = _singularPersonIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public SwitchParameter WithOtherEnrolment { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] StudentIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] StudentCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] ExamCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] RefIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] ContactCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] ExternalIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
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
            switch (ParameterSetName)
            {
                case _singularStudentIdParamSet:
                    ProcessParamsStudentIdSingular();
                    break;
                case _singularContactIdParamSet:
                    ProcessParamsContactIdSingular();
                    break;
                case _singularHouseholdIdParamSet:
                    ProcessParamsHouseholdIdSingular();
                    break;
                case _singularPersonIdParamSet:
                    ProcessParamsPersonIdSingular();
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
                    SentralApiClient.Enrolments.GetStudent(StudentId.Value, GetIncludeOptions())
                );
        }

        private void ProcessParamsContactIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentContactStudent(StudentContactId.Value, GetIncludeOptions())
                );
        }

        private void ProcessParamsHouseholdIdSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentHouseholdStudents(StudentHouseholdId.Value, GetIncludeOptions())
                );
        }

        private void ProcessParamsPersonIdSingular()
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

        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudent(GetIncludeOptions(), StudentIds, StudentCodes, ExamCodes, RefIds,
                        ContactCodes, ExternalIds, AcademicPeriodIds)
                );
        }

        private List<StudentIncludeOptions> GetIncludeOptions()
        {
            List<StudentIncludeOptions> include = new List<StudentIncludeOptions>();

            if (IncludePrimaryEnrolment.IsPresent)
            {
                include.Add(StudentIncludeOptions.PrimaryEnrolment);
            }
            if (IncludePerson.IsPresent)
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
