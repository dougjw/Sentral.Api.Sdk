using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class UpdateStaffQualification : AbstractUpdatable
    {

        private const string _type = "staffQualification";

        // Patch model
        public UpdateStaffQualification(int id) :base(id, _type)
        {}

        // Post Model
        public UpdateStaffQualification() : base(_type)
        { }

        private string _qualification;
        private string _qualificationType;
        private string _from;
        private string _aitslTeacherAccreditationLevel;
        private string _nextAitslTeacherAccreditationLevel;
        private DateTime? _dateAchieved;
        private Relationship<Staff> _staff;



        private bool _qualificationIncludeInSerialize;
        private bool _typeIncludeInSerialize;
        private bool _fromIncludeInSerialize;
        private bool _aitslTeacherAccreditationLevelIncludeInSerialize;
        private bool _nextAitslTeacherAccreditationLevelIncludeInSerialize;
        private bool _dateAchievedIncludeInSerialize;
        private bool _staffIncludeInSerialize;


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Qualification
        {
            get
            {
                return _qualification;
            }

            set
            {
                _qualification = value;
                _qualificationIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeQualification()
        {
            return _qualificationIncludeInSerialize;
        }


        [JsonProperty(propertyName:"type", NullValueHandling = NullValueHandling.Include)]
        public string QualificationType
        {
            get
            {
                return _qualificationType;
            }

            set
            {
                _qualificationType = value;
                _typeIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeQualificationType()
        {
            return _typeIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string From
        {
            get
            {
                return _from;
            }

            set
            {
                _from = value;
                _fromIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeFrom()
        {
            return _fromIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string AitslTeacherAccreditationLevel
        {
            get
            {
                return _aitslTeacherAccreditationLevel;
            }

            set
            {
                _aitslTeacherAccreditationLevel = value;
                _aitslTeacherAccreditationLevelIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeAitslTeacherAccreditationLevel()
        {
            return _aitslTeacherAccreditationLevelIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string NextAitslTeacherAccreditationLevel
        {
            get
            {
                return _nextAitslTeacherAccreditationLevel;
            }

            set
            {
                _nextAitslTeacherAccreditationLevel = value;
                _nextAitslTeacherAccreditationLevelIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeNextAitslTeacherAccreditationLevel()
        {
            return _nextAitslTeacherAccreditationLevelIncludeInSerialize;
        }


        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public DateTime? DateAchieved
        {
            get
            {
                return _dateAchieved;
            }

            set
            {
                _dateAchieved = value;
                _dateAchievedIncludeInSerialize = true;
            }
        }


        public bool ShouldSerializeDateAchieved()
        {
            return _dateAchievedIncludeInSerialize;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public Relationship<Staff> Staff
        {
            get
            {
                return _staff;
            }

            set
            {
                _staff = value;
                _staffIncludeInSerialize = IsPostModel();
            }
        }


        public bool ShouldSerializeStaff()
        {
            return _staffIncludeInSerialize;
        }

    }
}
