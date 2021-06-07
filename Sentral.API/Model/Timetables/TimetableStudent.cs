using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;

namespace Sentral.API.Model.Timetables
{
    public class TimetableStudent
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Year { get; set; }
        public string Gender { get; set; }
        public Relationship<Core.CoreStudent> CoreStudent { get; set; }
    }
}