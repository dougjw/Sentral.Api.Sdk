using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Model.Enrolments;
using Sentral.API.Model.Enrolments.Update;
using Sentral.API.PowerShell.Enrolments;
using System.Collections.Generic;
using System.Linq;

namespace Sentral.API.PowerShell.Test
{
    [TestClass]
    public class EnrolmentsPowerShellTests : AbstractPowerShellTest
    {

        [TestMethod]
        public void GetManyStudentSPowerShellTest()
        {
            List<Student> students = new List<Student>();

            var studentsCmd = new Enrolments.GetSntEnrStudent
            {
                StudentIds = new int[] { 1, 2 }
            };

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

                var studentsCmd = new Enrolments.GetSntEnrStudent
                {
                    StudentId = 1
                };


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
        
        [TestMethod]
        public void SetOneEnrolmentPowerShellTest()
        {
            if (IsTestSite) {
                Enrolment enrolment = null;

                Enrolment updatedEnrolment = null;

                var studentsCmd = new GetSntEnrEnrolment
                {
                    StudentId = 1
                };


                var enumerator = studentsCmd.Invoke<Enrolment>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    enrolment = enumerator.Current;
                }

                var updateValue = !enrolment.IsBoarding;


                var updateEnrolmentsCmd = new Enrolments.SetSntEnrEnrolment()
                {
                    EnrolmentId = 1,
                    IsBoarding = updateValue
                };

                enumerator = updateEnrolmentsCmd.Invoke<Enrolment>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    updatedEnrolment = enumerator.Current;
                }


                Assert.IsTrue(updatedEnrolment != null && updatedEnrolment.ID == 1 && updatedEnrolment.IsBoarding == updateValue);
            }
        }

        [TestMethod]
        public void NewSetDelConsentPowerShellTest()
        {
            if (IsTestSite)
            {

                var consentType = "Consent to Test";
                var consentDetails = "This is a detailed description of the Consent to Test.";

                var replacementConsentType = "Consent to Test2";

                var newConsentCmdlet = new NewSntEnrConsent() 
                {
                    ConsentType = consentType,
                    Details = consentDetails
                };

                Consent newConsentResponse = newConsentCmdlet.Invoke<Consent>().FirstOrDefault();
                
                // Has been created
                Assert.IsTrue(newConsentResponse != null && newConsentResponse.ConsentType == consentType && newConsentResponse.Details == consentDetails);


                var setConsentCmdlet = new SetSntEnrConsent()
                {
                    Consent = newConsentResponse,
                    ConsentType = replacementConsentType
                };

                var setConsentResponse = setConsentCmdlet.Invoke<Consent>().FirstOrDefault();

                // Is updated
                Assert.IsTrue(setConsentResponse != null && setConsentResponse.ConsentType == replacementConsentType);


                var removeConsentCmdlet = new RemoveSntEnrConsent()
                {
                    Consent = setConsentResponse
                };

                removeConsentCmdlet.Invoke();


                var getConsentCmdlet = new GetSntEnrConsent()
                {
                    ConsentId = setConsentResponse.ID
                };

                var getConsentResponse = getConsentCmdlet.Invoke<Consent>().FirstOrDefault();


                // Is deleted
                Assert.IsTrue(getConsentResponse == null);
            }
        }
    }
}
