using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Model.WebCal.Update;
using Sentral.API.Model.WebCal;
using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;
using Sentral.API.DataAccess.Exceptions;
using System.Collections.Generic;

namespace Sentral.API.Test
{
    [TestClass]
    public class WebCalApiTest : AbstractApiTest
    {

        [TestMethod]
        public void CreateUpdateAndDeleteOneCalendarTest()
        {
            // Only run test on sandbox
            if (IsTestSite)
            {
                string calName = "Testing Calendar";
                string calSrc = "SDK Testing: " + DateTime.Now.ToString("yyyyMMdd-hhmmss");

                string calUpdateName = "Testing Calendar (updated)";

                var newCalendar = new UpdateWebcalCalendar()
                {
                    CalendarName = calName,
                    ExternalSource = calSrc,
                    Owner = new Relationship<Model.Core.Update.SimpleCoreAdministrativeUserLink>()
                    {
                        Data = new Model.Core.Update.SimpleCoreAdministrativeUserLink()
                        {
                            ID = 1
                        }
                    }
                };


                var response = SAPI.WebCal.CreateWebcalCalendar(newCalendar);
                Assert.IsTrue(
                        response != null &&
                        response.ID > 0 &&
                        response.ExternalSource == calSrc &&
                        response.CalendarName == calName
                    );

                var getCalendarTest = SAPI.WebCal.GetWebcalCalendar(response.ID);
                Assert.IsTrue(
                        getCalendarTest != null && 
                        getCalendarTest.ID == response.ID &&
                        getCalendarTest.ExternalSource == calSrc &&
                        getCalendarTest.CalendarName == calName
                    );

                var updateModel = getCalendarTest.ToUpdatable();
                updateModel.CalendarName = calUpdateName;
                var updateCalendarTest = SAPI.WebCal.UpdateWebcalCalendar(updateModel);
                Assert.IsTrue(
                        updateCalendarTest != null &&
                        updateCalendarTest.ID == response.ID &&
                        updateCalendarTest.ExternalSource == calSrc &&
                        updateCalendarTest.CalendarName == calUpdateName
                    );

                SAPI.WebCal.DeleteWebcalCalendar(response.ID);
                Assert.ThrowsException<RestClientException>(()=> SAPI.WebCal.GetWebcalCalendar(response.ID));
            }
        }


        [TestMethod]
        public void CreateUpdateAndDeleteOneCalendarEventTest()
        {
            // Only run test on sandbox
            if (IsTestSite)
            {
                string eventTitle = "Testing Calendar";
                string eventNotes = "SDK Testing: " + DateTime.Now.ToString("yyyyMMdd-hhmmss");
                string eventTitleUpdate = "Testing Calendar (updated)";
                string category = "test";
                string link = "http://a-link-to-some-website.domain/some-folder";
                var primaryDate = new DateTime(2021, 01, 01);

                var newCalendarEvent = new UpdateWebcalCalendarEvent()
                {
                    Title = eventTitle,
                    Notes = eventNotes,
                    Date = primaryDate,
                    OtherDates = new List<DateTime>(){
                            new DateTime(2021,01,02),
                            new DateTime(2021,01,03)
                        },
                    Category = category,
                    StartTime = new SentralTime(5,30,00),
                    EndTime = new SentralTime(8, 30, 00),
                    Link = link,
                    Calendar = new Relationship<SimpleWebCalCalendarLink>()
                    {
                        Data = new SimpleWebCalCalendarLink()
                        {
                            ID = 1
                        }
                    }
                };


                var response = SAPI.WebCal.CreateWebcalCalendarEvent(newCalendarEvent);
                Assert.IsTrue(
                        response != null &&
                        response.ID > 0 &&
                        response.Title == eventTitle &&
                        response.Notes == eventNotes &&
                        response.Date == primaryDate &&
                        response.Link == link &&
                        response.Category == category

                    );

                var getCalendarTest = SAPI.WebCal.GetWebcalCalendarEvent(response.ID);
                Assert.IsTrue(
                        getCalendarTest != null &&
                        getCalendarTest.ID == response.ID &&
                        getCalendarTest.Title == eventTitle &&
                        getCalendarTest.Notes == eventNotes
                    );

                var updateModel = getCalendarTest.ToUpdatable();
                updateModel.Title = eventTitleUpdate;
                var updateCalendarTest = SAPI.WebCal.UpdateWebcalCalendarEvent(updateModel);
                Assert.IsTrue(
                        updateCalendarTest != null &&
                        updateCalendarTest.ID == response.ID &&
                        updateCalendarTest.Title == eventTitleUpdate
                    );

                SAPI.WebCal.DeleteWebcalCalendarEvent(response.ID);
                Assert.ThrowsException<RestClientException>(() => SAPI.WebCal.GetWebcalCalendarEvent(response.ID));
            }
        }




        [TestMethod]
        public void CreateUpdateAndDeleteOneCalendarRecurringEventTest()
        {
            // Only run test on sandbox
            if (IsTestSite)
            {
                string eventTitle = "Testing Calendar";
                string eventNotes = "SDK Testing: " + DateTime.Now.ToString("yyyyMMdd-hhmmss");
                string eventTitleUpdate = "Testing Calendar (updated)";
                string category = "test";
                string link = "http://a-link-to-some-website.domain/some-folder";
                var startDate = new DateTime(2021, 01, 01);
                var endDate = new DateTime(2021, 01, 01);

                var newCalendarRecurringEvent = new UpdateWebcalCalendarRecurringEvent()
                {
                    Title = eventTitle,
                    Notes = eventNotes,
                    StartDate = startDate,
                    EndDate = endDate,
                    Category = category,
                    StartTime = new SentralTime(5, 30, 00),
                    EndTime = new SentralTime(8, 30, 00),
                    Link = link,
                    Recurrence = WebCalRecurrenceType.day1,
                    RecurrenceWeekDay = 1,
                    Calendar = new Relationship<SimpleWebCalCalendarLink>()
                    {
                        Data = new SimpleWebCalCalendarLink()
                        {
                            ID = 1
                        }
                    }
                };


                var response = SAPI.WebCal.CreateWebcalCalendarRecurringEvent(newCalendarRecurringEvent);
                Assert.IsTrue(
                        response != null &&
                        response.ID > 0 &&
                        response.Title == eventTitle &&
                        response.Notes == eventNotes &&
                        response.StartDate == startDate &&
                        response.EndDate == endDate &&
                        response.Link == link &&
                        response.Category == category

                    );

                var getCalendarTest = SAPI.WebCal.GetWebcalCalendarRecurringEvent(response.ID);
                Assert.IsTrue(
                        getCalendarTest != null &&
                        getCalendarTest.ID == response.ID &&
                        getCalendarTest.Title == eventTitle &&
                        getCalendarTest.Notes == eventNotes
                    );

                var updateModel = getCalendarTest.ToUpdatable();
                updateModel.Title = eventTitleUpdate;
                var updateCalendarTest = SAPI.WebCal.UpdateWebcalCalendarRecurringEvent(updateModel);
                Assert.IsTrue(
                        updateCalendarTest != null &&
                        updateCalendarTest.ID == response.ID &&
                        updateCalendarTest.Title == eventTitleUpdate
                    );

                SAPI.WebCal.DeleteWebcalCalendarRecurringEvent(response.ID);
                Assert.ThrowsException<RestClientException>(() => SAPI.WebCal.GetWebcalCalendarRecurringEvent(response.ID));
            }
        }

    }
}
