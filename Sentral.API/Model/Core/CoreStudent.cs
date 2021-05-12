using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;

namespace Sentral.API.Model.Core
{
    public class CoreStudent
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public string Barcode { get; set; }
        public string ExamId { get; set; }
        public string SchoolYear { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string[] Allergies { get; set; }
        public string[] MedicalConditions { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string RefId { get; set; }
        public string EslSupportNeeded { get; set; }
        public string EslDateAssessed { get; set; }
        public bool IsEslSupportReceived { get; set; }
        public DateTime? EnrolDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public SentralDateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public Relationship<Enrolments.Student> EnrolmentStudent { get; set; }
        public Relationship<CorePerson> AdditionalDetails { get; set; }

        public Relationship<CoreRollclass> CoreRollclass { get; set; }

        public Relationship<CoreHouse> CoreHouse { get; set; }

        public Relationship<CoreFamily> CoreFamily { get; set; }
        public Relationship<CoreFamily> NonResidentialFamily { get; set; }
    }
}