using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdateConsent : AbstractUpdatable
    {

        private const string _type = "consent";

        private string _consentType;
        private string _details;


        private bool _consentTypeIncludeInSerialize;
        private bool _detailsIncludeInSerialize;

        // Patch model
        public UpdateConsent(int id) :base(id, _type)
        {}

        // Post Model
        public UpdateConsent() : base(_type)
        { }



        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string ConsentType {
            get
            {
                return _consentType;
            } 
            
            set
            {
                _consentType = value;
                _consentTypeIncludeInSerialize = true;
            } 
        }


        public bool ShouldSerializeConsentGiven()
        {
            return _consentTypeIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Details
        {
            get
            {
                return _details;
            }

            set
            {
                _details = value;
                _detailsIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeDetails()
        {
            return _detailsIncludeInSerialize;
        }
    }
}
