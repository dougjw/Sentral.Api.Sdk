using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core
{
    public class CoreTerm
    {
        public string ID { get; set; }
        public string Year { get; set; }
        public string Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
