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
    public class EnrolmentAPI : AbstractAPI
    {
        private readonly APIHeader _header;
        private readonly string _baseUrl;
        private const int MaxPageSize = 200;

        public EnrolmentAPI(string baseUrl, string apiKey, string tenantCode) : 
                base (baseUrl, apiKey, tenantCode) { }

        public Person GetPerson(int id)
        {
            return InvokeRestMethod<Person>(string.Format("/v1/enrolments/person/{0}",id));
        }

        public List<Person> GetPerson()
        {
            return GetAllData<Person>("/v1/enrolments/person");
        }
        
    }
}
