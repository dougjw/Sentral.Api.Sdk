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
        public TimetableApi Timetables { get; }
        public WebCalApi WebCal { get; }
        public SentralApi (string baseUrl, string apiKey, string tenantCode)
        {
            Enrolments = new EnrolmentApi(baseUrl, apiKey, tenantCode);
            Core = new CoreApi(baseUrl, apiKey, tenantCode);
            Timetables = new TimetableApi(baseUrl, apiKey, tenantCode);
            WebCal = new WebCalApi(baseUrl, apiKey, tenantCode);
        }

    }
}
