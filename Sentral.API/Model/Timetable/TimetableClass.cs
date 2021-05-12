using JsonApiSerializer.JsonApi;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Timetable
{
    public class TimetableClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Relationship<TimetableSubject> TimetableSubject { get; set; }

    }
}
