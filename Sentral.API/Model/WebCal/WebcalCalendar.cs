using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal
{
    public class WebcalCalendar
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string CalendarName { get; set; }

        public string ExternalSource { get; set; }

        Relationship<Model.Core.CoreAdministrativeUser> Owner { get; set; }
    }
}
