using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.DataAccess;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdatePersonConsentLink : AbstractUpdatable
    {

        private const string _type = "personConsentLink";

        private bool _consentGiven;
        private Relationship<Person> _consentedBy;
        private Relationship<Person> _person;
        private Relationship<Consent> _consent;


        private bool _consentGivenSpecified;
        private bool _consentedBySpecified;
        private bool _personSpecified;
        private bool _consentSpecified;


        // Patch Model - With ID
        public UpdatePersonConsentLink(int id) :base(id, _type)
        {

        }

        // Post Model - No ID
        public UpdatePersonConsentLink() : base(_type)
        {
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public bool ConsentGiven {
            get
            {
                return _consentGiven;
            } 
            
            set
            {
                _consentGiven = value;
                _consentGivenSpecified = true;
            } 
        }


        public bool ShouldSerializeConsentGiven()
        {
            return _consentGivenSpecified;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<Person> ConsentedBy
        {
            get
            {
                return _consentedBy;
            }

            set
            {
                _consentedBy = value;
                _consentedBySpecified = true;
            }
        }


        public bool ShouldSerializeConsentedBy()
        {
            return _consentedBySpecified;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<Person> Person
        {
            get
            {
                return _person;
            }

            set
            {
                _person = value;
                _personSpecified = IsPostModel();
            }
        }

        public bool ShouldSerializePerson()
        {
            return _personSpecified;
        }




        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<Consent> Consent
        {
            get
            {
                return _consent;
            }

            set
            {
                _consent = value;
                _consentSpecified = IsPostModel();
            }
        }


        public bool ShouldSerializeConsent()
        {
            return _consentSpecified;
        }
    }
}
