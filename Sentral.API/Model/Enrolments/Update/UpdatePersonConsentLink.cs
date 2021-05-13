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


        private bool _consentGivenIncludeInSerialize;
        private bool _consentedByIncludeInSerialize;
        private bool _personIncludeInSerialize;
        private bool _consentIncludeInSerialize;


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
                _consentGivenIncludeInSerialize = true;
            } 
        }


        public bool ShouldSerializeConsentGiven()
        {
            return _consentGivenIncludeInSerialize;
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
                _consentedByIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeConsentedBy()
        {
            return _consentedByIncludeInSerialize;
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
                _personIncludeInSerialize = IsPostModel();
            }
        }

        public bool ShouldSerializePerson()
        {
            return _personIncludeInSerialize;
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
                _consentIncludeInSerialize = IsPostModel();
            }
        }


        public bool ShouldSerializeConsent()
        {
            return _consentIncludeInSerialize;
        }
    }
}
