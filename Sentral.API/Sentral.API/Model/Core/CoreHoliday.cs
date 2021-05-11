using System;

namespace Sentral.API.Model.Core
{
    public class CoreHoliday
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        public string Name { get; set; }

        public bool IsReoccuring { get; set; }

        public bool IsWholeSchool { get; set; }
    }
}