using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sentral.API.PowerShell.Test
{
    [TestClass]
    public class EnrolmentsPowerShellTests : AbstractPowerShellTest
    {

        [TestMethod]
        public void GetManyStudentSPowerShellTest()
        {

            var students = new Enrolments.GetSntEnrStudent();

            students.StudentIds = new int[] { 1, 2 };

            students.Invoke();
            //SAPI.Enrolments.GetStudent(1);

        }
    }
}
