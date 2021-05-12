using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class AcademicPeriod
    {
        [JsonProperty(propertyName:"id")]
        public int ID { get; set; }

        [JsonProperty(propertyName:"name")]
        public string Name { get; set; }

        [JsonProperty(propertyName:"year")]
        public int Year { get; set; }

        [JsonProperty(propertyName: "start_date")]
        public DateTime? StartDate { get; set; }

        [JsonProperty(propertyName:"end_date")]
        public DateTime? EndDate { get; set; }

    }
}
