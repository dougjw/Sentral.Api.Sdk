using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Timetables
{
    public class TimetablePeriodInDay
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public SentralTime StartTime { get; set; }
        public SentralTime EndTime { get; set; }
        public bool IsActive { get; set; }

        public Relationship<TimetableDay> Day { get; set; }
        public Relationship<TimetablePeriod> Period { get; set; }

    }
}