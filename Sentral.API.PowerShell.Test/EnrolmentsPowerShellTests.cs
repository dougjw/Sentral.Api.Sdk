using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Model.Enrolments;
using Sentral.API.Model.Enrolments.Update;
using System.Collections.Generic;

namespace Sentral.API.PowerShell.Test
{
    [TestClass]
    public class EnrolmentsPowerShellTests : AbstractPowerShellTest
    {

        [TestMethod]
        public void GetManyStudentSPowerShellTest()
        {
            List<Student> students = new List<Student>();

            var studentsCmd = new Enrolments.GetSntEnrStudent();

            studentsCmd.StudentIds = new int[] { 1, 2 };

            var enumerator = studentsCmd.Invoke<List<Student>>().GetEnumerator();

            while (enumerator.MoveNext())
            {
                foreach (var student in enumerator.Current) {
                    students.Add(student);
                };
            }


            Assert.IsTrue(students.Count == 2);
        }

        [TestMethod]
        public void SetOneStudentPowerShellTest()
        {
            if (IsTestSite) {
                Student student = null;

                Student updatedStudent = null;

                var studentsCmd = new Enrolments.GetSntEnrStudent();

                studentsCmd.StudentId = 1;


                var enumerator = studentsCmd.Invoke<Student>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    student = enumerator.Current;
                }

                var updateValue = student != null && student.AcaraId != null && student.AcaraId != "12345" ? "12345" : "67890";


                var updateStudentsCmd = new Enrolments.SetSntEnrStudent()
                {
                    StudentId = 1,
                    AcaraId = updateValue
                };

                enumerator = updateStudentsCmd.Invoke<Student>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    updatedStudent = enumerator.Current;
                }


                Assert.IsTrue(updatedStudent != null && updatedStudent.ID == 1 && updatedStudent.AcaraId == updateValue);
            }
        }
    }
}
