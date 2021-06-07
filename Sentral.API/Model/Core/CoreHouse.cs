using Sentral.API.Model.Common;

namespace Sentral.API.Model.Core
{
    public class CoreHouse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public SentralColour Colour { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }
        public bool IsActive { get; set; }
    }
}