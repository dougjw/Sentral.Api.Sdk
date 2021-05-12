using JsonApiSerializer.JsonApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core
{
    public class CoreStudentPersonRelation
    {
        public int ID { get; set; }
        public string Relationship { get; set; }
        public bool IsResidentialGuardian { get; set; }
        public bool IsEmergencyContact { get; set; }
        public bool IsAuthorisedPickup { get; set; }
        public bool CanContactViaSms { get; set; }
        public bool CanContactViaEmail { get; set; }
        public bool CanContactViaPhone { get; set; }
        public bool CanContactViaLetter { get; set; }
        public bool CanReceiveCorrespondence { get; set; }
        public bool CanReceivePortalAccess { get; set; }
        public bool CanReceiveReports { get; set; }
        public bool CanReceiveSms { get; set; }
        public string Sequence { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }

        public Relationship<CoreStudent> CoreStudent { get; set; }

        public Relationship<CorePerson> CorePerson { get; set; }
    }
}
