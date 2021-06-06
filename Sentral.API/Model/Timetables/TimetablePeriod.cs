using Newtonsoft.Json;
using System;

namespace Sentral.API.Model.Timetables
{
    public class TimetablePeriod
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }


    }
}