using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StudentDocument
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string FileName { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsConfidential { get; set; }

    }
}
