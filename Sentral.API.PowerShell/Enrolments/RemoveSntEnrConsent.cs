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
    [Cmdlet(VerbsCommon.Remove , "SntEnrConsent")]
    public class RemoveSntEnrConsent : SentralPSCmdlet
    {
        private const string _idParamSet = "Id";
        private const string _objectParamSet = "Object";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _idParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int ConsentId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = _objectParamSet)]
        public Consent Consent { get; set; }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }


        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            switch (ParameterSetName)
            {
                case _idParamSet:
                    ProcessParamsId();
                    break;
                case _objectParamSet:
                    ProcessParamsObject();
                    break;
            }
            
        }

        private int GetObjectId()
        {
            if(Consent != null)
            {
                return Consent.ID;
            }

            return 0;
        }


        private void ProcessParamsId()
        {
            SentralApiClient.Enrolments.DeleteConsent(ConsentId);
        }
        private void ProcessParamsObject()
        {
            SentralApiClient.Enrolments.DeleteConsent(GetObjectId());
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
