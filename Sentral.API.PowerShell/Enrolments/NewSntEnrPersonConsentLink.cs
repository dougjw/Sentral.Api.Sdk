using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;
using JsonApiSerializer.JsonApi;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.New,"SntEnrConsent")]
    [OutputType(typeof(Consent))]
    public class NewSntEnrConsentLink : SentralPSCmdlet
    {
        private Person _consentedBy;

        private bool _consentedByProvided;



        [Parameter(Mandatory = true)]
        public bool ConsentGiven { get; set; }


        [Parameter(Mandatory = true)]
        public Person Person { get; set; }


        [Parameter(Mandatory = true)]
        public Consent Consent { get; set; }

        [Parameter(Mandatory = true)]
        public Person ConsentedBy
        {
            get
            {
                return _consentedBy;
            }
            set
            {
                _consentedBy = value;
                _consentedByProvided = true;
            }
        }
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }
        
        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            var simpleConsent = new Relationship<SimpleConsentLink>()
            {
                Data = new SimpleConsentLink() { ID = Consent.ID }
            };


            var simplePerson = new Relationship<SimplePersonLink>()
            {
                Data = new SimplePersonLink() { ID = Person.ID }
            };

            UpdatePersonConsentLink consentLink = new UpdatePersonConsentLink()
            {
                ConsentGiven = ConsentGiven,
                Consent = simpleConsent,
                Person = simplePerson
            };



            if (_consentedByProvided && _consentedBy != null)
            {
                consentLink.ConsentedBy = new Relationship<SimplePersonLink>()
                {
                    Data = new SimplePersonLink() { ID = ConsentedBy.ID }
                };

            }



            // Populate from student object if object was used.
 

            var response = SentralApiClient.Enrolments.CreatePersonConsentLink(consentLink);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
