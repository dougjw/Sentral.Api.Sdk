using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Reports
{
    public class StudentAcademicReport
    {
        public int ID { get; set; }

        public DateTime? PublishedDateTime { get; set; }

        public int Year { get; set; }
        public int Semester { get; set; }
        public string ReportingPeriod { get; set; }

        public bool IsActive { get; set; }

        public Relationship<Enrolments.Student> Student { get; set; }
        public Relationship<StudentAcademicReportPeriod> Period { get; set; }
    }
}