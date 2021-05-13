using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdateEnrolment : AbstractUpdatable
    {

        private const string _type = "enrolment";

        private bool? _isBoarding;
        private bool _isBoardingIncludeInSerialize;


        public UpdateEnrolment(int id) :base(id, _type)
        {}


        [JsonProperty(propertyName: "isBoarding", NullValueHandling = NullValueHandling.Include)]
        public bool? IsBoarding {
            get
            {
                return _isBoarding;
            } 
            
            set
            {
                _isBoarding = value;
                _isBoardingIncludeInSerialize = true;
            } }


        public bool ShouldSerializeIsBoarding()
        {
            return _isBoardingIncludeInSerialize;
        }
    }
}
