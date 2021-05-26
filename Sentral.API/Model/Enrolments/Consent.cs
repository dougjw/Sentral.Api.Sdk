using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.Enrolments.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Consent : IToUpdatable<UpdateConsent>
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "type")]
        public string ConsentType { get; set; }

        public string Details { get; set; }

        [JsonProperty(propertyName: "isInactive")]
        public bool Inactive { get; set; }

        public UpdateConsent ToUpdatable()
        {
            return new UpdateConsent(ID)
            {
                ConsentType = ConsentType,
                Details = Details
            };
        }
    }
}
