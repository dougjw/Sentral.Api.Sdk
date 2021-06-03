using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.DataAccess.Exceptions;
using Sentral.API.Model.Enrolments;
using Sentral.API.Model.Enrolments.Update;
using Sentral.API.PowerShell.Enrolments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace Sentral.API.PowerShell.Test
{
    [TestClass]
    public class EnrolmentsPowerShellTests : AbstractPowerShellTest
    {

        [TestMethod]
        public void GetManyStudentSPowerShellTest()
        {


            var students = RunScript<Collection<Student>>(
                "Get-SntEnrStudent",
                new Dictionary<string, object>()
                    {
                        { "StudentIds", new int[]{1, 2 } }
                    }
                );

            Assert.IsTrue(students.Count == 1 && students[0].Count == 2);
        }

        [TestMethod]
        public void SetOneStaffPowerShellTest()
        {
            if (IsTestSite)
            {
                Staff staff = null;
                Staff updatedStaff = null;

                var getResponse = RunScript<Staff>(
                    "Get-SntEnrStaff",
                    new Dictionary<string, object>()
                        {
                            { "StaffId", 1 }
                        }
                    );

                if(getResponse.Count == 1)
                {
                    staff = getResponse[0];
                }

                var updateValue = staff != null && staff.TimetableCode != null && staff.TimetableCode != "T999" ? "A000" : "T999";

                var updateResponse = RunScript<Staff>(
                    "Set-SntEnrStaff",
                    new Dictionary<string, object>()
                        {
                            { "StaffId", 1 },
                            { "TimetableCode", updateValue },
                        }
                    );

                if(updateResponse.Count == 1)
                {
                    updatedStaff = updateResponse[0];
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


                var getResponse = RunScript<Student>(
                    "Get-SntEnrStudent",
                    new Dictionary<string, object>()
                        {
                            { "StudentId", 1 }
                        }
                    );

                if(getResponse.Count == 1)
                {
                    student = getResponse[0];
                }

                var updateValue = student != null && student.AcaraId != null && student.AcaraId != "12345" ? "12345" : "67890";

                var updateResponse = RunScript<Student>(
                    "Set-SntEnrStudent",
                    new Dictionary<string, object>()
                        {
                            { "StudentId", 1 },
                            { "AcaraId", updateValue }
                        }
                    );

                if (updateResponse.Count == 1)
                {
                    updatedStudent = updateResponse[0];
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

                var getResponse = RunScript<Enrolment>(
                    "Get-SntEnrEnrolment",
                    new Dictionary<string, object>()
                        {
                            { "StudentId", 1 }
                        }
                    );

                if (getResponse.Count == 1)
                {
                    enrolment = getResponse[0];
                }

                var updateValue = !enrolment.IsBoarding;

                var setResponse = RunScript<Enrolment>(
                    "Set-SntEnrEnrolment",
                    new Dictionary<string, object>()
                        {
                            { "StudentId", 1 },
                            { "IsBoarding", updateValue }
                        }
                    );

                if (setResponse.Count == 1)
                {
                    updatedEnrolment = setResponse[0];
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

                var getResponse = RunScript<Person>(
                    "Get-SntEnrPerson",
                    new Dictionary<string, object>()
                        {
                            { "PersonId", 1 }
                        }
                    );

                if (getResponse.Count == 1)
                {
                    person = getResponse[0];
                }


                var updateFirstName = person != null && person.FirstName == "Test Emily" ?  "Test Sarah" : "Test Emily";
                var updateLastName = person != null && person.FirstName == "Test Thompson" ? "Test Smith" : "Test Thompson";


                var setResponse = RunScript<Person>(
                    "Set-SntEnrPerson",
                    new Dictionary<string, object>()
                        {
                            { "PersonId", 1 },
                            { "FirstName", updateFirstName },
                            { "LastName", updateLastName }
                        }
                    );

                if (setResponse.Count == 1)
                {
                    updatedPerson = setResponse[0];
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

                Consent newConsentResponse = null;
                Consent setConsentResponse = null;

                var getResponse = RunScript<Consent>(
                    "New-SntEnrConsent",
                    new Dictionary<string, object>()
                        {
                            { "ConsentType", consentType },
                            { "Details", consentDetails}
                        }
                    );

                if(getResponse.Count == 1)
                {
                    newConsentResponse = getResponse[0];
                }

                // Has been created
                Assert.IsTrue(newConsentResponse != null && newConsentResponse.ConsentType == consentType && newConsentResponse.Details == consentDetails);


                var setResponse = RunScript<Consent>(
                    "Set-SntEnrConsent",
                    new Dictionary<string, object>()
                        {
                            { "Consent", newConsentResponse},
                            { "ConsentType", replacementConsentType }
                        }
                    );
                if(setResponse.Count == 1)
                {
                    setConsentResponse = setResponse[0];
                }

                // Is updated
                Assert.IsTrue(setConsentResponse != null && setConsentResponse.ConsentType == replacementConsentType);

                RunScript<Consent>(
                    "Remove-SntEnrConsent",
                    new Dictionary<string, object>()
                        {
                            { "Consent", setConsentResponse}
                        }
                    );


                // Is Deleted
                Assert.ThrowsException<CmdletInvocationException>(()=> RunScript<Consent>(
                    "Get-SntEnrConsent",
                    new Dictionary<string, object>()
                        {
                            { "ConsentId", setConsentResponse.ID }
                        }
                    )
                );

            }
        }



        [TestMethod]
        public void NewSetDelConsentLinkPowerShellTest()
        {
            if (IsTestSite)
            {
                ConsentLink newConsentLinkResponse = null;
                ConsentLink setConsentLinkResponse = null;

                var newResponse = RunScript<ConsentLink>(
                    "New-SntEnrConsentLink",
                    new Dictionary<string, object>()
                        {
                            { "Person", new Person() { ID = 1 } },
                            { "Consent", new Consent() { ID = 1 } },
                            { "ConsentedBy", new Person() { ID = 2 } },
                            { "ConsentGiven", true }
                        }
                    );

                if (newResponse.Count == 1)
                {
                    newConsentLinkResponse = newResponse[0];
                }

                // Has been created
                Assert.IsTrue(
                        newConsentLinkResponse != null &&
                        newConsentLinkResponse.ConsentGiven
                    );

                var setResponse = RunScript<ConsentLink>(
                    "Set-SntEnrConsentLink",
                    new Dictionary<string, object>()
                        {
                            { "ConsentLink", newConsentLinkResponse },
                            { "ConsentGiven", false }
                        }
                    );
                if(setResponse.Count == 1)
                {
                    setConsentLinkResponse = setResponse[0];
                }

                // Is updated
                Assert.IsTrue(
                        setConsentLinkResponse != null && 
                        !setConsentLinkResponse.ConsentGiven
                    );


                RunScript<ConsentLink>(
                    "Remove-SntEnrConsentLink",
                    new Dictionary<string, object>()
                        {
                            { "ConsentLink", setConsentLinkResponse }
                        }
                    );

                // Is Deleted?
                Assert.ThrowsException<CmdletInvocationException>(() =>
                    RunScript<ConsentLink>(
                        "Get-SntEnrConsentLink",
                        new Dictionary<string, object>()
                            {
                                { "ConsentLinkId", setConsentLinkResponse.ID }
                            }
                        )
                );

            }
        }

        [TestMethod]
        public void NewSetDelPersonEmailPowerShellTest()
        {
            if (IsTestSite)
            {
                PersonEmail newPersonEmailResponse = null;
                PersonEmail setPersonEmailResponse = null;

                var testEmail = "test@testdomain.net";
                var testUpdatedEmail = "test@testseconddomain.net";

                var newResponse = RunScript<PersonEmail>(
                    "New-SntEnrPersonEmail",
                    new Dictionary<string, object>()
                        {
                            { "Email", testEmail },
                            { "EmailType", "01" },
                            { "Owner", new Person() { ID =1 } }
                        }
                    );

                if (newResponse.Count == 1)
                {
                    newPersonEmailResponse = newResponse[0];
                }

                // Has been created
                Assert.IsTrue(
                        newPersonEmailResponse != null &&
                        newPersonEmailResponse.Email == testEmail
                    );


                var setResponse = RunScript<PersonEmail>(
                    "Set-SntEnrPersonEmail",
                    new Dictionary<string, object>()
                        {
                            { "PersonEmail", newPersonEmailResponse },
                            { "Email", testUpdatedEmail }
                        }
                    );
                if(setResponse.Count == 1)
                {
                    setPersonEmailResponse = setResponse[0];
                }

                // Is updated
                Assert.IsTrue(
                        setPersonEmailResponse != null &&
                        setPersonEmailResponse.Email == testUpdatedEmail
                    );


                RunScript<PersonEmail>(
                    "Remove-SntEnrPersonEmail",
                    new Dictionary<string, object>()
                        {
                            { "PersonEmail", newPersonEmailResponse }
                        }
                    );


                var getPersonEmailCmdlet = new GetSntEnrPersonEmail()
                {
                    PersonEmailId = setPersonEmailResponse.ID
                };


                // Is Deleted?
                Assert.ThrowsException<CmdletInvocationException>(() =>
                    RunScript<PersonEmail>(
                        "Get-SntEnrPersonEmail",
                        new Dictionary<string, object>()
                            {
                                { "PersonEmailId", setPersonEmailResponse.ID }
                            }
                        )
                );

            }
        }

        [TestMethod]
        public void NewSetDelStaffQualificationPowerShellTest()
        {
            if (IsTestSite)
            {
                StaffQualification newStaffQualificationResponse = null;
                StaffQualification setStaffQualificationResponse = null;

                var testCert = "Some Test Cert";
                var testUpdatedCert = "A better Test Cert";

                var newResponse = RunScript<StaffQualification>(
                    "New-SntEnrStaffQualification",
                    new Dictionary<string, object>()
                        {
                            { "Qualification", testCert },
                            { "QualificationType", EnumStaffQualificiationType.certificate },
                            { "From", "UTS" },
                            { "DateAchieved", new DateTime(2010, 10, 15) },
                            { "Staff", new Staff() { ID = 1} }
                        }
                    );

                if (newResponse.Count == 1)
                {
                    newStaffQualificationResponse = newResponse[0];
                }

                // Has been created
                Assert.IsTrue(
                        newStaffQualificationResponse != null &&
                        newStaffQualificationResponse.Qualification == testCert
                    );


                var setResponse = RunScript<StaffQualification>(
                    "Set-SntEnrStaffQualification",
                    new Dictionary<string, object>()
                        {
                            { "StaffQualification", newStaffQualificationResponse },
                            { "Qualification", testUpdatedCert }
                        }
                    );
                if (setResponse.Count == 1)
                {
                    setStaffQualificationResponse = setResponse[0];
                }

                // Is updated
                Assert.IsTrue(
                        setStaffQualificationResponse != null &&
                        setStaffQualificationResponse.Qualification == testUpdatedCert
                    );

                RunScript<StaffQualification>(
                    "Remove-SntEnrStaffQualification",
                    new Dictionary<string, object>()
                        {
                            { "StaffQualification", newStaffQualificationResponse }
                        }
                    );

                // Is Deleted?
                Assert.ThrowsException<CmdletInvocationException>(() =>
                    RunScript<StaffQualification>(
                        "Get-SntEnrStaffQualification",
                        new Dictionary<string, object>()
                            {
                                { "QualificationId", setStaffQualificationResponse.ID }
                            }
                        )
                );

            }
        }

        [TestMethod]
        public void NewSetDelPersonPhonePowerShellTest()
        {
            if (IsTestSite)
            {
                PersonPhone newPersonPhoneResponse = null;
                PersonPhone setPersonPhoneResponse = null;

                var testPhone = "0400000000";
                var testUpdatedPhone = "0499999999";


                var newResponse = RunScript<PersonPhone>(
                    "New-SntEnrPersonPhone",
                    new Dictionary<string, object>()
                        {
                            { "Number", testPhone },
                            { "Extension", null },
                            { "PhoneType", "01" },
                            { "Owner", new Person() { ID = 1 } }
                        }
                    );

                if (newResponse.Count == 1)
                {
                    newPersonPhoneResponse = newResponse[0];
                }

                // Has been created
                Assert.IsTrue(
                        newPersonPhoneResponse != null &&
                        newPersonPhoneResponse.Number == testPhone
                    );

                var setResponse = RunScript<PersonPhone>(
                    "Set-SntEnrPersonPhone",
                    new Dictionary<string, object>()
                        {
                            { "PersonPhone", newPersonPhoneResponse },
                            { "Number", testUpdatedPhone }
                        }
                    );

                if (setResponse.Count == 1)
                {
                    setPersonPhoneResponse = setResponse[0];
                }

                // Is updated
                Assert.IsTrue(
                        setPersonPhoneResponse != null &&
                        setPersonPhoneResponse.Number == testUpdatedPhone
                    );

                RunScript<PersonPhone>(
                    "Remove-SntEnrPersonPhone",
                    new Dictionary<string, object>()
                        {
                            { "PersonPhone", newPersonPhoneResponse }
                        }
                    );

                // Is Deleted?
                Assert.ThrowsException<RestClientException>(() =>
                    RunScript<PersonPhone>(
                        "Get-SntEnrPersonPhone",
                        new Dictionary<string, object>()
                            {
                                { "PersonPhoneId", setPersonPhoneResponse.ID }
                            }
                        )
                );

            }
        }
    }
}
