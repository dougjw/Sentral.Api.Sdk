﻿using Sentral.API.Client;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Sentral.API.PowerShell.Common
{
    public class SentralPSCmdlet : Cmdlet
    {
        protected SentralApi SentralApiClient { get; private set; }

        public SentralPSCmdlet()
        {
            SentralApiClient = ConnectSentralApi.GetSentralAPIConnection();
        }
    }
}
