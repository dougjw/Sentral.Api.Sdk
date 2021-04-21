using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Sentral.API.DataAccess
{
    public class APIHeader
    {
        public APIHeader(string key, string tenant)
        {
            Key = key;
            Tenant = tenant;
        }

        [JsonProperty(propertyName: "x-api-key")]
        public string Key { get; }

        [JsonProperty(propertyName: "x-api-tenant")]
        public string Tenant { get; }
    }
}
