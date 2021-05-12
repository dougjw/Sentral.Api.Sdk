using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StaffQualification
    {
         [JsonProperty(propertyName:"id")]
         public int ID { get; set; }

        [JsonProperty(propertyName: "qualification")]
        public string Qualification { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type { get; set; }

        [JsonProperty(propertyName: "from")]
        public string From { get; set; }

        [JsonProperty(propertyName: "aitslTeacherAccreditationLevel")]
        public string AitslTeacherAccreditationLevel { get; set; }

        [JsonProperty(propertyName: "nextAitslTeacherAccreditationLevel")]
        public string NextAitslTeacherAccreditationLevel { get; set; }

        [JsonProperty(propertyName: "dateAchieved")]
        public DateTime? DateAchieved { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(propertyName: "staff")]
        public Relationship<Staff> Staff { get; set; }


        //TODO: Complete Stub
    }
}
