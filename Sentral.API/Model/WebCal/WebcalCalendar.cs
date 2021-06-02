using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.Model.WebCal.Update;

namespace Sentral.API.Model.WebCal
{
    public class WebcalCalendar : IToUpdatable<UpdateWebcalCalendar>
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string CalendarName { get; set; }

        public string ExternalSource { get; set; }

        public Relationship<Core.CoreAdministrativeUser> Owner { get; set; }

        public UpdateWebcalCalendar ToUpdatable()
        {
            return new UpdateWebcalCalendar(ID)
            {
                CalendarName = CalendarName,
                ExternalSource = ExternalSource
            };
        }
    }
}
