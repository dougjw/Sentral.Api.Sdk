using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public abstract class AbstractMedicalCondition
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Details { get; set; }

        public string AdditionalInformation { get; set; }

        public bool HasCarePlanProvided { get; set; }

        Relationship<Person> Person { get; set; }

    }
}
