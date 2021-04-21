using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.DataAccess;
using Newtonsoft.Json;
using JsonApiSerializer;
using Sentral.API.Model.Enrolments;
using Sentral.API.Model.Common;

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
            return InvokeRestMethod<Person>(string.Format("/v1/enrolments/person/{0}",id));
        }



        //private T GetAllData<T>(string endpoint)
        //{
        //    var data = new List<T>();
        //    var next = endpoint;

        //    do
        //    {
        //        var dataPage = InvokeRestMethod<APIDataPage<List<T>>>(endpoint);
        //        //dataPage.Data.CopyTo(data);
        //    }
        //    while (next != null)

            
        //    return null;
        //}

        private T InvokeRestMethod<T>(string endpoint)
        {
            return InvokeRestMethod<T>(endpoint, APIMethod.GET, "");
        }

        private T InvokeRestMethod<T>(string endpoint, APIMethod method)
        {
            return InvokeRestMethod<T>(endpoint, method, "");
        }

        private T InvokeRestMethod<T>(string endpoint, APIMethod method, string payload)
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
