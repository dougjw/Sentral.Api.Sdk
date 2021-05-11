using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.Client.ActionNamespace;

namespace Sentral.API.Client
{
    public class SentralApi
    {
        public EnrolmentApi Enrolments { get; }
        public CoreApi Core { get; }
        public SentralApi (string baseUrl, string apiKey, string tenantCode)
        {
            Enrolments = new EnrolmentApi(baseUrl, apiKey, tenantCode);
            Core = new CoreApi(baseUrl, apiKey, tenantCode);
        }

    }
}
