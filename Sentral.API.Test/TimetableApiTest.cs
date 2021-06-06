using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using System;
using System.Text;

namespace Sentral.API.Test
{
    [TestClass]
    public class TimetableApiTest : AbstractApiTest
    {


        [TestMethod]
        public void GetOneTimetableCalendarDate()
        {

            var x = SAPI.Timetables.GetTimetableCalendarDate(DateTime.Today);

            Assert.IsTrue(x != null && x.Date == x.ID);
        }


        [TestMethod]
        public void GetOneTimetableClass()
        {
            var x = SAPI.Timetables.GetTimetableClass(1);

            Assert.IsTrue(x != null && !string.IsNullOrWhiteSpace(x.Name));
        }
    }
}
