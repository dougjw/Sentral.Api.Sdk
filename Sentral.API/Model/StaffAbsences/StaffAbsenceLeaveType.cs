using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.StaffAbsences
{
    public class StaffAbsenceLeaveType
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

    }
}
