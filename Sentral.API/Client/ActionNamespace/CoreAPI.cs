using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.DataAccess;
using Newtonsoft.Json;
using JsonApiSerializer;
using Sentral.API.Model.Core;
using Sentral.API.Model.Common;
using Sentral.API.Model.Core.Include;
using Sentral.API.Model.StaffAbsences;
using Sentral.API.Common;
using Sentral.API.Model.Enrolments.Include;

namespace Sentral.API.Client.ActionNamespace
{
    public class CoreApi : AbstractApi
    {

        internal CoreApi(string baseUrl, string apiKey, string tenantCode) :
                base(baseUrl, apiKey, tenantCode)
        { }



        public List<CoreAdministrativeUser> GetCoreAdministrativeUser(int[] administrativeUserIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["administrativeUserIds"] = administrativeUserIds
            };
            var uri = GetEndpointParameters("/v1/core/core-administrative-user", p);
            return GetAllData<CoreAdministrativeUser>(uri);
        }

        public CoreAdministrativeUser GetCoreAdministrativeUser(int id)
        {
            return GetData<CoreAdministrativeUser>(string.Format("/v1/core/core-administrative-user/{0}", id));
        }

        public List<CoreClass> GetCoreClass(ICollection<CoreClassIncludeOptions> include = null, int[] ids = null, 
            int[] teacherIds = null, int[] assignedStudentIds = null, int[] assignedStaffIds = null,
            bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["teacherIds"] = teacherIds,
                ["assignedStudentIds"] = assignedStudentIds,
                ["assignedStaffIds"] = assignedStaffIds,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters<CoreClassIncludeOptions>("/v1/core/core-classes", p);
            return GetAllData<CoreClass>(uri);
        }

        public CoreClass GetCoreClass(int id, ICollection<CoreClassIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<CoreClassIncludeOptions>(string.Format("/v1/core/core-class/{0}", id), p);
            return GetData<CoreClass>(uri);
        }
        public List<CoreStaff> GetCoreClassAssignedStaff(int classId)
        {
            return GetAllData<CoreStaff>(string.Format("/v1/core/core-classes/{0}/assigned-staff", classId));
        }
        public List<CoreStudent> GetCoreClassAssignedStudents(int classId)
        {
            return GetAllData<CoreStudent>(string.Format("/v1/core/core-classes/{0}/assigned-students", classId));
        }


