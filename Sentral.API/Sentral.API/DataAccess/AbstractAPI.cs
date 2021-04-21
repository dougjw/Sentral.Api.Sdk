using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.DataAccess;
using Newtonsoft.Json;
using JsonApiSerializer;
using Sentral.API.Model.Enrolments;
using Sentral.API.Model.Common;
using JsonApiSerializer.JsonApi;

namespace Sentral.API.DataAccess
{
    abstract public class AbstractAPI 
    {
        private readonly APIHeader _header;
        private readonly string _baseUrl;
        private const int MaxPageSize = 200;
        private const string NextLinkKey = "next";

        public AbstractAPI(string baseUrl, string apiKey, string tenantCode) {
            _baseUrl = baseUrl;
            _header = new APIHeader(apiKey, tenantCode);
        }


        internal List<T> GetAllData<T>(string endpoint)
        {
            return GetAllData<T>(endpoint, MaxPageSize);
        }

        internal List<T> GetAllData<T>(string endpoint, int pageSize)
        {
            var data = new List<T>();

            string separtor = endpoint.Contains("?") ? "&" : "?";
            string next = string.Format("{0}{1}limit={2}", endpoint, separtor, pageSize);

            // Loop through and get all data pages.
            do
            {
                var dataPage = InvokeRestMethod<DocumentRoot<List<T>>>(next);
                data.AddRange(dataPage.Data);
                                
                if (dataPage.Links.ContainsKey(NextLinkKey))
                {
                    next = dataPage.Links[NextLinkKey].Href;
                }
                else
                {
                    next = null;
                }
                  
                
            }
            while (next != null);

            return data;
        }

        internal T InvokeRestMethod<T>(string endpoint)
        {
            return InvokeRestMethod<T>(endpoint, APIMethod.GET, "");
        }

        internal T InvokeRestMethod<T>(string endpoint, APIMethod method)
        {
            return InvokeRestMethod<T>(endpoint, method, "");
        }

        internal T InvokeRestMethod<T>(string endpoint, APIMethod method, string payload)
        {
            var client = new SentralRestClient(GetUri(endpoint), _header, method, payload);
            var response = client.Invoke();
            return JsonConvert.DeserializeObject<T>(response, new JsonApiSerializerSettings());
        }

        private string GetUri(string endpoint)
        {
            if(endpoint.StartsWith(_baseUrl))
            {
                return endpoint;
            }
            return _baseUrl + endpoint;
        }
    }
}
