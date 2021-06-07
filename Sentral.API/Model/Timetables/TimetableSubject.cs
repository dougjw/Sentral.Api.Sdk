using Newtonsoft.Json;
using System;

namespace Sentral.API.Model.Timetables
{
    public class TimetableSubject
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Name { get; set; }


    }
}