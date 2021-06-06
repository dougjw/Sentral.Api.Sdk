using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.DataAccess.Exceptions;
using Sentral.API.Model.WebCal;
using Sentral.API.Model.WebCal.Update;
using Sentral.API.PowerShell.WebCal;
using Sentral.API.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace Sentral.API.PowerShell.Test
{
    [TestClass]
    public class WebcalCmdletTests : AbstractCmdletTest
    {
        [TestMethod]
        public void NewSetDelCalendarCmdletTest()
        {
            if (IsTestSite)
            {

                var calName = "Testing Calendar " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                var externalSource = "Testing SDK";
                var replacementCalendarName = "Updated Testing Calendar " + DateTime.Now.AddMilliseconds(30).ToString("yyyyMMdd HH:mm: ss");

                WebcalCalendar newResponse = null;
                WebcalCalendar setResponse = null;

                var newScriptInvocation = RunScript<WebcalCalendar>(
                    "New-SntCalCalendar",
                    new Dictionary<string, object>()
                        {
                            { "Calendar", calName },
                            { "ExternalSource", externalSource},
                            { "Owner", new CoreAdministrativeUser(){ID = 1} }
                    });

                if(newScriptInvocation.Count == 1)
                {
                    newResponse = newScriptInvocation[0];
                }

                // Has been created
                Assert.IsTrue(
                        newResponse != null && 
                        newResponse.CalendarName == calName && 
                        newResponse.ExternalSource == externalSource);


                var setScriptInvocation = RunScript<WebcalCalendar>(
                    "Set-SntCalCalendar",
                    new Dictionary<string, object>()
                        {
                            { "Calendar", newResponse},
                            { "CalendarName", replacementCalendarName }
                        }
                    );
                if(setScriptInvocation.Count == 1)
                {
                    setResponse = setScriptInvocation[0];
                }

                // Is updated
                Assert.IsTrue(
                        setResponse != null && 
                        setResponse.CalendarName == replacementCalendarName
                    );

                RunScript<WebcalCalendar>(
                    "Remove-SntCalCalendar",
                    new Dictionary<string, object>()
                        {
                            { "Calendar", setResponse}
                        }
                    );


                // Is Deleted
                Assert.ThrowsException<CmdletInvocationException>(()=> RunScript<WebcalCalendar>(
                    "Get-SntCalCalendar",
                    new Dictionary<string, object>()
                        {
                            { "CalendarId", setResponse.ID }
                        }
                    )
                );

            }
        }

        [TestMethod]
        public void NewSetDelCalendarEventCmdletTest()
        {
            if (IsTestSite)
            {

                var calEventTitle = "Testing Calendar Event " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                var notes = "This is a detailed description of the Calendar Event.";
                var replacementCalEventTitle = "Updated Testing Calendar " + DateTime.Now.AddMilliseconds(30).ToString("yyyyMMdd HH:mm: ss");

                WebcalCalendarEvent newResponse = null;
                WebcalCalendarEvent setResponse = null;

                var newScriptInvocation = RunScript<WebcalCalendarEvent>(
                    "New-SntCalCalendarEvent",
                    new Dictionary<string, object>()
                        {
                            { "Title", calEventTitle },
                            { "Notes", notes},
                            { "Link", "https://www.google.com" },
                            { "Category", "Important" },
                            { "Date", new DateTime(2021,10,10) },
                            { "StartTime", "09:30:00" },
                            { "EndTime", "13:30:00" },
                            { "OtherDates", new DateTime[] {
                                    new DateTime(2021,10,11),
                                    new DateTime(2021,10,12)
                                }},
                            { "Calendar", new WebcalCalendar(){ ID=1 } }
                    });

                if (newScriptInvocation.Count == 1)
                {
                    newResponse = newScriptInvocation[0];
                }

                // Has been created
                Assert.IsTrue(
                        newResponse != null &&
                        newResponse.Title == calEventTitle &&
                        newResponse.Notes == notes &&
                        newResponse.OtherDates.Count == 2);


                var setScriptInvocation = RunScript<WebcalCalendarEvent>(
                    "Set-SntCalCalendarEvent",
                    new Dictionary<string, object>()
                        {
                            { "CalendarEvent", newResponse},
                            { "Title", replacementCalEventTitle }
                        }
                    );
                if (setScriptInvocation.Count == 1)
                {
                    setResponse = setScriptInvocation[0];
                }

                // Is updated
                Assert.IsTrue(
                        setResponse != null &&
                        setResponse.Title == replacementCalEventTitle
                    );

                RunScript<WebcalCalendarEvent>(
                    "Remove-SntCalCalendarEvent",
                    new Dictionary<string, object>()
                        {
                            { "CalendarEvent", setResponse}
                        }
                    );


                // Is Deleted
                Assert.ThrowsException<CmdletInvocationException>(() => RunScript<WebcalCalendar>(
                    "Get-SntCalCalendarEvent",
                    new Dictionary<string, object>()
                        {
                            { "CalendarEventId", setResponse.ID }
                        }
                    )
                );

            }
        }
        [TestMethod]
        public void NewSetDelCalendarRecurringEventCmdletTest()
        {
            if (IsTestSite)
            {

                var calEventTitle = "Testing Calendar Event " + DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                var notes = "This is a detailed description of the Calendar Event.";
                var replacementCalEventTitle = "Updated Testing Calendar " + DateTime.Now.AddMilliseconds(30).ToString("yyyyMMdd HH:mm: ss");

                WebcalCalendarRecurringEvent newResponse = null;
                WebcalCalendarRecurringEvent setResponse = null;

                var newScriptInvocation = RunScript<WebcalCalendarRecurringEvent>(
                    "New-SntCalCalendarRecurringEvent",
                    new Dictionary<string, object>()
                        {
                            { "RecurranceDay1" , new SwitchParameter(true)},
                            { "Title", calEventTitle },
                            { "Notes", notes},
                            { "Link", "https://www.google.com" },
                            { "Category", "Important" },
                            { "StartDate", new DateTime(2021,10,10) },
                            { "EndDate", new DateTime(2031,10,10) },
                            { "StartTime", "09:30:00" },
                            { "EndTime", "13:30:00" },
                            { "RecurrenceWeekDay", 1},
                            { "Calendar", new WebcalCalendar(){ ID=1 } }
                    });

                if (newScriptInvocation.Count == 1)
                {
                    newResponse = newScriptInvocation[0];
                }

                // Has been created
                Assert.IsTrue(
                        newResponse != null &&
                        newResponse.Title == calEventTitle &&
                        newResponse.Notes == notes );


                var setScriptInvocation = RunScript<WebcalCalendarRecurringEvent>(
                    "Set-SntCalCalendarRecurringEvent",
                    new Dictionary<string, object>()
                        {
                            { "CalendarRecurringEvent", newResponse},
                            { "Title", replacementCalEventTitle }
                        }
                    );
                if (setScriptInvocation.Count == 1)
                {
                    setResponse = setScriptInvocation[0];
                }

                // Is updated
                Assert.IsTrue(
                        setResponse != null &&
                        setResponse.Title == replacementCalEventTitle
                    );

                RunScript<WebcalCalendarRecurringEvent>(
                    "Remove-SntCalCalendarRecurringEvent",
                    new Dictionary<string, object>()
                        {
                            { "CalendarRecurringEvent", setResponse}
                        }
                    );


                // Is Deleted
                Assert.ThrowsException<CmdletInvocationException>(() => RunScript<WebcalCalendarRecurringEvent>(
                    "Get-SntCalCalendarRecurringEvent",
                    new Dictionary<string, object>()
                        {
                            { "CalendarRecurringEventId", setResponse.ID }
                        }
                    )
                );

            }
        }
    }
}
