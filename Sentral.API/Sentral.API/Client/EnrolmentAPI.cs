using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.DataAccess;
using Newtonsoft.Json;
using JsonApiSerializer;
using Sentral.API.Model.Enrolments;

namespace Sentral.API.Client
{
    public class EnrolmentAPI 
    {
        private readonly APIHeader _header;
        private readonly string _baseUrl;

        public EnrolmentAPI(string baseUrl, string apiKey, string tenantCode) {
            _baseUrl = baseUrl;
            _header = new APIHeader(apiKey, tenantCode);
        }

        public Person GetPerson(int id)
        {
            return (Person)InvokeRestMethod<Person>(string.Format("/v1/enrolments/person/{0}",id));
        }

        private object InvokeRestMethod<T>(string endpoint)
        {
            return InvokeRestMethod<T>(endpoint, APIMethod.GET, "");
        }

        private object InvokeRestMethod<T>(string endpoint, APIMethod method)
        {
            return InvokeRestMethod<T>(endpoint, method, "");
        }

        private object InvokeRestMethod<T>(string endpoint, APIMethod method, string payload)
        {
            var client = new SentralRestClient(GetUri(endpoint), _header, method, payload);
            var response = client.Invoke();
            return JsonConvert.DeserializeObject<T>(response, new JsonApiSerializerSettings());
        }

        private string GetUri(string endpoint)
        {
            return _baseUrl + endpoint;
        }
    }
}
