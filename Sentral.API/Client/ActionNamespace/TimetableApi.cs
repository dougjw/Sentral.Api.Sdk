using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.DataAccess;
using Newtonsoft.Json;
using JsonApiSerializer;
using Sentral.API.Model.Timetables;
using Sentral.API.Model.Common;
using Sentral.API.Model.Timetables.Include;
using Sentral.API.Common;

namespace Sentral.API.Client.ActionNamespace
{
    public class TimetableApi : AbstractApi
    {

        internal TimetableApi(string baseUrl, string apiKey, string tenantCode) :
                base(baseUrl, apiKey, tenantCode)
        { }


        public List<TimetableStudent> GetTimetableStudent(int[] ids = null,
            int[] coreStudentIds = null, int[] enrolmentStudentIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["coreStudentIds"] = coreStudentIds,
                ["enrolmentStudentIds"] = enrolmentStudentIds
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-student", p);
            return GetAllData<TimetableStudent>(uri);
        }

        public TimetableStudent GetTimetableStudent(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-student/{0}", id);
            return GetData<TimetableStudent>(uri);
        }
    }
}
