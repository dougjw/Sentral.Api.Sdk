using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class EnrolmentClassLink
    {
        [JsonProperty(propertyName: "id")]
        public string ID { get; set; }

        [JsonProperty(propertyName: "enrolment")]
        public Relationship<Enrolment> Enrolment { get; set; }

        [JsonProperty(propertyName: "class")]
        public Relationship<Class> Class { get; set; }



    }
}
