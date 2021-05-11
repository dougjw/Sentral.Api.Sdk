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
    [Cmdlet(VerbsCommon.Get,"SntEnrPerson")]
    [OutputType(typeof(Person))]
    public class GetSntEnrPerson : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularIdPersonId")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularIdStudentId")]
        [ValidateRange(1, int.MaxValue)]
        public int? StudentId { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularCode")]
        [ValidateRange(1, int.MaxValue)]
        public string ContactCode { get; set; }



        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] PersonIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] RefIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] ContactCodes { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string[] ExternalIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string FirstName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public string LastName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
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
        protected override void BeginProcessing()
        {
            PersonIncludeOptions include = new PersonIncludeOptions(
                    IncludePrimaryHousehold.IsPresent,
                    IncludeStudentPrimaryEnrolment.IsPresent,
                    IncludeStaff.IsPresent,
                    IncludeStudent.IsPresent,
                    IncludeContactDetails.IsPresent,
                    IncludeOtherHouseholds.IsPresent,
                    IncludeStudentContacts.IsPresent,
                    IncludeStudentTenants.IsPresent,
                    IncludePrescribedMedication.IsPresent,
                    IncludeEmails.IsPresent,
                    IncludePhoneNumbers.IsPresent,
                    IncludeGivenConsents.IsPresent,
                    IncludeGivenConsentLinks.IsPresent,
                    IncludeEmergencyContactLinks.IsPresent,
                    IncludeAbilities.IsPresent,
                    IncludeAdditionalFields.IsPresent
            );

            // Singular mode chosen
            if(PersonId.HasValue && PersonId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPerson(PersonId.Value, include)
                    );
            }
            else if(ContactCode != null)
            {

                WriteObject(
                        SentralApiClient.Enrolments.GetPersonByCode(ContactCode, include)
                    );
            }
            else if (StudentId.HasValue && StudentId.Value > 0)
            {

                WriteObject(
                        SentralApiClient.Enrolments.GetStudentPerson(StudentId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPerson(include, PersonIds, RefIds, ContactCodes, ExternalIds,
                            FirstName, LastName, Inactive)
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
