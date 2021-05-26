using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.DataAccess.Exceptions;
using Sentral.API.Model.Enrolments;
using Sentral.API.Model.Enrolments.Update;
using Sentral.API.PowerShell.Enrolments;
using System;
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
        public void SetOneStaffPowerShellTest()
        {
            if (IsTestSite)
            {
                Staff staff = null;

                Staff updatedStaff = null;

                var studentsCmd = new GetSntEnrStaff
                {
                    StaffId = 1
                };


                var enumerator = studentsCmd.Invoke<Staff>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    staff = enumerator.Current;
                }

                var updateValue = staff != null && staff.TimetableCode != null && staff.TimetableCode != "T999" ? "A000" : "T999";


                var updateStudentsCmd = new SetSntEnrStaff()
                {
                    StaffId = 1,
                    TimetableCode = updateValue
                };

                enumerator = updateStudentsCmd.Invoke<Staff>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    updatedStaff = enumerator.Current;
                }


                Assert.IsTrue(updatedStaff != null && updatedStaff.ID == 1 && updatedStaff.TimetableCode == updateValue);
            }
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
        public void SetOnePersonPowerShellTest()
        {
            if (IsTestSite)
            {
                Person person = null;

                Person updatedPerson = null;

                var studentsCmd = new SetSntEnrPerson
                {
                    PersonId = 1
                };


                var enumerator = studentsCmd.Invoke<Person>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    person = enumerator.Current;
                }

                var updateFirstName = person != null && person.FirstName == "Test Emily" ?  "Test Sarah" : "Test Emily";
                var updateLastName = person != null && person.FirstName == "Test Thompson" ? "Test Smith" : "Test Thompson";

                var updatePersonCmd = new SetSntEnrPerson()
                {
                    PersonId = 1,
                    FirstName = updateFirstName,
                    LastName = updateLastName
                };

                enumerator = updatePersonCmd.Invoke<Person>().GetEnumerator();

                while (enumerator.MoveNext())
                {
                    updatedPerson = enumerator.Current;
                }


                Assert.IsTrue(
                        updatedPerson != null && updatedPerson.ID == 1 && 
                        updatedPerson.FirstName == updateFirstName &&
                        updatedPerson.LastName == updateLastName
                    );
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

                // Is Deleted
                Assert.ThrowsException<Exception>(()=> getConsentCmdlet.Invoke<Consent>().FirstOrDefault());

            }
        }



        [TestMethod]
        public void NewSetDelConsentLinkPowerShellTest()
        {
            if (IsTestSite)
            {

                var newConsentLinkCmdlet = new NewSntEnrConsentLink()
                {
                    Person = new Person() { ID = 1 },
                    Consent = new Consent() { ID = 1},
                    ConsentedBy = new Person() { ID = 2 },
                    ConsentGiven = true
                };


                ConsentLink newConsentLinkResponse = newConsentLinkCmdlet.Invoke<ConsentLink>().FirstOrDefault();

                // Has been created
                Assert.IsTrue(
                        newConsentLinkResponse != null &&
                        newConsentLinkResponse.ConsentGiven
                    );


                var setConsentLinkCmdlet = new SetSntEnrConsentLink()
                {
                    ConsentLink = newConsentLinkResponse,
                    ConsentGiven = false
                };

                var setConsentLinkResponse = setConsentLinkCmdlet.Invoke<ConsentLink>().FirstOrDefault();

                // Is updated
                Assert.IsTrue(
                        setConsentLinkResponse != null && 
                        !setConsentLinkResponse.ConsentGiven
                    );


                var removeConsentCmdlet = new RemoveSntEnrConsentLink()
                {
                    ConsentLink = setConsentLinkResponse
                };

                removeConsentCmdlet.Invoke<object>().FirstOrDefault();


                var getConsentLinkCmdlet = new GetSntEnrConsentLink()
                {
                    ConsentLinkId = setConsentLinkResponse.ID
                };


                // Is Deleted?
                Assert.ThrowsException<RestClientException>(() => getConsentLinkCmdlet.Invoke<ConsentLink>().FirstOrDefault());

            }
        }

        [TestMethod]
        public void NewSetDelPersonEmailPowerShellTest()
        {
            if (IsTestSite)
            {
                var testEmail = "test@testdomain.net";
                var testUpdatedEmail = "test@testseconddomain.net";

                var newConsentLinkCmdlet = new NewSntEnrPersonEmail()
                {
                    Email = testEmail,
                    EmailType = "01",
                    Owner = new Person() { ID = 1}
                };


                PersonEmail newPersonEmailResponse = newConsentLinkCmdlet.Invoke<PersonEmail>().FirstOrDefault();

                // Has been created
                Assert.IsTrue(
                        newPersonEmailResponse != null &&
                        newPersonEmailResponse.Email == testEmail
                    );


                var setPersonEmailCmdlet = new SetSntEnrPersonEmail()
                {
                    PersonEmail = newPersonEmailResponse,
                    Email = testUpdatedEmail
                };

                var setPersonEmailResponse = setPersonEmailCmdlet.Invoke<PersonEmail>().FirstOrDefault();

                // Is updated
                Assert.IsTrue(
                        setPersonEmailResponse != null &&
                        setPersonEmailResponse.Email == testUpdatedEmail
                    );


                var removeConsentCmdlet = new RemoveSntEnrPersonEmail()
                {
                    PersonEmail = setPersonEmailResponse
                };

                removeConsentCmdlet.Invoke<object>().FirstOrDefault();


                var getPersonEmailCmdlet = new GetSntEnrPersonEmail()
                {
                    PersonEmailId = setPersonEmailResponse.ID
                };


                // Is Deleted?
                Assert.ThrowsException<RestClientException>(() => getPersonEmailCmdlet.Invoke<ConsentLink>().FirstOrDefault());

            }
        }


        [TestMethod]
        public void NewSetDelPersonPhonePowerShellTest()
        {
            if (IsTestSite)
            {
                var testPhone = "0400000000";
                var testUpdatedPhone = "0499999999";
                var newConsentLinkCmdlet = new NewSntEnrPersonPhone()
                {
                    Number = testPhone,
                    Extension = null,
                    PhoneType = "01",
                    Owner = new Person() { ID = 1 }
                };


                PersonPhone newPersonPhoneResponse = newConsentLinkCmdlet.Invoke<PersonPhone>().FirstOrDefault();

                // Has been created
                Assert.IsTrue(
                        newPersonPhoneResponse != null &&
                        newPersonPhoneResponse.Number == testPhone
                    );


                var setPersonPhoneCmdlet = new SetSntEnrPersonPhone()
                {
                    PersonPhone = newPersonPhoneResponse,
                    Phone = testUpdatedPhone
                };

                var setPersonPhoneResponse = setPersonPhoneCmdlet.Invoke<PersonPhone>().FirstOrDefault();

                // Is updated
                Assert.IsTrue(
                        setPersonPhoneResponse != null &&
                        setPersonPhoneResponse.Number == testUpdatedPhone
                    );


                var removeConsentCmdlet = new RemoveSntEnrPersonPhone()
                {
                    PersonPhone = setPersonPhoneResponse
                };

                removeConsentCmdlet.Invoke<object>().FirstOrDefault();


                var getPersonPhoneCmdlet = new GetSntEnrPersonPhone()
                {
                    PersonPhoneId = setPersonPhoneResponse.ID
                };


                // Is Deleted?
                Assert.ThrowsException<RestClientException>(() => getPersonPhoneCmdlet.Invoke<ConsentLink>().FirstOrDefault());

            }
        }
    }
}
