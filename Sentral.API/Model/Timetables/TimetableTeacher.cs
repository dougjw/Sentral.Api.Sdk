using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;

namespace Sentral.API.Model.Timetables
{
    public class TimetableTeacher
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Relationship<Core.CoreStaff> CoreStaff { get; set; }
    }
}