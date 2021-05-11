using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;

namespace Sentral.API.Model.Core
{
    public class CoreRollclass
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int Year { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }
        public Guid RefId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public SentralDateTime UpdatedAt {get;set;}
        public bool IsActive { get; set; }

        public Relationship<CoreStaff> Teacher { get; set; }

        public Relationship<Enrolments.Rollclass> EnrolmentRollclass { get; set; }
    }
}