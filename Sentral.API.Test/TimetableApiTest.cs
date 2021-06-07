using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Client;
using Sentral.API.Model.Timetables.Include;
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

        [TestMethod]
        public void GetOneTimetableClassLesson()
        {
            var x = SAPI.Timetables.GetTimetableClassLesson(1,
                new TimetableLessonIncludeOptions[]{
                        TimetableLessonIncludeOptions.TimetableTeachers
                });

            Assert.IsTrue(x != null && !string.IsNullOrWhiteSpace(x.TimetableTeachers.Data[0].FirstName));
        }
        

        [TestMethod]
        public void GetOneTimetableDailyLesson()
        {
            var x = SAPI.Timetables.GetTimetableDailyLesson(1,
                new TimetableLessonIncludeOptions[]{
                        TimetableLessonIncludeOptions.TimetableTeachers
                });

            Assert.IsTrue(x != null && !string.IsNullOrWhiteSpace(x.TimetableTeachers.Data[0].FirstName));
        }

        [TestMethod]
        public void GetOneTimetableDay()
        {
            var x = SAPI.Timetables.GetTimetableDay(1);

            Assert.IsTrue(x != null && !string.IsNullOrWhiteSpace(x.Name));
        }

        [TestMethod]
        public void GetOneTimetablePeriod()
        {
            var x = SAPI.Timetables.GetTimetablePeriod(1);

            Assert.IsTrue(
                    x != null && 
                    !string.IsNullOrWhiteSpace(x.Name)
                );
        }

        [TestMethod]
        public void GetOneTimetablePeriodInDay()
        {
            var x = SAPI.Timetables.GetTimetablePeriodInDay(1);

            Assert.IsTrue(
                    x != null && 
                    !string.IsNullOrWhiteSpace(x.Name) && 
                    x.StartTime != null &&
                    x.EndTime != null);
        }

        [TestMethod]
        public void GetOneTimetableRoom()
        {
            var x = SAPI.Timetables.GetTimetableRoom(1);

            Assert.IsTrue(
                    x != null &&
                    !string.IsNullOrWhiteSpace(x.Name)
                );
        }

        [TestMethod]
        public void GetTimetableStudents()
        {
            var x = SAPI.Timetables.GetTimetableStudent();

            Assert.IsTrue(
                    x != null &&
                    x.Count > 0 &&
                    !string.IsNullOrWhiteSpace(x[0].FirstName) &&
                    !string.IsNullOrWhiteSpace(x[0].LastName)
                );
        }

        [TestMethod]
        public void GetTimetableSubjects()
        {
            var x = SAPI.Timetables.GetTimetableSubject();

            Assert.IsTrue(
                    x != null &&
                    x.Count > 0 &&
                    !string.IsNullOrWhiteSpace(x[0].Name)
                );
        }
    }
}
