using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentral.API.Client;
using Sentral.API.Model.Enrolments.Include;
using System.Text;
using Sentral.API.Common;
using Sentral.API.Model.Reports.Include;
using System.Collections.Generic;

namespace Sentral.API.Test
{
    [TestClass]
    public class EnrolmentApiTest : AbstractApiTest
    {
        // No Abilities to test
        //[TestMethod]
        //public void GetOneAbilityTest()
        //{

        //    var x = sapi.Enrolments.GetAbility(1);

        //    Assert.IsTrue(x != null && x.ID == 2 && !string.IsNullOrWhiteSpace(x.LastName));
        //}


        [TestMethod]
        public void GetOneAcademicPeriodTest()
        {

            var x = SAPI.Enrolments.GetAcademicPeriod(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }

        [TestMethod]
        public void GetOneAddressTest()
        {

            var x = SAPI.Enrolments.GetHouseholdAddress(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.ToString()));
        }


        [TestMethod]
        public void GetOneCampusTest()
        {

            var x = SAPI.Enrolments.GetCampus(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }

        // No data to test
        //[TestMethod]
        //public void GetOneClassTest()
        //{

        //    var x = sapi.Enrolments.GetClass(1);

        //    Assert.IsTrue(x != null && x.ID == 2 && !string.IsNullOrWhiteSpace(x.Name));
        //}

        // No data to test
        //[TestMethod]
        //public void GetOneClassSubjectTest()
        //{

        //    var x = sapi.Enrolments.GetClassSubject(1);

        //    Assert.IsTrue(x != null && x.ID == 2 && !string.IsNullOrWhiteSpace(x.Name));
        //}



       [TestMethod]
        public void GetOneConsentTest()
        {

            var x = SAPI.Enrolments.GetConsent(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.ConsentType));
        }

        [TestMethod]
        public void GetOneConsentLinkTest()
        {

            var x = SAPI.Enrolments.GetPersonConsentLink(1);

            Assert.IsTrue(x != null && x.ID == 1 && x.Consent != null);
        }


