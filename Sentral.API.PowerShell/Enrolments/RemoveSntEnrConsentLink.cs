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
    [Cmdlet(VerbsCommon.Remove , "SntEnrConsentLink")]
    public class RemoveSntEnrConsentLink : SentralPSCmdlet
    {
        private const string _idParamSet = "Id";
        private const string _objectParamSet = "Object";


        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = _idParamSet)]
        [ValidateRange(1, int.MaxValue)]
        public int ConsentLinkId { get; set; }


        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = _objectParamSet)]
        public ConsentLink ConsentLink { get; set; }
        
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

        private void ProcessParamsId()
        {
            SentralApiClient.Enrolments.DeletePersonConsentLink(ConsentLinkId);
        }
        private void ProcessParamsObject()
        {
            SentralApiClient.Enrolments.DeletePersonConsentLink(GetObjectId());
        }

        private int GetObjectId()
        {
            if(ConsentLink != null)
            {
                return ConsentLink.ID;
            }
            return 0;
        }



        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}
