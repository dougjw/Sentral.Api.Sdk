using JsonApiSerializer.JsonApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core
{
    public class CoreStudentRelationship
    {
        public int ID { get; set; }
        public string Relationship { get; set; }
        public bool IsResidentialGuardian { get; set; }
        public bool IsEmergencyContact { get; set; }
        public string Sequence { get; set; }

        public CorePerson CorePerson { get; set; }
        public bool IsActive { get; set; }

        public Relationship<CoreStudent> CoreStudent { get; set; }
    }
}
