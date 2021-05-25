﻿using System;
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
    [OutputType(typeof(Consent))]
    public class RemoveSntEnrConsent : SentralPSCmdlet
    {
        
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
        [ValidateRange(1, int.MaxValue)]
        public Consent Consent { get; set; }
        
        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
        }


        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
            int consentId = GetConsentId();
            
            SentralApiClient.Enrolments.DeleteConsent(consentId);
        }

        private int GetConsentId()
        {
            if (ConsentId > 0)
            {
                return ConsentId;
            }
            if(Consent != null)
            {
                return Consent.ID;
            }

            return 0;
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }
    }
}