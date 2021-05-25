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
    [Cmdlet(VerbsCommon.Get, "SntEnrConsentLink")]
    [OutputType(typeof(ConsentLink))]
    [CmdletBinding(DefaultParameterSetName = "Singular")]
    public class GetSntEnrConsentLink : SentralPSCmdlet
    {

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "Singular")]
        [ValidateRange(1, int.MaxValue)]
        public int? ConsentLinkId { get; set; }


        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] ConsentLinkIds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public int[] PersonIds { get; set; }
        [Parameter(Mandatory = false, ParameterSetName = "Multiple")]
        public bool? IncludeInactive { get; set; }



        [Parameter(Mandatory = false)]
        public SwitchParameter IncludePerson { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeConsent { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter IncludeConsentedBy { get; set; }





        //bool person = false, bool consent = false, bool consentedBy = false
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
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

            // Singular mode chosen
            if (ConsentLinkId.HasValue && ConsentLinkId.Value > 0)
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonConsentLink(ConsentLinkId.Value, include)
                    );
            }
            // Multiple mode chosen
            else
            {
                WriteObject(
                        SentralApiClient.Enrolments.GetPersonConsentLink(include, ConsentLinkIds, PersonIds, IncludeInactive)
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
