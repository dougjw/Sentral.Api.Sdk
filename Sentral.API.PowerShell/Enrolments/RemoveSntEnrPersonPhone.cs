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
    [Cmdlet(VerbsCommon.Remove , "SntEnrPersonPhone")]
    public class RemoveSntEnrPersonPhone : SentralPSCmdlet
    {
        
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName ="PersonPhoneId")]
        [ValidateRange(1, int.MaxValue)]
        public int PersonPhoneId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "PersonPhoneObject")]
        [ValidateRange(1, int.MaxValue)]
        public PersonPhone PersonPhone { get; set; }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }


        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            int personPhoneId = GetId();
            
            SentralApiClient.Enrolments.DeletePersonPhone(personPhoneId);
        }

        private int GetId()
        {
            if (PersonPhoneId > 0)
            {
                return PersonPhoneId;
            }
            if(PersonPhone != null)
            {
                return PersonPhone.ID;
            }

            return 0;
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
