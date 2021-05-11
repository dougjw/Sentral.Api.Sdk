using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Core
{
    public class CoreStaff
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string GivenNames { get; set; }
        public string LastName { get; set; }
        public string PreferredTitle { get; set; }
        public string PreferredFirstName { get; set; }
        public string PreferredLastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string EmploymentStatus { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }
        public string RefId { get; set; }

        public DateTime? CreatedAt { get; set; }
        public SentralDateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        public Relationship<Enrolments.Staff> EnrolmentStaff { get; set; }
        public Relationship<List<CoreClass>> AssignedClasses { get; set; }
    }
}