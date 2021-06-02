using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal.Update
{
    public class UpdateWebcalCalendar : AbstractUpdatable
    {

        private const string _type = "webcalCalendar";

        private string _calendarName;
        private string _externalSource;
        private Relationship<Model.Core.Update.SimpleCoreAdministrativeUserLink> _owner;


        private bool _calendarNameIncludeInSerialize;
        private bool _externalSourceIncludeInSerialize;
        private bool _ownerIncludeInSerialize;

        // Patch model
        public UpdateWebcalCalendar(int id) :base(id, _type)
        {}

        // Post Model
        public UpdateWebcalCalendar() : base(_type)
        { }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string CalendarName {
            get
            {
                return _calendarName;
            } 
            
            set
            {
                _calendarName = value;
                _calendarNameIncludeInSerialize = true;
            } 
        }


        public bool ShouldSerializeCalendarName()
        {
            return _calendarNameIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string ExternalSource
        {
            get
            {
                return _externalSource;
            }

            set
            {
                _externalSource = value;
                _externalSourceIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeExternalSource()
        {
            return _externalSourceIncludeInSerialize;
        }




        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<Model.Core.Update.SimpleCoreAdministrativeUserLink> Owner
        {
            get
            {
                return _owner;
            }

            set
            {
                _owner = value;
                _ownerIncludeInSerialize = IsPostModel();
            }
        }


        public bool ShouldSerializeOwner()
        {
            return _ownerIncludeInSerialize;
        }
    }
}
