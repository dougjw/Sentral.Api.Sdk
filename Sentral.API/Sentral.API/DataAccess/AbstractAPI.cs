using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Sentral.API.DataAccess
{
    public abstract class AbstractAPI
    {
        private readonly string _apiHeader;
        private readonly string _baseUrl;

        public AbstractAPI(string baseUrl, string apiKey, string apiTenant)
        {
            APIHeader header = new APIHeader(apiKey, apiTenant);
            _apiHeader = JsonConvert.SerializeObject(header);
            _baseUrl = baseUrl;
        }

        protected object InvokeRestEndpoint<T>(string endpoint, APIMethod method, object payload)
        {

            return null;
        }


    }
}
