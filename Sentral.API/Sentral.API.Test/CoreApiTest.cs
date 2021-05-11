using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using System;
using System.Text;

namespace Sentral.API.Test
{
    [TestClass]
    public class CoreApiTest : AbstractApiTest
    {

        private int _knownPersonId = 40;
        private int _knownTeachingStaffId = 3;
        private int _knownStudentId = 1385;

        [TestMethod]
        public void GetOneCoreAdministrativeUser()
        {

            var x = SAPI.Core.GetCoreAdministrativeUser(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Email));
        }

        [TestMethod]
        public void GetOneCoreClass()
        {

            var x = SAPI.Core.GetCoreClass(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.ExternalId));
        }

        [TestMethod]
        public void GetCoreClassAssignedStaff()
        {

            var x = SAPI.Core.GetCoreClassAssignedStaff(1);

            Assert.IsTrue(x != null && x.Count>=0);
        }

        [TestMethod]
        public void GetClassAssignedStudents()
        {

            var x = SAPI.Core.GetCoreClassAssignedStudents(1);

            Assert.IsTrue(x != null && x.Count >= 0);
        }


        [TestMethod]
        public void GetOneCoreFamily()
        {
            int knownFamilyId = 743;
            var x = SAPI.Core.GetCoreFamily(knownFamilyId);

            Assert.IsTrue(x != null && x.ID == knownFamilyId && !string.IsNullOrWhiteSpace(x.ExternalId));
        }


        [TestMethod]
        public void GetOneCoreHoliday()
        {

            var x = SAPI.Core.GetCoreHoliday(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }


        [TestMethod]
        public void GetOneCoreHouse()
        {

            var x = SAPI.Core.GetCoreHouse(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }


        [TestMethod]
        public void GetOneCorePerson()
        {
            var x = SAPI.Core.GetCorePerson(_knownPersonId);

            Assert.IsTrue(x != null && x.ID == _knownPersonId && !string.IsNullOrWhiteSpace(x.FirstName));
        }


        [TestMethod]
        public void GetOneCorePersonStudentContacts()
        {

            var x = SAPI.Core.GetCorePersonStudentContacts(_knownPersonId);

            Assert.IsTrue(x != null && x.Count >= 1 && !string.IsNullOrWhiteSpace(x[0].ExternalId));
        }


        [TestMethod]
        public void GetOneCoreRollclass()
        {
            int knownRollclassId = 123;
            var x = SAPI.Core.GetCoreRollclass(knownRollclassId);

            Assert.IsTrue(x != null && x.ID == knownRollclassId && !string.IsNullOrWhiteSpace(x.Name));
        }


        [TestMethod]
        public void GetOneCoreStaff()
        {

            var x = SAPI.Core.GetCoreStaff(_knownTeachingStaffId);

            Assert.IsTrue(x != null && x.ID == _knownTeachingStaffId && !string.IsNullOrWhiteSpace(x.EmploymentStatus));
        }


        [TestMethod]
        public void GetCoreStaffAssignedClasses()
        {
            var x = SAPI.Core.GetCoreStaffAssignedClasses(_knownTeachingStaffId);

            Assert.IsTrue(x != null && x.Count >= 1 );
        }


        [TestMethod]
        public void GetOneCoreStudent()
        {

            var x = SAPI.Core.GetCoreStudent(_knownStudentId);

            Assert.IsTrue(x != null && x.ID == _knownStudentId && !string.IsNullOrWhiteSpace(x.FirstName));
        }


        [TestMethod]
        public void GetCoreStudentAttendedClasses()
        {

            var x = SAPI.Core.GetCoreStudentAttendedClasses(_knownStudentId);

            Assert.IsTrue(x != null && x.Count >= 1);

        }


        [TestMethod]
        public void GetCoreStudentContacts()
        {

            var x = SAPI.Core.GetCoreStudentContacts(_knownStudentId);

            Assert.IsTrue(x != null && x.Count >= 1);
        }


        [TestMethod]
        public void GetOneCoreStudentRelationship()
        {

            var x = SAPI.Core.GetCoreStudentRelationship(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Relationship));
        }


        // No Data to test
        //[TestMethod]
        //public void GetOneCoreSubject()
        //{

        //    var x = SAPI.Core.GetCoreSubject(1);

        //    Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        //}


        [TestMethod]
        public void GetOneDate()
        {

            var x = SAPI.Core.GetDate(new DateTime(2021,1,1));

            Assert.IsTrue(x != null && !string.IsNullOrWhiteSpace(x.Code));
        }


        [TestMethod]
        public void GetOneTerm()
        {

            var x = SAPI.Core.GetTerm(2020, 4);

            Assert.IsTrue(x != null && x.ID == "2020-4" && !string.IsNullOrWhiteSpace(x.Year));
        }

    }
}
