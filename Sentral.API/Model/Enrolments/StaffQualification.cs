using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.Enrolments.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StaffQualification : IToUpdatable<UpdateStaffQualification>
    {
         [JsonProperty(propertyName:"id")]
         public int ID { get; set; }

        public string Qualification { get; set; }

        public string QualificationType { get; set; }

        public string From { get; set; }

        public string AitslTeacherAccreditationLevel { get; set; }

        public string NextAitslTeacherAccreditationLevel { get; set; }

        public DateTime? DateAchieved { get; set; }

        public bool IsActive { get; set; }

        [JsonProperty(propertyName: "staff")]
        public Relationship<Staff> Staff { get; set; }

        public UpdateStaffQualification ToUpdatable()
        {
            return new UpdateStaffQualification(ID)
            {
                Qualification = Qualification,
                QualificationType = QualificationType,
                From = From,
                AitslTeacherAccreditationLevel = AitslTeacherAccreditationLevel,
                NextAitslTeacherAccreditationLevel = NextAitslTeacherAccreditationLevel,
                DateAchieved = DateAchieved
            };
        }

    }
}
