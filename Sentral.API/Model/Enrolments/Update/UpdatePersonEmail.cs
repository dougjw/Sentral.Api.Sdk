using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdatePersonEmail : AbstractUpdatable
    {

        private const string _type = "personEmail";

        private string _email;
        private string _emailType;
        private Relationship<Person> _owner;


        private bool _emailIncludeInSerialize;
        private bool _emailTypeIncludeInSerialize;
        private bool _ownerIncludeInSerialize;

        // Patch model
        public UpdatePersonEmail(int id) :base(id, _type)
        {}

        // Post Model
        public UpdatePersonEmail() : base(_type)
        { }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Email {
            get
            {
                return _email;
            } 
            
            set
            {
                _email = value;
                _emailIncludeInSerialize = true;
            } }


        public bool ShouldSerializeEmail()
        {
            return _emailIncludeInSerialize;
        }


        [JsonProperty(propertyName:"type", NullValueHandling = NullValueHandling.Include)]
        public string EmailType
        {
            get
            {
                return _emailType;
            }

            set
            {
                _emailType = value;
                _emailTypeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeEmailType()
        {
            return _emailTypeIncludeInSerialize;
        }


        [JsonProperty(propertyName: "type", NullValueHandling = NullValueHandling.Include)]
        public Relationship<Person> Owner
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
