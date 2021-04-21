using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Common
{
    public class APIDataPage<T>
    {
        [JsonProperty(propertyName: "links")]
        public APILinks Links { get; set; }

        [JsonProperty(propertyName: "data")]
        public List<T> Data { get; set;}

    }
}
