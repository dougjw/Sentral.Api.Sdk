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

        private string _consentGiven;
        private string _details;


        private bool _consentGivenSpecified;
        private bool _detailsSpecified;

        // Patch model
        public UpdateConsent(int id) :base(id, _type)
        {}

        // Post Model
        public UpdateConsent() : base(_type)
        { }



        [JsonProperty(propertyName: "type", NullValueHandling = NullValueHandling.Include)]
        public string ConsentGiven {
            get
            {
                return _consentGiven;
            } 
            
            set
            {
                _consentGiven = value;
                _consentGivenSpecified = true;
            } }


        public bool ShouldSerializeConsentGiven()
        {
            return _consentGivenSpecified;
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
                _detailsSpecified = true;
            }
        }


        public bool ShouldSerializeDetails()
        {
            return _detailsSpecified;
        }
    }
}
