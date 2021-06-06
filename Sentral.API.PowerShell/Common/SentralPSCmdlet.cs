using Sentral.API.Client;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Sentral.API.PowerShell.Common
{
    public class SentralPSCmdlet : PSCmdlet
    {
        protected SentralApi SentralApiClient { get; private set; }
        protected const string TimePattern = "^([01][0-9]|2[0-3])(:[0-5][0-9]){2}$";

        public SentralPSCmdlet()
        {
            SentralApiClient = ConnectSentralApi.GetSentralAPIConnection();
        }

    }
}
