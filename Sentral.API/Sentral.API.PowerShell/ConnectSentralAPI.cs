using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Sentral.API.Client;

namespace Sentral.API.PowerShell
{
    [Cmdlet(VerbsCommunications.Connect,"SentralApi")]
    // [OutputType(typeof(FavoriteStuff))]
    public class ConnectSentralApi : PSCmdlet
    {
        private static SentralApi _connection;

        [Parameter(
            Position = 0,
            Mandatory = true)]
        [ValidatePattern("^https://.*/restapi$")]
        public string BaseUrl { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true)]
        [ValidatePattern("^[A-z0-9]{6}$")]
        public string TenantCode { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true)]
        [ValidatePattern("^[a-z0-9]{32}$")]
        public string ApiKey { private get; set; }

        // This method gets called once for each cmdlet in the pipeline when the pipeline starts executing
        protected override void BeginProcessing()
        {
            _connection = new SentralApi(BaseUrl, ApiKey, TenantCode);
        }

        // This method will be called for each input received from the pipeline to this cmdlet; if no input is received, this method is not called
        protected override void ProcessRecord()
        {
        }

        // This method will be called once at the end of pipeline execution; if no input is received, this method is not called
        protected override void EndProcessing()
        {
        }

        public static SentralApi GetSentralAPIConnection()
        {
            if(_connection == null)
            {
                throw new Exceptions.SentralApiConnectionException("Run 'Connect-SentralApi' before running this Commandlet");
            }
            return _connection;
        }
    }
}
