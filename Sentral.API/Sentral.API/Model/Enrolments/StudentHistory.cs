using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StudentHistory
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "previousSchool")]
        public string PreviousSchool { get; set; }

        [JsonProperty(propertyName: "destinationSchool")]
        public string DestinationSchool { get; set; }

        [JsonProperty(propertyName: "startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(propertyName: "endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty(propertyName: "country")]
        public string Country { get; set; }

        [JsonProperty(propertyName: "reasonForChange")]
        public string ReasonForChange { get; set; }

        [JsonProperty(propertyName: "areRecordsReceived")]
        public bool AreRecordsReceived { get; set; }

        [JsonProperty(propertyName: "isExpelledOrSuspended")]
        public bool? IsExpelledOrSuspended { get; set; }

        [JsonProperty(propertyName: "hasLearningDisability")]
        public bool? HasLearningDisability { get; set; }

        [JsonProperty(propertyName: "student")]
        public Relationship<Student> Student { get; set; }

    }
}
