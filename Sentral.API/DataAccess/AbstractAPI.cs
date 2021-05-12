using System.Collections.Generic;
using Newtonsoft.Json;
using JsonApiSerializer;
using JsonApiSerializer.JsonApi;
using Sentral.API.Common;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.Model.Common;
using Sentral.API.DataAccess.Exceptions;

namespace Sentral.API.DataAccess
{
    abstract public class AbstractApi 
    {
        private readonly ApiHeader _header;
        private readonly string _baseUrl;
        private const int MaxPageSize = 200;
        private const string NextLinkKey = "next";
        private readonly ApiQueryStringHelper<EnumEnrolmentsIncludeOptions> _queryStringHelper;
        private static readonly JsonApiSerializerSettings _settings = new JsonApiSerializerSettings(new SentralResourceObjectConverter());

        public AbstractApi(string baseUrl, string apiKey, string tenantCode) {
            _baseUrl = baseUrl;
            _header = new ApiHeader(apiKey, tenantCode);
            _queryStringHelper = new ApiQueryStringHelper<EnumEnrolmentsIncludeOptions>();
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
                var dataPage = GetData<DocumentRoot<List<T>>>(next);
                data.AddRange(dataPage.Data);
                                
                if (dataPage.Links != null && dataPage.Links.ContainsKey(NextLinkKey))
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

        internal T GetData<T>(string endpoint)
        {
            return GetApiResponse<T>(endpoint, ApiMethod.GET, "");
        }

        internal T GetApiResponse<T>(string endpoint, ApiMethod method)
        {
            return GetApiResponse<T>(endpoint, method, "");
        }


        internal T GetApiResponse<T>(string endpoint, ApiMethod method, AbstractUpdatable payload)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload, _settings);
            return GetApiResponse<T>(endpoint, method, jsonPayload);
        }

        private T GetApiResponse<T>(string endpoint, ApiMethod method, string payload)
        {
            var client = new SentralRestClient(GetUri(endpoint), _header, method, payload);
            var response = client.Invoke();
            return JsonConvert.DeserializeObject<T>(response, _settings);
        }

        private string GetUri(string endpoint)
        {
            if(endpoint.StartsWith(_baseUrl))
            {
                return endpoint;
            }
            return _baseUrl + endpoint;
        }

        internal string GetEndpointParameters(string endpoint, Dictionary<string, object> parameters)
        {
            return _queryStringHelper.GetQueryString(endpoint, parameters);
        }

        internal void ValidateModelIsNotNullOrZero(AbstractUpdatable updateData)
        {

            if (updateData == null || updateData.ID == 0)
            {
                throw new RestClientException("Enrolment object null or has ID of zero (0).");
            }
        }
    }
}
