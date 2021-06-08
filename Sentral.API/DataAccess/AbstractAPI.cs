using System.Collections.Generic;
using Newtonsoft.Json;
using JsonApiSerializer;
using JsonApiSerializer.JsonApi;
using Sentral.API.Common;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.Model.Common;
using Sentral.API.DataAccess.Exceptions;
using System;

namespace Sentral.API.DataAccess
{
    abstract public class AbstractApi 
    {
        private readonly ApiHeader _header;
        private readonly string _baseUrl;
        private const int MaxPageSize = 200;
        private const string NextLinkKey = "next";

        // TODO: Need more flexibility here? Enrolments Inc breaking other areas. This might need to be generic.

        private static readonly JsonApiSerializerSettings _settings = new JsonApiSerializerSettings(new SentralResourceObjectConverter());

        protected AbstractApi(string baseUrl, string apiKey, string tenantCode) {
            _baseUrl = baseUrl;
            _header = new ApiHeader(apiKey, tenantCode);
        }

        protected List<T> GetAllData<T>(string endpoint)
        {
            return GetAllData<T>(endpoint, MaxPageSize);
        }

        protected List<T> GetAllData<T>(string endpoint, int pageSize)
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

        protected T GetData<T>(string endpoint)
        {
            return GetApiResponse<T>(endpoint, ApiMethod.GET, "");
        }

        protected T GetApiResponse<T>(string endpoint, ApiMethod method)
        {
            return GetApiResponse<T>(endpoint, method, "");
        }


        protected T GetApiResponse<T>(string endpoint, ApiMethod method, AbstractUpdatable payload)
        {
            var jsonPayload = JsonConvert.SerializeObject(payload, _settings);
            return GetApiResponse<T>(endpoint, method, jsonPayload);
        }

        protected T GetApiResponse<T>(string endpoint, ApiMethod method, string payload)
        {
            var client = new SentralRestClient(GetUri(endpoint), _header, method, payload);
            var response = client.Invoke();
            return JsonConvert.DeserializeObject<T>(response, _settings);
        }

        protected byte[] GetBinaryData(string endpoint)
        {
            var client = new SentralRestClient(GetUri(endpoint), _header, ApiMethod.GET, null);
            return client.InvokeBinary();
        }

        protected BinaryFile GetBinaryFile(string endpoint)
        {
            var client = new SentralRestClient(GetUri(endpoint), _header, ApiMethod.GET, null);
            return client.InvokeBinaryResponse();
        }


        protected string GetApiResponse(string endpoint, ApiMethod method)
        {
            var client = new SentralRestClient(GetUri(endpoint), _header, method, null);
            var response = client.Invoke();
            return response;
        }

        private string GetUri(string endpoint)
        {
            if(endpoint.StartsWith(_baseUrl))
            {
                return endpoint;
            }
            return _baseUrl + endpoint;
        }


        protected string GetEndpointParameters(string endpoint,
                Dictionary<string, object> parameters)
        {
            return GetEndpointParameters<object>(endpoint, parameters);
        }

        protected string GetEndpointParameters<T>(
                string endpoint,
                Dictionary<string, object> parameters
        )
        {
            var queryStringHelper = new ApiQueryStringHelper();

            return GetEndpointParameters<T>(endpoint, parameters, queryStringHelper);
        }

        protected string GetEndpointParameters<T>(
                string endpoint,
                Dictionary<string, object> parameters,
                ApiQueryStringHelper queryStringHelper
        )
        {
            return queryStringHelper.GetQueryString<T>(endpoint, parameters);
        }

        protected void ValidateModelIsNotNullOrZero(AbstractUpdatable updateData)
        {

            if (updateData == null || updateData.ID == 0)
            {
                throw new RestClientException("Enrolment object null or has ID of zero (0).");
            }
        }


        protected T UpdateData<T>(string endpoint, AbstractUpdatable updateData)
        {
            ValidateModelIsNotNullOrZero(updateData);
            return GetApiResponse<T>(
                    string.Format(endpoint + "/{0}", updateData.ID),
                    ApiMethod.PATCH,
                    updateData
                );
        }


        protected T CreateData<T>(string endpoint, AbstractUpdatable updateData)
        {
            return GetApiResponse<T>(
                    endpoint,
                    ApiMethod.POST,
                    updateData
                );
        }
        protected void DeleteData(string endpoint, int id)
        {
            GetApiResponse(string.Format(endpoint + "/{0}", id), ApiMethod.DELETE);
        }
    }
}
