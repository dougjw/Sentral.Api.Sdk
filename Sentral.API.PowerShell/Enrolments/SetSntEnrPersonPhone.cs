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
    [Cmdlet(VerbsCommon.Set,"SntEnrPersonPhone")]
    [OutputType(typeof(PersonPhone))]
    public class SetSntEnrPersonPhone : SentralPSCmdlet
    {

        private string _phoneType;
        private string _number;
        private string _extension;
        private bool _canContact;
        private bool _isListed;

        private bool _phoneTypeProvided;
        private bool _numberProvided;
        private bool _extensionProvided;
        private bool _canContactProvided;
        private bool _isListedProvided;

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = "PersonPhoneId")]
        [ValidateRange(1, int.MaxValue)]
        public int PersonPhoneId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "PersonPhoneObject")]
        public PersonPhone PersonPhone { get; set; }

        [Parameter(Mandatory = false)]
        public string PhoneType
        {
            get
            {
                return _phoneType;
            }
            set
            {
                _phoneType = value;
                _phoneTypeProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string Phone
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                _numberProvided = true;
            }

        }

        [Parameter(Mandatory = false)]
        public string Extension
        {
            get
            {
                return _extension;
            }
            set
            {
                _extension = value;
                _extensionProvided = true;
            }

        }


        [Parameter(Mandatory = false)]
        public bool CanContact
        {
            get
            {
                return _canContact;
            }
            set
            {
                _canContact = value;
                _canContactProvided = true;
            }
        }


        [Parameter(Mandatory = false)]
        public bool IsListed
        {
            get
            {
                return _isListed;
            }
            set
            {
                _isListed = value;
                _isListedProvided = true;
            }
        }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }

        private UpdatePersonPhone GetInitUpdateModel()
        {

            if (PersonPhone != null)
            {
                return new UpdatePersonPhone(PersonPhone.ID);
            }
            return new UpdatePersonPhone(PersonPhoneId);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            UpdatePersonPhone personPhone = GetInitUpdateModel(); 

            // Populate from student object if object was used.
            if (_numberProvided)
            {
                personPhone.Number = _number;
            }
            if (_phoneTypeProvided)
            {
                personPhone.PhoneType = _phoneType;
            }
            if (_extensionProvided)
            {
                personPhone.Extension = _extension;
            }
            if (_isListedProvided)
            {
                personPhone.IsListed = _isListed;
            }
            if (_canContactProvided)
            {
                personPhone.CanContact = _canContact;
            }

            var response = SentralApiClient.Enrolments.UpdatePersonPhone(personPhone);

            WriteObject(response);
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
