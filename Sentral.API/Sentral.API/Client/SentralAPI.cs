using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.Client.ActionNamespace;

namespace Sentral.API.Client
{
    public class SentralAPI
    {
        public EnrolmentAPI Enrolments { get; }
        public SentralAPI (string baseUrl, string apiKey, string tenantCode)
        {
            Enrolments = new EnrolmentAPI(baseUrl, apiKey, tenantCode);
        }

    }
}
