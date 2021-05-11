using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class ClassSubject
    {
        [JsonProperty(propertyName:"id")]
        public int ID { get; set; }

        [JsonProperty(propertyName:"name")]
        public string Name { get; set; }
    }
}
