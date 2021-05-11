using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StudentFlagLink
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "comment")]
        public string Comment { get; set; }

        [JsonProperty(propertyName: "expiryDate")]
        public DateTime? ExpiryDate { get; set; }


        [JsonProperty(propertyName: "student")]
        public Relationship<Student> Student { get; set; }

        [JsonProperty(propertyName: "flag")]
        public Relationship<Flag> Flag { get; set; }
    }
}
