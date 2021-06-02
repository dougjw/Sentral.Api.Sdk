using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.DataAccess;
using Newtonsoft.Json;
using Sentral.API.Model.WebCal;
using Sentral.API.Model.WebCal.Update;
using Sentral.API.DataAccess.Exceptions;
using Sentral.API.Common;

namespace Sentral.API.Client.ActionNamespace
{
    public class WebCalApi : AbstractApi
    {

        internal WebCalApi(string baseUrl, string apiKey, string tenantCode) :
                base(baseUrl, apiKey, tenantCode)
        { }

        public WebcalCalendar GetWebcalCalendar(int id)
        {
            return GetData<WebcalCalendar>(string.Format("/v1/webcal/webcal-calendar/{0}", id));
        }

        public List<WebcalCalendar> GetWebcalCalendar(int[] ids = null, int[] ownerIds = null)
        {

            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["ownerIds"] = ownerIds
            };

            var uri = GetEndpointParameters("/v1/webcal/webcal-calendar", p);

            return GetAllData<WebcalCalendar>(uri);
        }



        public WebcalCalendar UpdateWebcalCalendar(UpdateWebcalCalendar updateData)
        {
            return UpdateData<WebcalCalendar>("/v1/webcal/webcal-calendar", updateData);
        }


        public WebcalCalendar CreateWebcalCalendar(UpdateWebcalCalendar updateData)
        {
            return CreateData<WebcalCalendar>("/v1/webcal/webcal-calendar", updateData);
        }

        public void DeleteWebcalCalendar(int id)
        {
            DeleteData("/v1/webcal/webcal-calendar", id);
        }



        public WebcalCalendarEvent GetWebcalCalendarEvent(int id)
        {
            return GetData<WebcalCalendarEvent>(string.Format("/v1/webcal/webcal-calendar-event/{0}", id));
        }

        public List<WebcalCalendarEvent> GetWebcalCalendarEvent(int[] ids = null, int[] calendarIds = null, DateTime[] dates = null)
        {

            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["calendarIds"] = calendarIds,
                ["dates"] = dates
            };

            var uri = GetEndpointParameters("/v1/webcal/webcal-calendar-event", p);

            return GetAllData<WebcalCalendarEvent>(uri);
        }



        public WebcalCalendarEvent UpdateWebcalCalendarEvent(UpdateWebcalCalendarEvent updateData)
        {
            return UpdateData<WebcalCalendarEvent>("/v1/webcal/webcal-calendar-event", updateData);
        }


        public WebcalCalendarEvent CreateWebcalCalendarEvent(UpdateWebcalCalendarEvent updateData)
        {
            return CreateData<WebcalCalendarEvent>("/v1/webcal/webcal-calendar-event", updateData);
        }

        public void DeleteWebcalCalendarEvent(int id)
        {
            DeleteData("/v1/webcal/webcal-calendar-event", id);
        }


        public WebcalCalendarRecurringEvent GetWebcalCalendarRecurringEvent(int id)
        {
            return GetData<WebcalCalendarRecurringEvent>(string.Format("/v1/webcal/webcal-calendar-recurring-event/{0}", id));
        }

        public List<WebcalCalendarRecurringEvent> GetWebcalCalendarRecurringEvent(int[] calendarIds = null)
        {

            var p = new Dictionary<string, object>
            {
                ["calendarIds"] = calendarIds
            };

            var uri = GetEndpointParameters("/v1/webcal/webcal-calendar-recurring-event", p);

            return GetAllData<WebcalCalendarRecurringEvent>(uri);
        }



        public WebcalCalendarRecurringEvent UpdateWebcalCalendarRecurringEvent(UpdateWebcalCalendarRecurringEvent updateData)
        {
            return UpdateData<WebcalCalendarRecurringEvent>("/v1/webcal/webcal-calendar-recurring-event", updateData);
        }


        public WebcalCalendarRecurringEvent CreateWebcalCalendarRecurringEvent(UpdateWebcalCalendarRecurringEvent updateData)
        {
            return CreateData<WebcalCalendarRecurringEvent>("/v1/webcal/webcal-calendar-recurring-event", updateData);
        }

        public void DeleteWebcalCalendarRecurringEvent(int id)
        {
            DeleteData("/v1/webcal/webcal-calendar-recurring-event", id);
        }
    }
}
