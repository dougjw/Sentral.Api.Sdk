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
    [Cmdlet(VerbsCommon.Get,"SntEnrPerson", DefaultParameterSetName = _singularPersonIdParamSet)]
    [OutputType(typeof(Person))]
    public class GetSntEnrPerson : SentralPSCmdlet
    {
        private const string _singularPersonIdParamSet = "SingularPersonId";
        private const string _singularStudentIdParamSet = "SingularIdStudentId";
        private const string _singularContactCodeParamSet = "SingularContactCode";
        private const string _multipleParamSet = "Multiple";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularPersonIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularStudentIdParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularContactCodeParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public string ContactCode { get; set; }



        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public int[] PersonIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] RefIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] ContactCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string[] ExternalIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string FirstName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public string LastName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = _multipleParamSet)]
        public bool Inactive { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePrimaryHousehold { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudentPrimaryEnrolment { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStaff { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeContactDetails { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeOtherHouseholds { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudentContacts { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeStudentTenants { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePrescribedMedication { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeEmails { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePhoneNumbers { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeGivenConsents { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeGivenConsentLinks { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeEmergencyContactLinks { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeAbilities { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeAdditionalFields { get; set; }




        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {

            switch (ParameterSetName)
            {
                case _singularPersonIdParamSet:
                    ProcessParamsSingularPersonId();
                    break;
                case _singularStudentIdParamSet:
                    ProcessParamsSingularStudentId();
                    break;
                case _singularContactCodeParamSet:
                    ProcessParamsSingularContactCode();
                    break;
                case _multipleParamSet:
                default:
                    ProcessParamsMultiple();
                    break;
            }
        }

        private void ProcessParamsSingularPersonId()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPerson(PersonId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsSingularStudentId()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetStudentPerson(StudentId.Value, GetIncludeOptions())
                );
        }
        private void ProcessParamsSingularContactCode()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPersonByCode(ContactCode, GetIncludeOptions())
                );
        }
        private void ProcessParamsMultiple()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPerson(GetIncludeOptions(), PersonIds, RefIds, ContactCodes, ExternalIds,
                        FirstName, LastName, Inactive)
                );
        }

        private List<PersonIncludeOptions> GetIncludeOptions()
        {
            List<PersonIncludeOptions> include = new List<PersonIncludeOptions>();


            if (IncludePrimaryHousehold.IsPresent)
            {
                include.Add(PersonIncludeOptions.PrimaryHousehold);
            }
            if (IncludeStudentPrimaryEnrolment.IsPresent)
            {
                include.Add(PersonIncludeOptions.StudentPrimaryEnrolment);
            }
            if (IncludeStaff.IsPresent)
            {
                include.Add(PersonIncludeOptions.Staff);
            }
            if (IncludeStudent.IsPresent)
            {
                include.Add(PersonIncludeOptions.Student);
            }
            if (IncludeContactDetails.IsPresent)
            {
                include.Add(PersonIncludeOptions.ContactDetails);
            }
            if (IncludeOtherHouseholds.IsPresent)
            {
                include.Add(PersonIncludeOptions.OtherHouseholds);
            }
            if (IncludeStudentContacts.IsPresent)
            {
                include.Add(PersonIncludeOptions.StudentContacts);
            }
            if (IncludeStudentTenants.IsPresent)
            {
                include.Add(PersonIncludeOptions.StudentTenants);
            }
            if (IncludePrescribedMedication.IsPresent)
            {
                include.Add(PersonIncludeOptions.PrescribedMedication);
            }
            if (IncludeEmails.IsPresent)
            {
                include.Add(PersonIncludeOptions.Emails);
            }
            if (IncludePhoneNumbers.IsPresent)
            {
                include.Add(PersonIncludeOptions.PhoneNumbers);
            }
            if (IncludeGivenConsents.IsPresent)
            {
                include.Add(PersonIncludeOptions.GivenConsents);
            }
            if (IncludeGivenConsentLinks.IsPresent)
            {
                include.Add(PersonIncludeOptions.GivenConsentLinks);
            }
            if (IncludeEmergencyContactLinks.IsPresent)
            {
                include.Add(PersonIncludeOptions.EmergencyContactLinks);
            }
            if (IncludeAbilities.IsPresent)
            {
                include.Add(PersonIncludeOptions.AdditionalFields);
            }
            if (IncludeAdditionalFields.IsPresent)
            {
                include.Add(PersonIncludeOptions.AdditionalFields);
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
