using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class PrescribedMedication
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "dosage")]
        public string Dosage { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "details")]
        public string Details { get; set; }

        [JsonProperty(propertyName: "isPrescribed")]
        public bool IsPrescribed { get; set; }

        [JsonProperty(propertyName: "isTakenAtSchool")]
        public bool IsTakenAtSchooll { get; set; }

        [JsonProperty(propertyName: "isLongTerm")]
        public bool IsLongTerm { get; set; }

        [JsonProperty(propertyName: "anticipatedStopDate")]
        public DateTime? AnticipatedStopDate { get; set; }


        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

    }
}