        [TestMethod]
        public void GetOneDisabilityTest()
        {

            var x = SAPI.Enrolments.GetDisabilityOthers(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }


        [TestMethod]
        public void GetOneDoctorTest()
        {

            var x = SAPI.Enrolments.GetDisabilityOthers(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }


        [TestMethod]
        public void GetOneEmergencyContactTest()
        {

            var x = SAPI.Enrolments.GetEmergencyContactLink(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }

        [TestMethod]
        public void GetOneEnrolmentTest()
        {

            var x = SAPI.Enrolments.GetEnrolment(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.RollclassName));
        }

        [TestMethod]
        public void UpdateOneEnrolmentTest()
        {

            // Only run test on sandbox
            if (IsTestSite)
            {
                var enrolmentPreTest = SAPI.Enrolments.GetEnrolment(1);

                var newBoardingflag = !enrolmentPreTest.IsBoarding;

                var newEnrolmentPayload = enrolmentPreTest.ToUpdatable();

                newEnrolmentPayload.IsBoarding = newBoardingflag;

                var enrolmentPostTest = SAPI.Enrolments.UpdateEnrolment(newEnrolmentPayload);

                Assert.IsTrue(enrolmentPreTest.ID == enrolmentPostTest.ID && enrolmentPreTest.IsBoarding != enrolmentPostTest.IsBoarding);
            }
        }

        // No data to test
        //[TestMethod]
        //public void GetOneEnrolmentClassLinkTest()
        //{

        //    var x = sapi.Enrolments.GetEnrolmentClassLink(1);

        //    Assert.IsTrue(x != null && x.ID == 1 && x.Class != null);
        //}



        [TestMethod]
        public void GetOneEnrolmentPriorityTest()
        {

            var x = SAPI.Enrolments.GetEnrolmentPriorty(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }



        [TestMethod]
        public void GetOneFlagTest()
        {

            var x = SAPI.Enrolments.GetFlag(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }



        [TestMethod]
        public void GetOneFlagLinkTest()
        {

            var x = SAPI.Enrolments.GetStudentFlagLink(1);

            Assert.IsTrue(x != null && x.ID == 1 && x.Flag != null);
        }



        [TestMethod]
        public void GetOneHouseTest()
        {

            var x = SAPI.Enrolments.GetHouse(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }



        [TestMethod]
        public void GetOneHouseholdTest()
        {

            var x = SAPI.Enrolments.GetHousehold(1);

            Assert.IsTrue(x != null && x.ID == 1);
        }



        [TestMethod]
        public void GetOneMedicalConditionTest()
        {

            var x = SAPI.Enrolments.GetMedicalConditions(1);

            Assert.IsTrue(x != null && x.ID == 1);
        }



        [TestMethod]
        public void GetOneMedicalConditionAddTest()
        {

            var x = SAPI.Enrolments.GetMedicalConditionAdd(1);

            Assert.IsTrue(x != null && x.ID == 1);
        }



        [TestMethod]
        public void GetOneMedicalConditionAllergyTest()
        {
            int knownMedicalConditionIdWithAllergy = 3791;
            var x = SAPI.Enrolments.GetMedicalConditionAllergy(knownMedicalConditionIdWithAllergy);

            Assert.IsTrue(x != null && x.ID == knownMedicalConditionIdWithAllergy);
        }



        [TestMethod]
        public void GetOneMedicalConditionAsthmaTest()
        {

            int knownMedicalConditionIdWithAsthma = 975;
            var x = SAPI.Enrolments.GetMedicalConditionAsthma(knownMedicalConditionIdWithAsthma);

            Assert.IsTrue(x != null && x.ID == knownMedicalConditionIdWithAsthma);
        }



        [TestMethod]
        public void GetOneMedicalConditionDiabetesTest()
        {

            int knownMedicalConditionIdWithDiabetes = 1284;
            var x = SAPI.Enrolments.GetMedicalConditionDiabetes(knownMedicalConditionIdWithDiabetes);

            Assert.IsTrue(x != null && x.ID == knownMedicalConditionIdWithDiabetes);
        }



        [TestMethod]
        public void GetOneMedicalConditionEpilepsyTest()
        {
            int knownMedicalConditionIdWithEpilepsy = 2087;

            var x = SAPI.Enrolments.GetMedicalConditionEpilepsy(knownMedicalConditionIdWithEpilepsy);

            Assert.IsTrue(x != null && x.ID == knownMedicalConditionIdWithEpilepsy);
        }



        [TestMethod]
        public void GetOneMedicalConditionOtherTest()
        {
            int knownMedicalConditionIdWithOtherType = 3541;
            var x = SAPI.Enrolments.GetMedicalConditionOther(knownMedicalConditionIdWithOtherType);

            Assert.IsTrue(x != null && x.ID == knownMedicalConditionIdWithOtherType);
        }



        [TestMethod]
        public void GetAllMedicalConditions()
        {

            var x = SAPI.Enrolments.GetMedicalConditions();

            Assert.IsTrue(x != null && x.Count > 200);
        }


        [TestMethod]
        public void GetOnePersonTest()
        {

            var incl = new PersonIncludeOptions(emails: true, phoneNumbers: true, primaryHousehold: true, otherHouseholds:true);
            var x = SAPI.Enrolments.GetPerson(2, include: incl);

            Assert.IsTrue(x != null && x.ID == 2 && !string.IsNullOrWhiteSpace(x.LastName));
        }

        [TestMethod]
        public void UpdateOnePersonTest()
        {
            // Only run test on sandbox
            if (IsTestSite)
            {
                var personPreUpdate = SAPI.Enrolments.GetPerson(2);

                string updatePersonName = personPreUpdate.FirstName == "Sharron" ? "Jane" : "Sharron";

                var updatePayload = personPreUpdate.ToUpdatable();
                updatePayload.FirstName = updatePersonName;

                var personPostUpdate = SAPI.Enrolments.UpdatePerson(updatePayload);
                Assert.IsTrue(personPreUpdate.ID == personPostUpdate.ID && personPostUpdate.FirstName == updatePersonName);
            }
        }

        [TestMethod]
        public void GetOneContactDetailTest()
        {

            var x = SAPI.Enrolments.GetContactDetails(1);

            Assert.IsTrue(x != null && x.ID == 1);
        }

        [TestMethod]
        public void GetPersonEmailTest()
        {

            var x = SAPI.Enrolments.GetPersonEmail(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Email));
        }



        [TestMethod]
        public void GetOnePersonFieldTest()
        {

            var x = SAPI.Enrolments.GetPersonField(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }

        [TestMethod]
        public void GetOnePersonFieldValueTest()
        {

            var x = SAPI.Enrolments.GetPersonFieldValue(1);

            Assert.IsTrue(x != null && x.ID == 1 && x.Field != null);
        }

        [TestMethod]
        public void GetOneMedicalMiscTest()
        {

            var x = SAPI.Enrolments.GetPersonMedicalMisc(1);

            Assert.IsTrue(x != null && x.ID == 1 );
        }

        [TestMethod]
        public void GetPersonPhoneTest()
        {

            var x = SAPI.Enrolments.GetPersonPhone(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Number));
        }


        [TestMethod]
        public void GetOnePrescribedMedicationTest()
        {

            var x = SAPI.Enrolments.GetPrescribedMedication(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }



        [TestMethod]
        public void GetOneRollclassTest()
        {

            var x = SAPI.Enrolments.GetRollclass(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }

        [TestMethod]
        public void GetOneSchoolTest()
        {

            var x = SAPI.Enrolments.GetSchool(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.SchoolCode));
        }

        // No Data to test
        //[TestMethod]
        //public void GetOneSpecialNeedsTest()
        //{

        //    var x = sapi.Enrolments.GetSpecialNeedsProgram(1);

        //    Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        //}

        [TestMethod]
        public void GetOneStaffTest()
        {

            var x = SAPI.Enrolments.GetStaff(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.EmploymentStatus));
        }


        // Better test needed
        //[TestMethod]
        //public void GetOneStaffAbsenceTest()
        //{

        //    var x = sapi.Enrolments.GetStaffAbsences(1);

        //    Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.EmploymentStatus));
        //}


        [TestMethod]
        public void GetOneStaffEmploymentTest()
        {

            var x = SAPI.Enrolments.GetStaffEmployment(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.EmploymentStatus));
        }


        [TestMethod]
        public void GetOneStaffQualificationTest()
        {

            var x = SAPI.Enrolments.GetQualification(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.QualificationType));
        }



        [TestMethod]
        public void GetOneStudentTest()
        {

            var x = SAPI.Enrolments.GetStudent(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.StudentCode));
        }



        [TestMethod]
        public void GetOneStudentsAbsencesTest()
        {
            var knownStudentIdWithAbsence = 9613;
            var x = SAPI.Enrolments.GetStudentAbsences(knownStudentIdWithAbsence);

            Assert.IsTrue(x != null && x.Count >= 1);
        }


        [TestMethod]
        public void GetOneStudentsRelatedAcademicReportWithSideloadTest()
        {
           var knownStudentIdWithReport = 10061;



            var incl = new StudentAcademicReportIncludeOptions(period: true);

            AbstractIncludeOptions<EnumReportsIncludeOptions> incl2 = incl;

            var x = SAPI.Enrolments.GetStudentRelatedAcademicReports(knownStudentIdWithReport, incl);

            Assert.IsTrue(x != null && x.Count >= 1 && !string.IsNullOrWhiteSpace(x[0].Period.Data.Name));
        }

        [TestMethod]
        public void GetOneStudentDocumentFileTest()
        {

            var x = SAPI.Enrolments.GetStudentDocumentFile(1);

            Assert.IsTrue(x != null && x.ID == 1 && x.FileData.Length>0);
        }

        [TestMethod]
        public void WriteOneStudentDocumentFileTest()
        {

            var x = SAPI.Enrolments.GetStudentDocumentFile(1);

            x.SaveDocument("C:\\Temp");
        }

        [TestMethod]
        public void GetOneStudentFlagTest()
        {

            var x = SAPI.Enrolments.GetStudentFlagLink(1);

            Assert.IsTrue(x != null && x.ID == 1 && x.Flag != null);
        }


        [TestMethod]
        public void GetOneStudentHistoryTest()
        {

            var x = SAPI.Enrolments.GetStudentSchoolHistory(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.PreviousSchool));
        }

