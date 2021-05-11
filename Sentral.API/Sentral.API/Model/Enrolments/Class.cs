using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Class
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "identifier")]
        public string Identifier { get; set; }


        [JsonProperty(propertyName:"teachers")]
        public Relationship<Staff> Teachers { get; set; }

        [JsonProperty(propertyName: "students")]
        public Relationship<Student> Students { get; set; }

        [JsonProperty(propertyName: "subject")]
        public Relationship<ClassSubject> Subject { get; set; }
    }
}