        public List<CoreFamily> GetCoreFamily(int[] familyIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = familyIds
            };
            var uri = GetEndpointParameters("/v1/core/core-families", p);
            return GetAllData<CoreFamily>(uri);
        }

        public CoreFamily GetCoreFamily(int id)
        {
            return GetData<CoreFamily>(string.Format("/v1/core/core-family/{0}", id));
        }

        public List<CoreHoliday> GetCoreHoliday(int[] holidayIds = null, int[] years = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = holidayIds,
                ["years"] = years
            };
            var uri = GetEndpointParameters("/v1/core/core-holiday", p);
            return GetAllData<CoreHoliday>(uri);
        }

        public CoreHoliday GetCoreHoliday(int id)
        {
            return GetData<CoreHoliday>(string.Format("/v1/core/core-holiday/{0}", id));
        }

        public List<CoreHouse> GetCoreHouse(int[] houseIds = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = houseIds,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters("/v1/core/core-house", p);
            return GetAllData<CoreHouse>(uri);
        }

        public CoreHouse GetCoreHouse(int id)
        {
            return GetData<CoreHouse>(string.Format("/v1/core/core-house/{0}", id));
        }

        public List<CorePerson> GetCorePerson(int[] PersonIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["PersonIds"] = PersonIds
            };
            var uri = GetEndpointParameters("/v1/core/core-person", p);
            return GetAllData<CorePerson>(uri);
        }

        public CorePerson GetCorePerson(int id)
        {
            return GetData<CorePerson>(string.Format("/v1/core/core-person/{0}", id));
        }

        public List<CoreStudentPersonRelation> GetCorePersonStudentContacts(int personId)
        {
            return GetAllData<CoreStudentPersonRelation>(string.Format("/v1/core/core-person/{0}/contacts", personId));
        }

        public List<CoreRollclass> GetCoreRollclass(int[] rollclassIds = null, int[] enterpriseUseIds= null,
               bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = rollclassIds,
                ["enterpriseUseIds"] = enterpriseUseIds,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters("/v1/core/core-rollclass", p);
            return GetAllData<CoreRollclass>(uri);
        }

        public CoreRollclass GetCoreRollclass(int id)
        {
            return GetData<CoreRollclass>(string.Format("/v1/core/core-rollclass/{0}", id));
        }

        public List<CoreStaff> GetCoreStaff(ICollection<CoreStaffIncludeOptions> include = null, int[] staffIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = staffIds
            };
            var uri = GetEndpointParameters<CoreStaffIncludeOptions>("/v1/core/core-staff", p);
            return GetAllData<CoreStaff>(uri);
        }

        public CoreStaff GetCoreStaff(int id, ICollection<CoreStaffIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<CoreStaffIncludeOptions>(string.Format("/v1/core/core-staff/{0}", id), p);
            return GetData<CoreStaff>(uri);

        }
        public List<CoreClass> GetCoreStaffAssignedClasses(int staffId, ICollection<CoreClassIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<CoreClassIncludeOptions>(string.Format("/v1/core/core-staff/{0}/assigned-classes", staffId), p);
            return GetAllData<CoreClass>(uri);
        }

        public List<CoreStudent> GetCoreStudent(ICollection<CoreStudentIncludeOptions> include = null, int[] staffIds = null,
            bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = staffIds,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters<CoreStudentIncludeOptions>("/v1/core/core-student", p);
            return GetAllData<CoreStudent>(uri);
        }

        public CoreStudent GetCoreStudent(int id, ICollection<CoreStudentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<CoreStudentIncludeOptions>(string.Format("/v1/core/core-student/{0}", id), p);
            return GetData<CoreStudent>(uri);
        }
        public List<CoreClass> GetCoreStudentAttendedClasses(int studentId, ICollection<CoreClassIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<CoreClassIncludeOptions>(string.Format("/v1/core/core-student/{0}/attended-classes", studentId), p);
            return GetAllData<CoreClass>(uri);
        }

        public List<CoreStudentPersonRelation> GetCoreStudentContacts(int studentId)
        {
            var uri = string.Format("/v1/core/core-student/{0}/contacts", studentId);
            return GetAllData<CoreStudentPersonRelation>(uri);
        }

        public List<CoreStudentRelationship> GetCoreStudentRelationship(ICollection<CoreStudentRelationshipIncludeOptions> include = null,
            int[] studentRelationshipIds = null, int[] studentIds = null,  bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = studentRelationshipIds,
                ["studentIds"] = studentIds,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters<CoreStudentRelationshipIncludeOptions>("/v1/core/core-student-relationships", p);
            return GetAllData<CoreStudentRelationship>(uri);
        }

        public CoreStudentRelationship GetCoreStudentRelationship(int id, ICollection<CoreStudentRelationshipIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<CoreStudentRelationshipIncludeOptions>(string.Format("/v1/core/core-student-relationship/{0}", id), p);
            return GetData<CoreStudentRelationship>(uri);
        }

        public BinaryFile GetStudentPhoto(int studentId, int? width = null, int? height = null)
        {
            var p = new Dictionary<string, object>
            {
                ["width"] = width,
                ["height"] = height,
            };

            var uri = GetEndpointParameters(string.Format("/v1/core/core-student/{0}/photo", studentId), p);

            return GetBinaryFile(uri);
        }

        public List<CoreSubject> GetCoreSubject(int[] ids = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["includeInactive"] = includeInactive
            };
            var uri = GetEndpointParameters("/v1/core/core-subject", p);
            return GetAllData<CoreSubject>(uri);
        }

        public CoreSubject GetCoreSubject(int id)
        {
            return GetData<CoreSubject>(string.Format("/v1/core/core-subject/{0}", id));
        }
        public List<Date> GetDate(DateTime? fromDate = null, DateTime? toDate = null)
        {
            var p = new Dictionary<string, object>
            {
                ["fromDate"] = fromDate,
                ["toDate"] = toDate
            };
            var uri = GetEndpointParameters("/v1/core/date", p);
            return GetAllData<Date>(uri);
        }

        public Date GetDate(DateTime id)
        {

            return GetData<Date>(string.Format("/v1/core/date/{0}", id.ToString("yyyyMMdd")));
        }

        public List<CoreTerm> GetTerm(int[] years = null)
        {
            var p = new Dictionary<string, object>
            {
                ["years"] = years
            };
            var uri = GetEndpointParameters("/v1/core/core-terms", p);
            return GetAllData<CoreTerm>(uri);
        }

        public CoreTerm GetTerm(int year, int term)
        {
            return GetData<CoreTerm>(string.Format("/v1/core/core-term/{0}-{1}", year, term));
        }
    }
}