        [TestMethod]
        public void GetOneStudentRelationshipTest()
        {

            var x = SAPI.Enrolments.GetStudentContact(1);

            Assert.IsTrue(x != null && !string.IsNullOrWhiteSpace(x.ID) && x.Student!=null);
        }

        [TestMethod]
        public void GetOneStudentHouseholdRelationshipTest()
        {

            var x = SAPI.Enrolments.GetStudentHouseholdRelationship(1);

            Assert.IsTrue(x != null && !string.IsNullOrWhiteSpace(x.ID) && x.Student != null);
        }


        [TestMethod]
        public void GetOneTenantTest()
        {

            var x = SAPI.Enrolments.GetSchoolTenant(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }

        [TestMethod]
        public void GetOneVaccinationTest()
        {

            var x = SAPI.Enrolments.GetVaccination(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }


        [TestMethod]
        public void GetOneYearLevelTest()
        {

            var x = SAPI.Enrolments.GetYearLevel(1);

            Assert.IsTrue(x != null && x.ID == 1 && !string.IsNullOrWhiteSpace(x.Name));
        }


        [TestMethod]
        public void GetAllPersonsTest()
        {

            var x = SAPI.Enrolments.GetPerson();

            
            Assert.IsTrue(x != null && x.Count >= 200);
        }

        [TestMethod]
        public void GetAllHouseholdsTest()
        {
            var x = SAPI.Enrolments.GetHousehold();

            Assert.IsTrue(x != null && x.Count > 200);
        }

        [TestMethod]
        public void GetOneStaffByCodeTest()
        {
            var x = SAPI.Enrolments.GetStaff(staffCodes:new string[] { "A450" });

            Assert.IsTrue(x != null);
        }

        [TestMethod]
        public void GetOneStudentWithContactTest()
        {
            int studentId = 11434;
            var x = SAPI.Enrolments.GetStudent(studentId, new StudentIncludeOptions(contacts:true));


            Assert.IsTrue(x != null && x.ID == studentId && x.Contacts.Data.Count >=1);
        }



    }
}
