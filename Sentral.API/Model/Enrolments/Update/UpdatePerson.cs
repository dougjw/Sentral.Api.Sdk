using System;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdatePerson : AbstractUpdatable
    {

        private const string _type = "person";

        private string _contactCode;
        private string _title;
        private string _firstName;
        private string _middleNames;
        private string _lastName;
        private string _legalLastName;
        private string _preferredName;
        private string _genderCode;
        private string _crn;
        private string _languageSpokenAtHomeCode;


        private bool _contactCodeSpecified;
        private bool _titleSpecified;
        private bool _firstNameSpecified;
        private bool _middleNamesSpecified;
        private bool _lastNameSpecified;
        private bool _legalLastNameSpecified;
        private bool _preferredNameSpecified;
        private bool _genderCodeSpecified;
        private bool _crnSpecified;
        private bool _languageSpokenAtHomeCodeSpecified;



        public UpdatePerson(int id) : base (id, _type)
        {
        }
   

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string ContactCode { 
            get {
                return _contactCode;
            }
            set {
                _contactCode = value;
                _contactCodeSpecified = true;
            }
        }
        public bool ShouldSerializeContactCode()
        {
            return _contactCodeSpecified;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                _titleSpecified = true;
            }
        }
        public bool ShouldSerializeTitle()
        {
            return _titleSpecified;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                _firstNameSpecified = true;
            }
        }
        public bool ShouldSerializeFirstName()
        {
            return _firstNameSpecified;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string MiddleNames
        {
            get
            {
                return _middleNames;
            }
            set
            {
                _middleNames = value;
                _middleNamesSpecified = true;
            }
        }

        public bool ShouldSerializeMiddleNames()
        {
            return _middleNamesSpecified;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                _lastNameSpecified = true;
            }
        }
        public bool ShouldSerializeLastName()
        {
            return _lastNameSpecified;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string LegalLastName
        {
            get
            {
                return _legalLastName;
            }
            set
            {
                _legalLastName = value;
                _legalLastNameSpecified = true;
            }
        }
        public bool ShouldSerializeLegalLastName()
        {
            return _legalLastNameSpecified;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string PreferredName
        {
            get
            {
                return _preferredName;
            }
            set
            {
                _preferredName = value;
                _preferredNameSpecified = true;
            }
        }
        public bool ShouldSerializePreferredName()
        {
            return _preferredNameSpecified;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string GenderCode
        {
            get
            {
                return _genderCode;
            }
            set
            {
                _genderCode = value;
                _genderCodeSpecified = true;
            }
        }

        public bool ShouldSerializeGenderCode()
        {
            return _genderCodeSpecified;
        }

        [JsonProperty(propertyName: "crn", NullValueHandling = NullValueHandling.Include)]
        public string CRN
        {
            get
            {
                return _crn;
            }
            set
            {
                _crn = value;
                _crnSpecified = true;
            }
        }
        public bool ShouldSerializeCRN()
        {
            return _crnSpecified;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string LanguageSpokenAtHomeCode
        {
            get
            {
                return _languageSpokenAtHomeCode;
            }
            set
            {
                _languageSpokenAtHomeCode = value;
                _languageSpokenAtHomeCodeSpecified = true;
            }
        }
        public bool ShouldSerializeLanguageSpokenAtHomeCode()
        {
            return _languageSpokenAtHomeCodeSpecified;
        }

    }
}
