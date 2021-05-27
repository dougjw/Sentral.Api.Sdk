using Newtonsoft.Json;

namespace Sentral.API.Model.Activities
{
    public class CycleInstance
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public int Year { get; set; }

        public string Name { get; set; }

        public string Cyle { get; set; }

        public string Period { get; set; }
    }
}