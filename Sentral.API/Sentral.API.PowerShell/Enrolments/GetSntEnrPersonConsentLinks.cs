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
    [Cmdlet(VerbsCommon.Get,"SntEnrPersonGivenConsentLinks")]
    [OutputType(typeof(ConsentLink))]
    public class GetSntEnrPersonGivenConsentLinks : SentralPSCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "SingularId")]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeConsent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeConsentedBy { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            PersonConsentIncludeOptions include = new PersonConsentIncludeOptions(
                        IncludePerson.IsPresent,
                        IncludeConsent.IsPresent,
                        IncludeConsentedBy.IsPresent
                   );


            // Singular mode chosen
            if (PersonId.HasValue && PersonId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonGivenConsentLinks(PersonId.Value, include)
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
