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
    [Cmdlet(VerbsCommon.Set,"SntEnrPersonEmail")]
    [OutputType(typeof(PersonEmail))]
    public class SetSntEnrPersonEmail : SentralPSCmdlet
    {
        private string _emailType;
        private string _email;

        private bool _emailTypeProvided;
        private bool _emailProvided;


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "PersonEmailId")]
        [ValidateRange(1, int.MaxValue)]
        public int PersonEmailId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "PersonEmailObject")]
        public PersonEmail PersonEmail { get; set; }

        [Parameter(Mandatory = false)]
        public string EmailType
        {
            get
            {
                return _emailType;
            }
            set
            {
                _emailType = value;
                _emailTypeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                _emailProvided = true;
            }

        }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdatePersonEmail GetInitUpdateModel()
        {

            if (PersonEmail != null)
            {
                return new UpdatePersonEmail(PersonEmail.ID);
            }
            return new UpdatePersonEmail(PersonEmailId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdatePersonEmail personEmail = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_emailProvided)
            {
                personEmail.Email = _email;
            };
            if (_emailTypeProvided)
            {
                personEmail.EmailType = _emailType;
            }

            var response = SentralApiClient.Enrolments.UpdatePersonEmail(personEmail);

            WriteObject(response);
        }


        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
