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


        private bool _contactCodeIncludeInSerialize;
        private bool _titleIncludeInSerialize;
        private bool _firstNameIncludeInSerialize;
        private bool _middleNamesIncludeInSerialize;
        private bool _lastNameIncludeInSerialize;
        private bool _legalLastNameIncludeInSerialize;
        private bool _preferredNameIncludeInSerialize;
        private bool _genderCodeIncludeInSerialize;
        private bool _crnIncludeInSerialize;
        private bool _languageSpokenAtHomeCodeIncludeInSerialize;



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
                _contactCodeIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializeContactCode()
        {
            return _contactCodeIncludeInSerialize;
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
                _titleIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializeTitle()
        {
            return _titleIncludeInSerialize;
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
                _firstNameIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializeFirstName()
        {
            return _firstNameIncludeInSerialize;
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
                _middleNamesIncludeInSerialize = true;
            }
        }

        public bool ShouldSerializeMiddleNames()
        {
            return _middleNamesIncludeInSerialize;
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
                _lastNameIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializeLastName()
        {
            return _lastNameIncludeInSerialize;
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
                _legalLastNameIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializeLegalLastName()
        {
            return _legalLastNameIncludeInSerialize;
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
                _preferredNameIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializePreferredName()
        {
            return _preferredNameIncludeInSerialize;
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
                _genderCodeIncludeInSerialize = true;
            }
        }

        public bool ShouldSerializeGenderCode()
        {
            return _genderCodeIncludeInSerialize;
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
                _crnIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializeCRN()
        {
            return _crnIncludeInSerialize;
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
                _languageSpokenAtHomeCodeIncludeInSerialize = true;
            }
        }
        public bool ShouldSerializeLanguageSpokenAtHomeCode()
        {
            return _languageSpokenAtHomeCodeIncludeInSerialize;
        }

    }
}
