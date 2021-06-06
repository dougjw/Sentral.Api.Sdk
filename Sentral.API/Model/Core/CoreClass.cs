using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core
{
    public class CoreClass
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public string SchoolYear { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSourse { get; set; }
        public string RefId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public SentralDateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public Relationship<CoreStaff> Teacher {get; set;}

        public Relationship<List<CoreStaff>> AssignedStaff { get; set; }
        public Relationship<List<CoreStudent>> AssignedStudents { get; set; }
        public Relationship<List<Timetables.TimetableClass>> TimetableClass { get; set; }
    }
}
