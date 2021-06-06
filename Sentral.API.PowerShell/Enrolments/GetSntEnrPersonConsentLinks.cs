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
    [Cmdlet(VerbsCommon.Get,"SntEnrPersonGivenConsentLinks", DefaultParameterSetName = _singularParamSet)]
    [OutputType(typeof(ConsentLink))]
    public class GetSntEnrPersonGivenConsentLinks : SentralPSCmdlet
    {
        private const string _singularParamSet = "Singular";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _singularParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int? PersonId { get; set; }


        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeConsent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeConsentedBy { get; set; }


        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void ProcessRecord()
        {
            ProcessParamsSingular();
        }
        private void ProcessParamsSingular()
        {
            WriteObject(
                    SentralApiClient.Enrolments.GetPersonGivenConsentLinks(PersonId.Value, GetIncludeOptions())
                );
        }

        private List<PersonConsentIncludeOptions> GetIncludeOptions()
        {
            List<PersonConsentIncludeOptions> include = new List<PersonConsentIncludeOptions>();

            if (IncludePerson.IsPresent)
            {
                include.Add(PersonConsentIncludeOptions.Person);
            }
            if (IncludeConsent.IsPresent)
            {
                include.Add(PersonConsentIncludeOptions.Consent);
            }
            if (IncludeConsentedBy.IsPresent)
            {
                include.Add(PersonConsentIncludeOptions.ConsentedBy);
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
