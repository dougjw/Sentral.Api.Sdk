using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.PowerShell;
using Sentral.API.Model.Enrolments;
using Sentral.API.PowerShell.Common;
using Sentral.API.Model.Enrolments.Update;

namespace Sentral.API.PowerShell.Enrolments
{
    [Cmdlet(VerbsCommon.Set,"SntEnrConsent")]
    [OutputType(typeof(Consent))]
    public class SetSntEnrConsent : SentralPSCmdlet
    {

        private string _consentType;
        private string _details;

        private bool _consentTypeProvided;
        private bool _detailsProvided;


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName ="ConsentId")]
        [ValidateRange(1, int.MaxValue)]
        public int ConsentId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Consent")]
        public Consent Consent { get; set; }

        [Parameter(Mandatory = false)]
        public string ConsentType
        {
            get
            {
                return _consentType;
            }
            set
            {
                _consentType = value;
                _consentTypeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
                _detailsProvided = true;
            }

        }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdateConsent GetInitUpdateStudent()
        {

            if (Consent != null)
            {
                return new UpdateConsent(Consent.ID);
            }
            return new UpdateConsent(ConsentId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdateConsent consent = GetInitUpdateStudent(); 

            // Populate from student object if object was used.
            if (_detailsProvided)
            {
                consent.Details = _details;
            };
            if (_consentTypeProvided)
            {
                consent.ConsentType = _consentType;
            }

            var response = SentralApiClient.Enrolments.UpdateConsent(consent);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
