using Sentral.API.Model.Common;

namespace Sentral.API.Model.WebCal.Update
{
    public class SimpleWebCalCalendarLink : AbstractSimpleLink
    {
        private const string _typeName = "webcalCalendar";
        public SimpleWebCalCalendarLink() : base(_typeName) { }
    }
}