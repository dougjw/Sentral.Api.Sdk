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

        private const string _personType = "person";
        private const string _consentType = "consent";

        private bool _consentGiven;


        private Relationship<SimpleRelationshipLink> _consentedBy;
        private Relationship<SimpleRelationshipLink> _person;
        private Relationship<SimpleRelationshipLink> _consent;


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
        public Relationship<SimpleRelationshipLink> ConsentedBy
        {
            get
            {
                return _consentedBy;
            }

            set
            {
                _consentedBy = value;
                SetRelationshipLinkType(_personType, _consentedBy);
                _consentedByIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeConsentedBy()
        {
            return _consentedByIncludeInSerialize;
        }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<SimpleRelationshipLink> Person
        {
            get
            {
                return _person;
            }

            set
            {
                _person = value;
                SetRelationshipLinkType(_personType, _consentedBy);
                _personIncludeInSerialize = IsPostModel();
            }
        }

        public bool ShouldSerializePerson()
        {
            return _personIncludeInSerialize;
        }




        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<SimpleRelationshipLink> Consent
        {
            get
            {
                return _consent;
            }

            set
            {
                _consent = value;
                SetRelationshipLinkType(_consentType, _consentedBy);
                _consentIncludeInSerialize = IsPostModel();
            }
        }


        public bool ShouldSerializeConsent()
        {
            return _consentIncludeInSerialize;
        }
    }
}
