using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Reports
{
    public class StudentAcademicReportPeriod
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
        public int Semester { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}