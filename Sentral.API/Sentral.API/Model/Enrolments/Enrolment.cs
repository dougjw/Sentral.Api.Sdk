using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.Enrolments.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Enrolment : IToUpdatable<UpdateEnrolment>
    {

        public int ID { get; set; }


        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; }

        public string SchoolName { get; set; }

        public string SchoolYearName { get; set; }

        public string RollclassName { get; set; }

        public string BoardingHouse { get; set; }

        public string TutorGroup { get; set; }
        public bool IsBoarding { get; set; }

        public SentralDateTime CreatedAt { get; set; }

        public SentralDateTime UpdatedAt { get; set; }

        public Relationship<Student> Student { get; set; }

        public Relationship<House> House { get; set; }

        public Relationship<Rollclass> Rollclass { get; set; }

        public Relationship<School> School { get; set; }

        public Relationship<YearLevel> YearLevel { get; set; }

        public Relationship<AcademicPeriod> AcademicPeriod { get; set; }

        public Relationship<Campus> Campus { get; set; }

        public UpdateEnrolment ToUpdatable()
        {
            return new UpdateEnrolment(ID)
            {
                IsBoarding = IsBoarding
            };
        }

    }
}
