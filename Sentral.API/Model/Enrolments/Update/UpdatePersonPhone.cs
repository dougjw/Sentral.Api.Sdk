using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdatePersonPhone : AbstractUpdatable
    {

        private const string _type = "personEmail";

        private string _number;
        private string _extension;
        private string _phoneType;
        private bool _isListed;
        private bool _canContact;
        private Relationship<Person> _owner;


        private bool _numberIncludeInSerialize;
        private bool _extensionIncludeInSerialize;
        private bool _phoneTypeIncludeInSerialize;
        private bool _isListedIncludeInSerialize;
        private bool _canContactIncludeInSerialize;
        private bool _ownerIncludeInSerialize;

        // Patch model
        public UpdatePersonPhone(int id) :base(id, _type)
        {}

        // Post Model
        public UpdatePersonPhone() : base(_type)
        { }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Extension
        {
            get
            {
                return _extension;
            } 
            
            set
            {
                _extension = value;
                _extensionIncludeInSerialize = true;
            } }


        public bool ShouldSerializeExtension()
        {
            return _extensionIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
                _numberIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeNumber()
        {
            return _numberIncludeInSerialize;
        }

        [JsonProperty(propertyName:"type", NullValueHandling = NullValueHandling.Include)]
        public string PhoneType
        {
            get
            {
                return _phoneType;
            }

            set
            {
                _phoneType = value;
                _phoneTypeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializePhoneType()
        {
            return _phoneTypeIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public bool IsListed
        {
            get
            {
                return _isListed;
            }

            set
            {
                _isListed = value;
                _isListedIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeIsListed()
        {
            return _isListedIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public bool CanContact
        {
            get
            {
                return _canContact;
            }

            set
            {
                _canContact = value;
                _canContactIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeCanContact()
        {
            return _canContactIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
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
