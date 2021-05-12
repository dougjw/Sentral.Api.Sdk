using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System.Linq;

namespace Sentral.API.Model.Enrolments
{
    public class StudentHouseholdRelationship
    {

        [JsonProperty(propertyName: "id")]
        public string ID { get; set; }

        [JsonProperty(propertyName: "studentId")]
        public int StudentId { get; set; }

        [JsonProperty(propertyName: "householdId")]
        public int HouseholdId { get; set; }

        [JsonProperty(propertyName: "ResidentialHousehold")]
        public string ResidentialHousehold { get; set; }



        [JsonProperty(propertyName: "student")]
        public Relationship<Student> Student { get; set; }

        [JsonProperty(propertyName: "household")]
        public Relationship<Household> Household { get; set; }

    }
}
