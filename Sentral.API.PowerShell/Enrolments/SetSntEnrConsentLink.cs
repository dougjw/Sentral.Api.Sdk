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
    [Cmdlet(VerbsCommon.Set,"SntEnrConsentLink")]
    [OutputType(typeof(ConsentLink))]
    public class SetSntEnrConsentLink : SentralPSCmdlet
    {

        private bool _consentGiven;
        private Person _consentedBy;

        private bool _consentGivenProvided;
        private bool _consentedByProvided;


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "ConsentLinkId")]
        [ValidateRange(1, int.MaxValue)]
        public int ConsentLinkId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "ConsentLinkObject")]
        public ConsentLink ConsentLink { get; set; }

        [Parameter(Mandatory = false)]
        public bool ConsentGiven
        {
            get
            {
                return _consentGiven;
            }
            set
            {
                _consentGiven = value;
                _consentGivenProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
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

        private UpdatePersonConsentLink GetInitUpdateModel()
        {

            if (ConsentLink != null)
            {
                return new UpdatePersonConsentLink(ConsentLink.ID);
            }
            return new UpdatePersonConsentLink(ConsentLinkId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdatePersonConsentLink consentLink = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_consentedByProvided)
            {

                consentLink.ConsentedBy = new Relationship<SimplePersonLink>();
                if (_consentedBy != null)
                {
                    consentLink.ConsentedBy.Data = new SimplePersonLink() { ID = _consentedBy.ID };
                }
            }
            if (_consentGivenProvided)
            {
                consentLink.ConsentGiven = _consentGiven;
            }

            var response = SentralApiClient.Enrolments.UpdatePersonConsentLink(consentLink);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
