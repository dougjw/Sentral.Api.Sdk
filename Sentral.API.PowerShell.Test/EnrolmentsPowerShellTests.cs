using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Model.Enrolments;
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
    }
}
