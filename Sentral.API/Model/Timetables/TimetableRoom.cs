using Newtonsoft.Json;

namespace Sentral.API.Model.Timetables
{
    public class TimetableRoom
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Name { get; set; }
        public int? Capacity { get; set; }

        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}