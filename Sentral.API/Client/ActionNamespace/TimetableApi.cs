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

        public List<TimetableLesson> GetStaffTimetableLessons(int staffId, DateTime date)
        {
            var uri = string.Format("/v1/timetables/staff/{0}/timetable-lessons/{1}", staffId, date);
            return GetAllData<TimetableLesson>(uri);
        }

        public List<TimetableLesson> GetStaffTimetableLessons(int staffId,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var p = new Dictionary<string, object>
            {
                ["startDate"] = startDate,
                ["endDate"] = endDate
            };
            var uri = GetEndpointParameters(string.Format("/v1/timetables/staff/{0}/timetable-lessons", staffId), p);
            return GetAllData<TimetableLesson>(uri);
        }

        public List<TimetableLesson> GetStudentTimetableLessons(int studentId,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var p = new Dictionary<string, object>
            {
                ["startDate"] = startDate,
                ["endDate"] = endDate
            };
            var uri = GetEndpointParameters(string.Format("/v1/timetables/student/{0}/timetable-lessons", studentId), p);
            return GetAllData<TimetableLesson>(uri);
        }

        public List<TimetableLesson> GetStudentTimetableLessons(int studentId, DateTime date)
        {
            var uri = string.Format("/v1/timetables/student/{0}/timetable-lessons/{1}", studentId, date);
            return GetAllData<TimetableLesson>(uri);
        }


        public List<TimetableCalendarDate> GetTimetableCalendarDate(int[] ids = null,
            DateTime? from = null, DateTime? to = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["from"] = from,
                ["to"] = to
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-calendar-date", p);
            return GetAllData<TimetableCalendarDate>(uri);
        }

        public TimetableCalendarDate TimetableCalendarDate(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-calendar-date/{0}", id);
            return GetData<TimetableCalendarDate>(uri);
        }

        public List<TimetableClass> GetTimetableClass(int[] ids = null,
            int[] coreStudentIds = null, int[] enrolmentStudentIds = null,
            int[] subjectIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["coreStudentIds"] = coreStudentIds,
                ["enrolmentStudentIds"] = enrolmentStudentIds,
                ["subjectIds"] = subjectIds
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-class", p);
            return GetAllData<TimetableClass>(uri);
        }

        public TimetableClass GetTimetableClass(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-class/{0}", id);
            return GetData<TimetableClass>(uri);
        }
        public List<TimetableStudent> GetTimetableClassStudents(int classId)
        {
            var uri = string.Format("/v1/timetables/timetable-class/{0}/timetable-students", classId);
            return GetAllData<TimetableStudent>(uri);
        }

        public List<TimetableClassLesson> GetTimetableClassLesson(TimetableLessonIncludeOptions[] include = null,
            int[] ids = null, int[] roomIds = null, int[] periodInDayIds = null,
            int[] classIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["roomIds"] = roomIds,
                ["periodInDayIds"] = periodInDayIds,
                ["classIds"] = classIds
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-class-lesson", p);
            return GetAllData<TimetableClassLesson>(uri);
        }

        public TimetableClassLesson GetTimetableClassLesson(int id, TimetableLessonIncludeOptions[] include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters(string.Format("/v1/timetables/timetable-class-lesson/{0}", id),p);
            return GetData<TimetableClassLesson>(uri);
        }

        public TimetableTeacher GetTimetableClassLessonStaff(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-class-lesson/{0}/timetable-teachers", classLessonId);
            return GetData<TimetableTeacher>(uri);
        }

        public TimetableStudent GetTimetableClassLessonStudent(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-class-lesson/{0}/timetable-students", classLessonId);
            return GetData<TimetableStudent>(uri);
        }

        public Model.Core.CoreStaff GetTimetableClassLessonCoreStaff(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-class-lesson/{0}/core-staff", classLessonId);
            return GetData<Model.Core.CoreStaff>(uri);
        }

        public Model.Core.CoreStudent GetTimetableClassLessonCoreStudent(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-class-lesson/{0}/core-students", classLessonId);
            return GetData<Model.Core.CoreStudent>(uri);
        }

        public List<TimetableDailyLesson> GetTimetableDailyLesson( TimetableLessonIncludeOptions[] include = null,
            int[] ids = null,int[] periodIds = null, int[] classIds = null,
            DateTime? from = null, DateTime? to = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["periodIds"] = periodIds,
                ["classIds"] = classIds,
                ["from"] = from,
                ["to"] = to
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-daily-lesson", p);
            return GetAllData<TimetableDailyLesson>(uri);
        }

        public TimetableDailyLesson GetTimetableDailyLesson(int id, TimetableLessonIncludeOptions[] include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters(string.Format("/v1/timetables/timetable-daily-lesson/{0}", id), p);
            return GetData<TimetableDailyLesson>(uri);
        }

        public TimetableTeacher GetTimetableDailyLessonStaff(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-daily-lesson/{0}/timetable-teachers", classLessonId);
            return GetData<TimetableTeacher>(uri);
        }

        public TimetableStudent GetTimetableDailyLessonStudent(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-daily-lesson/{0}/timetable-students", classLessonId);
            return GetData<TimetableStudent>(uri);
        }

        public Model.Core.CoreStaff GetTimetableDailyLessonCoreStaff(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-daily-lesson/{0}/core-staff", classLessonId);
            return GetData<Model.Core.CoreStaff>(uri);
        }

        public Model.Core.CoreStudent GetTimetableDailyLessonCoreStudent(int classLessonId)
        {
            var uri = string.Format("/v1/timetables/timetable-daily-lesson/{0}/core-students", classLessonId);
            return GetData<Model.Core.CoreStudent>(uri);
        }

        public List<TimetableDay> GetTimetableDay(int[] ids = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-day", p);
            return GetAllData<TimetableDay>(uri);
        }

        public TimetableDay GetTimetableDay(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-day/{0}", id);
            return GetData<TimetableDay>(uri);
        }

        public List<TimetablePeriod> GetTimetablePeriod(int[] ids = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-period", p);
            return GetAllData<TimetablePeriod>(uri);
        }

        public TimetablePeriod GetTimetablePeriod(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-period/{0}", id);
            return GetData<TimetablePeriod>(uri);
        }

        public List<TimetablePeriodInDay> GetTimetablePeriodInDay(int[] ids = null, int[] dayIds = null,
            int[] periodIds = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["dayIds"] = dayIds,
                ["periodIds"] = periodIds,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-period-in-day", p);
            return GetAllData<TimetablePeriodInDay>(uri);
        }

        public TimetablePeriodInDay GetTimetablePeriodInDay(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-period-in-day/{0}", id);
            return GetData<TimetablePeriodInDay>(uri);
        }

        public List<TimetableRoom> GetTimetableRoom(int[] ids = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-room", p);
            return GetAllData<TimetableRoom>(uri);
        }

        public TimetableRoom GetTimetableRoom(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-room/{0}", id);
            return GetData<TimetableRoom>(uri);
        }

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
        public List<TimetableSubject> GetTimetableSubject(int[] ids = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids
            };
            var uri = GetEndpointParameters("/v1/timetables/timetable-subject", p);
            return GetAllData<TimetableSubject>(uri);
        }

        public TimetableSubject GetTimetableSubject(int id)
        {
            var uri = string.Format("/v1/timetables/timetable-subject/{0}", id);
            return GetData<TimetableSubject>(uri);
        }

    }
}
