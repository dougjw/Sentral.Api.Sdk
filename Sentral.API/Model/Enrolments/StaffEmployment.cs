using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StaffEmployment
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "employmentStatus")]
        public string EmploymentStatus { get; set; }

        [JsonProperty(propertyName: "startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(propertyName: "endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty(propertyName: "isMainSchool")]
        public bool IsMainSchool { get; set; }



        [JsonProperty(propertyName: "staff")]
        public Relationship<Staff> Staff { get; set; }

        [JsonProperty(propertyName: "school")]
        public Relationship<School> School { get; set; }

    }
}
