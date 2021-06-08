using System;
using System.Collections.Generic;
using System.Text;
using Sentral.API.DataAccess;
using Newtonsoft.Json;
using JsonApiSerializer;
using Sentral.API.Model.Enrolments;
using Sentral.API.Model;
using Sentral.API.Model.Enrolments.Include;
using Sentral.API.Model.StaffAbsences;
using Sentral.API.Model.Enrolments.Update;
using Sentral.API.DataAccess.Exceptions;
using Sentral.API.Common;

namespace Sentral.API.Client.ActionNamespace
{
    public class EnrolmentApi : AbstractApi
    {

        internal EnrolmentApi(string baseUrl, string apiKey, string tenantCode) :
                base(baseUrl, apiKey, tenantCode)
        { }



        public List<Ability> GetAbility()
        {
            return GetAllData<Ability>("/v1/enrolments/ability");
        }

        public Ability GetAbility(int id)
        {
            return GetData<Ability>(string.Format("/v1/enrolments/ability/{0}", id));
        }

        public List<AcademicPeriod> GetAcademicPeriod(DateTime? date = null)
        {
            var p = new Dictionary<string, object>
            {
                ["date"] = date
            };

            var uri = GetEndpointParameters("/v1/enrolments/academic-period", p);

            return GetAllData<AcademicPeriod>(uri);
        }

        public AcademicPeriod GetAcademicPeriod(int id)
        {
            return GetData<AcademicPeriod>(string.Format("/v1/enrolments/academic-period/{0}", id));
        }

        public List<Campus> GetCampus(int[] ids = null, int[] schoolIds = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["schoolIds"] = schoolIds,
                ["includeInactive"] = includeInactive
            };

            var uri = GetEndpointParameters("/v1/enrolments/campus", p);

            return GetAllData<Campus>(uri);
        }

        public Campus GetCampus(int id)
        {
            return GetData<Campus>(string.Format("/v1/enrolments/campus/{0}", id));
        }


        public List<Class> GetClass(int[] ids = null, int[] subjectIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["subjectIds"] = subjectIds,
            };

            var uri = GetEndpointParameters("/v1/enrolments/class", p);

            return GetAllData<Class>(uri);
        }

        public Class GetClass(int id)
        {
            return GetData<Class>(string.Format("/v1/enrolments/class/{0}", id));
        }



        public List<ClassSubject> GetClassSubject(int[] ids = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
            };

            var uri = GetEndpointParameters("/v1/enrolments/class-subject", p);

            return GetAllData<ClassSubject>(uri);
        }

        public ClassSubject GetClassSubject(int id)
        {
            return GetData<ClassSubject>(string.Format("/v1/enrolments/class-subject/{0}", id));
        }

        public List<Student> GetClassStudents(int classId)
        {
            return GetAllData<Student>(string.Format("/v1/enrolments/class/{0}/students", classId));
        }

        public List<Consent> GetConsent()
        {
            return GetAllData<Consent>("/v1/enrolments/consent");
        }

        public Consent GetConsent(int id)
        {
            return GetData<Consent>(string.Format("/v1/enrolments/consent/{0}", id));
        }

        public Consent UpdateConsent(UpdateConsent updateData)
        {
            return UpdateData<Consent>("/v1/enrolments/consent", updateData);
        }


        public Consent CreateConsent(UpdateConsent updateData)
        {
            return CreateData<Consent>("/v1/enrolments/consent", updateData);
        }

        public void DeleteConsent(int id)
        {
            DeleteData("/v1/enrolments/consent", id);
        }

        public List<ConsentLink> GetPersonConsentLink(ICollection<PersonConsentIncludeOptions> include = null,
            int[] ids = null, int[] personIds = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["personIds"] = personIds,
                ["includeInactive"] = includeInactive
            };

            var uri = GetEndpointParameters<PersonConsentIncludeOptions>("/v1/enrolments/person-consent-link", p);

            return GetAllData<ConsentLink>(uri);
        }
        public ConsentLink GetPersonConsentLink(int id, ICollection<PersonConsentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var endpoint = string.Format("/v1/enrolments/person-consent-link/{0}", id);
            var uri = GetEndpointParameters<PersonConsentIncludeOptions>(endpoint, p);
            return GetData<ConsentLink>(uri);
        }


        public ConsentLink UpdatePersonConsentLink(UpdatePersonConsentLink updateData)
        {
            return UpdateData<ConsentLink>("/v1/enrolments/person-consent-link", updateData);
        }


        public ConsentLink CreatePersonConsentLink(UpdatePersonConsentLink updateData)
        {
            return CreateData<ConsentLink>("/v1/enrolments/person-consent-link", updateData);
        }

        public void DeletePersonConsentLink(int id)
        {
            DeleteData("/v1/enrolments/person-consent-link", id);
        }

        public List<Disability> GetDisabilityOthers(int[] ids = null, int[] personIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["personIds"] = personIds,
            };

            var uri = GetEndpointParameters("/v1/enrolments/disability-other", p);

            return GetAllData<Disability>(uri);
        }

        public Disability GetDisabilityOthers(int id)
        {
            return GetData<Disability>(string.Format("/v1/enrolments/disability-other/{0}", id));
        }


        // TODO: Implement /v1/enrolments/disability-other/:id/care-plan-file




        public List<Doctor> GetDoctor()
        {

            return GetAllData<Doctor>("/v1/enrolments/doctor");
        }

        public Doctor GetDoctor(int id)
        {
            return GetData<Doctor>(string.Format("/v1/enrolments/doctor/{0}", id));
        }

        public Person GetDoctorPerson(int doctorId)
        {
            return GetData<Person>(string.Format("/v1/enrolments/doctor/{0}/person", doctorId));
        }

        public List<EmergencyContactLink> GetEmergencyContactLink()
        {

            return GetAllData<EmergencyContactLink>("/v1/enrolments/emergency-contact-link");
        }

        public EmergencyContactLink GetEmergencyContactLink(int id)
        {
            return GetData<EmergencyContactLink>(string.Format("/v1/enrolments/emergency-contact-link/{0}", id));
        }


        public List<Enrolment> GetEnrolment(ICollection<EnrolmentIncludeOptions> include = null, int[] ids = null,
            int[] studentIds = null, int[] rollclassIds = null, int[] yearLevelIds = null,
            int[] houseIds = null, string[] statuses = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["studentIds"] = studentIds,
                ["rollclassIds"] = rollclassIds,
                ["yearLevelIds"] = yearLevelIds,
                ["houseIds"] = houseIds,
                ["statuses"] = statuses
            };

            var uri = GetEndpointParameters<EnrolmentIncludeOptions>("/v1/enrolments/enrolment", p);
            return GetAllData<Enrolment>(uri);
        }

        public Enrolment GetEnrolment(int id, ICollection<EnrolmentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters(string.Format("/v1/enrolments/enrolment/{0}", id), p);
            return GetData<Enrolment>(uri);
        }

        
        public Enrolment UpdateEnrolment(UpdateEnrolment updateData)
        {
            return UpdateData<Enrolment>("/v1/enrolments/enrolment", updateData);
        }

        public List<Class> GetEnrolmentClasses(int enrolmentId)
        {

            return GetAllData<Class>(string.Format("/v1/enrolments/enrolment/{0}/class", enrolmentId));
        }
        public House GetEnrolmentHouse(int enrolmentId)
        {

            return GetData<House>(string.Format("/v1/enrolments/enrolment/{0}/house", enrolmentId));
        }

        public Rollclass GetEnrolmentRollclass(int enrolmentId)
        {

            return GetData<Rollclass>(string.Format("/v1/enrolments/enrolment/{0}/rollclass", enrolmentId));
        }

        public List<EnrolmentClassLink> GetEnrolmentClassLink(int[] ids = null, int[] enrolmentIds = null,
            int[] classIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["enrolmentIds"] = enrolmentIds,
                ["classIds"] = classIds
            };

            var uri = GetEndpointParameters("/v1/enrolments/enrolment-class-link", p);
            return GetAllData<EnrolmentClassLink>(uri);
        }

        public EnrolmentClassLink GetEnrolmentClassLink(int id)
        {
            return GetData<EnrolmentClassLink>(string.Format("/v1/enrolments/enrolment-class-link/{0}", id));
        }

        public List<EnrolmentPriority> GetEnrolmentPriorty(int[] ids = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids
            };

            var uri = GetEndpointParameters("/v1/enrolments/enrolment-priority", p);
            return GetAllData<EnrolmentPriority>(uri);
        }

        public EnrolmentPriority GetEnrolmentPriorty(int id)
        {
            return GetData<EnrolmentPriority>(string.Format("/v1/enrolments/enrolment-priority/{0}", id));
        }

        public List<Flag> GetFlag()
        {
            return GetAllData<Flag>("/v1/enrolments/flag");
        }

        public Flag GetFlag(int id)
        {
            return GetData<Flag>(string.Format("/v1/enrolments/flag/{0}", id));
        }

        public School GetFlagSchool(int flagId)
        {
            return GetData<School>(string.Format("/v1/enrolments/flag/{0}/school", flagId));
        }

        public List<House> GetHouse(int[] ids = null, int[] schoolIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["schoolIds"] = schoolIds
            };
            var uri = GetEndpointParameters("/v1/enrolments/house", p);
            return GetAllData<House>(uri);
        }

        public House GetHouse(int id)
        {
            return GetData<House>(string.Format("/v1/enrolments/house/{0}", id));

        }
        public List<Student> GetHouseStudents(int houseId)
        {
            return GetAllData<Student>(string.Format("/v1/enrolments/house/{0}/students", houseId));

        }

        public List<Household> GetHousehold()
        {
            return GetAllData<Household>("/v1/enrolments/household?include=addresses");
        }

        public Household GetHousehold(int id)
        {
            return GetData<Household>(string.Format("/v1/enrolments/household/{0}?include=addresses", id));
        }

        public List<Address> GetHouseholdRelatedAddresses(int id)
        {
            return GetAllData<Address>(string.Format("/v1/enrolments/household/{0}/addresses", id));
        }

        public List<Address> GetHouseholdAddress()
        {
            return GetAllData<Address>("/v1/enrolments/household-address");
        }

        public Address GetHouseholdAddress(int id)
        {
            return GetData<Address>(string.Format("/v1/enrolments/household-address/{0}", id));
        }

        public AbstractMedicalCondition GetMedicalConditions(int id)
        {
            return GetData<AbstractMedicalCondition>(string.Format("/v1/enrolments/medical-condition/{0}", id));
        }

        public List<AbstractMedicalCondition> GetMedicalConditions(int[] ids=null, string[] name = null, int[] personIds=null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["name"] = name,
                ["personIds"] = personIds,
            };
            var uri = GetEndpointParameters("/v1/enrolments/medical-condition", p);

            return GetAllData<AbstractMedicalCondition>(uri);
        }

        // TODO: Add Careplan File endpoint for Medical Conditions


        public MedicalConditionAdd GetMedicalConditionAdd(int id, ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>(string.Format("/v1/enrolments/medical-condition-add/{0}",id), p);
            return GetData<MedicalConditionAdd>(uri);
        }

        public List<MedicalConditionAdd> GetMedicalConditionAdd(ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>("/v1/enrolments/medical-condition-add", p);

            return GetAllData<MedicalConditionAdd>(uri);
        }

        // TODO: Add Careplan File endpoint for Medical Condition ADD


        public MedicalConditionAllergy GetMedicalConditionAllergy(int id, ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>(string.Format("/v1/enrolments/medical-condition-allergy/{0}", id), p);
            return GetData<MedicalConditionAllergy>(uri);
        }

        public List<MedicalConditionAllergy> GetMedicalConditionAllergy(ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>("/v1/enrolments/medical-condition-allergy", p);

            return GetAllData<MedicalConditionAllergy>(uri);
        }

        // TODO: Add Careplan File endpoint for Medical Condition Allergy


        public MedicalConditionAsthma GetMedicalConditionAsthma(int id, ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>(string.Format("/v1/enrolments/medical-condition-asthma/{0}", id), p);
            return GetData<MedicalConditionAsthma>(uri);
        }

        public List<MedicalConditionAsthma> GetMedicalConditionAsthma(ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>("/v1/enrolments/medical-condition-asthma", p);

            return GetAllData<MedicalConditionAsthma>(uri);
        }

        // TODO: Add Careplan File endpoint for Medical Condition Asthma


        public MedicalConditionDiabetes GetMedicalConditionDiabetes(int id, ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>(string.Format("/v1/enrolments/medical-condition-diabetes/{0}", id), p);
            return GetData<MedicalConditionDiabetes>(uri);
        }

        public List<MedicalConditionDiabetes> GetMedicalConditionDiabetes(ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>("/v1/enrolments/medical-condition-diabetes", p);

            return GetAllData<MedicalConditionDiabetes>(uri);
        }

        // TODO: Add Careplan File endpoint for Medical Condition Diabetes


        public MedicalConditionEpilepsy GetMedicalConditionEpilepsy(int id, ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>(string.Format("/v1/enrolments/medical-condition-epilepsy/{0}", id), p);
            return GetData<MedicalConditionEpilepsy>(uri);
        }

        public List<MedicalConditionEpilepsy> GetMedicalConditionEpilepsy(ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>("/v1/enrolments/medical-condition-epilepsy", p);

            return GetAllData<MedicalConditionEpilepsy>(uri);
        }

        // TODO: Add Careplan File endpoint for Medical Condition Epilepsy


        public MedicalConditionOther GetMedicalConditionOther(int id, ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>(string.Format("/v1/enrolments/medical-condition-other/{0}", id), p);
            return GetData<MedicalConditionOther>(uri);
        }

        public List<MedicalConditionOther> GetMedicalConditionOther(ICollection<MedicalConditionsIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<MedicalConditionsIncludeOptions>("/v1/enrolments/medical-condition-other", p);

            return GetAllData<MedicalConditionOther>(uri);
        }

        // TODO: Add Careplan File endpoint for Medical Condition Epilepsy





        // TODO Medical Conditions ... Work out how to deal with varying types in data array
        // TODO Bitstteam for care plans


        public List<Person> GetPerson(
                ICollection<PersonIncludeOptions> include = null, int[] ids = null, string[] refIds = null,
                string[] contactCodes = null, string[] externalIds = null, string firstName = null,
                string lastName = null, bool? inactive = null
            )
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["refIds"] = refIds,
                ["contactCodes"] = contactCodes,
                ["externalIds"] = externalIds,
                ["firstName"] = firstName,
                ["lastName"] = lastName,
                ["inactive"] = inactive
            };

            var uri = GetEndpointParameters<PersonIncludeOptions>("/v1/enrolments/person", p);

            return GetAllData<Person>(uri);
        }


        public Person GetPerson(int id, ICollection<PersonIncludeOptions> include = null)
        {
            string endpoint = string.Format("/v1/enrolments/person/{0}", id);

            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<PersonIncludeOptions>(endpoint, p);

            return GetData<Person>(uri);
        }


        public Person GetPersonByCode(string contactCode, ICollection<PersonIncludeOptions> include = null)
        {
            string endpoint = string.Format("/v1/enrolments/person/{0}", contactCode);

            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };
            var uri = GetEndpointParameters<PersonIncludeOptions>(endpoint, p);

            return GetData<Person>(uri);
        }


        public Person UpdatePerson (UpdatePerson updateData)
        {
            return UpdateData<Person>("/v1/enrolments/person", updateData);
        }



        public List<Student> GetPersonAssociatedStudentsByPersonId(int personId, bool? hasPortalAccess = null,
                bool? withPastEnroloment = null, bool? withCurrentEnrolment = null,
                bool? withFutureEnrolment = null, bool? withOtherEnrolment = null)
        {
            string endpoint = string.Format("/v1/enrolments/person/{0}/associated-students", personId);

            var p = new Dictionary<string, object>
            {
                ["hasPortalAccess"] = hasPortalAccess,
                ["withPastEnroloment"] = withPastEnroloment,
                ["withCurrentEnrolment"] = withCurrentEnrolment,
                ["withFutureEnrolment"] = withFutureEnrolment,
                ["withOtherEnrolment"] = withOtherEnrolment
            };
            var uri = GetEndpointParameters(endpoint, p);

            return GetAllData<Student>(uri);
        }

        public List<Disability> GetPersonDisabilities(int personId)
        {
            return GetAllData<Disability>(string.Format("/v1/enrolments/person/{0}/disabilities", personId));
        }

        public List<Doctor> GetPersonDoctors(int personId)
        {
            return GetAllData<Doctor>(string.Format("/v1/enrolments/person/{0}/doctors", personId));
        }

        public List<ConsentLink> GetPersonGivenConsentLinks(int personId, ICollection<PersonConsentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/person/{0}/given-consent-links", personId);
            var uri = GetEndpointParameters<PersonConsentIncludeOptions>(endpoint, p);

            return GetAllData<ConsentLink>(uri);

        }

        public Household GetPersonHouseholdPrimary(int personId)
        {
            return GetData<Household>(string.Format("/v1/enrolments/person/{0}/primary-households?include=addresses", personId));
        }

        // TODO Workout how to generically handle medical conditions
        public List<Household> GetPersonHouseholdOthers(int personId)
        {
            return GetAllData<Household>(string.Format("/v1/enrolments/person/{0}/other-households?include=addresses", personId));
        }

        public List<PersonContactDetail> GetPersonContactDetails(int personId)
        {
            return GetAllData<PersonContactDetail>(string.Format("/v1/enrolments/person/{0}/person-contact-details", personId));
        }

        public List<PrescribedMedication> GetPersonPrescribedMedication(int personId)
        {
            return GetAllData<PrescribedMedication>(string.Format("/v1/enrolments/person/{0}/prescribed-medication", personId));
        }

        public Staff GetPersonStaff(int personId, ICollection<StaffIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/person/{0}/staff", personId);
            var uri = GetEndpointParameters<StaffIncludeOptions>(endpoint, p);

            return GetData<Staff>(uri);
        }

        public Student GetPersonStudent(int personId, ICollection<StudentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/person/{0}/student", personId);
            var uri = GetEndpointParameters<StaffIncludeOptions>(endpoint, p);

            return GetData<Student>(uri);
        }

        public List<StudentPersonRelationship> GetPersonStudentContacts(int personId, ICollection<StudentContactIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/person/{0}/student-contacts", personId);
            var uri = GetEndpointParameters<StudentContactIncludeOptions>(endpoint, p);

            return GetAllData<StudentPersonRelationship>(uri);
        }

        public List<Vaccination> GetPersonVaccination(int personId, ICollection<VaccinationIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/person/{0}/vaccination", personId);
            var uri = GetEndpointParameters<VaccinationIncludeOptions>(endpoint, p);

            return GetAllData<Vaccination>(uri);
        }

        public List<PersonContactDetail> GetContactDetails(int[] ids = null,
                int[] personIds = null, bool? includeInactive = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["personIds"] = personIds,
                ["includeInactive"] = includeInactive,
            };

            var uri = GetEndpointParameters("/v1/enrolments/person-contact-details", p);

            return GetAllData<PersonContactDetail>(uri);
        }

        public PersonContactDetail GetContactDetails(int id)
        {

            var uri = string.Format("/v1/enrolments/person-contact-details/{0}", id);

            return GetData<PersonContactDetail>(uri);
        }

        public PersonEmail GetPersonEmail(int id)
        {
            return GetData<PersonEmail>(string.Format("/v1/enrolments/person-email/{0}", id));
        }

        public List<PersonEmail> GetPersonEmail()
        {
            return GetAllData<PersonEmail>("/v1/enrolments/person-email");
        }



        public PersonEmail UpdatePersonEmail(UpdatePersonEmail updateData)
        {
            return UpdateData<PersonEmail>("/v1/enrolments/person-email", updateData);
        }


        public PersonEmail CreatePersonEmail(UpdatePersonEmail updateData)
        {
            return CreateData<PersonEmail>("/v1/enrolments/person-email", updateData);
        }

        public void DeletePersonEmail(int id)
        {
            DeleteData("/v1/enrolments/person-email", id);
        }


        public List<PersonField> GetPersonField(int[] ids = null, int[] schoolIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["schoolIds"] = schoolIds
            };

            var uri = GetEndpointParameters("/v1/enrolments/person-field", p);

            return GetAllData<PersonField>(uri);
        }
        public PersonField GetPersonField(int id)
        {
            return GetData<PersonField>(string.Format("/v1/enrolments/person-field/{0}", id));
        }

        public List<PersonFieldValue> GetPersonFieldValue(int[] ids = null, int[] personIds = null, int[] fieldIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["personIds"] = personIds,
                ["fieldIds"] = fieldIds
            };

            var uri = GetEndpointParameters("/v1/enrolments/person-field-value", p);

            return GetAllData<PersonFieldValue>(uri);
        }
        public PersonFieldValue GetPersonFieldValue(int id)
        {
            return GetData<PersonFieldValue>(string.Format("/v1/enrolments/person-field-value/{0}", id));
        }


        public List<PersonMedicalMisc> GetPersonMedicalMisc(ICollection<MedicalMiscIncludeOptions> include = null, int[] personIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["personIds"] = personIds
            };

            var uri = GetEndpointParameters<MedicalMiscIncludeOptions>("/v1/enrolments/person-medical-misc", p);

            return GetAllData<PersonMedicalMisc>(uri);
        }
        public PersonMedicalMisc GetPersonMedicalMisc(int id, ICollection<MedicalMiscIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters<MedicalMiscIncludeOptions>(string.Format("/v1/enrolments/person-medical-misc/{0}", id), p);

            return GetData<PersonMedicalMisc>(uri);
        }

        public PersonPhone GetPersonPhone(int id)
        {
            return GetData<PersonPhone>(string.Format("/v1/enrolments/person-phone/{0}", id));
        }

        public List<PersonPhone> GetPersonPhone()
        {
            return GetAllData<PersonPhone>("/v1/enrolments/person-phone");
        }


        public PersonPhone UpdatePersonPhone(UpdatePersonPhone updateData)
        {
            return UpdateData<PersonPhone>("/v1/enrolments/person-phone", updateData);
        }

        public PersonPhone CreatePersonPhone(UpdatePersonPhone updateData)
        {
            return CreateData<PersonPhone>("/v1/enrolments/person-phone", updateData);
        }

        public void DeletePersonPhone(int id)
        {
            DeleteData("/v1/enrolments/person-phones", id);
        }


        public List<PrescribedMedication> GetPrescribedMedication()
        {
            return GetAllData<PrescribedMedication>("/v1/enrolments/prescribed-medication");
        }

        public PrescribedMedication GetPrescribedMedication(int id)
        {
            return GetData<PrescribedMedication>(string.Format("/v1/enrolments/prescribed-medication/{0}", id));
        }


        public List<Rollclass> GetRollclass()
        {
            return GetAllData<Rollclass>("/v1/enrolments/rollclass");
        }

        public Rollclass GetRollclass(int id)
        {
            return GetData<Rollclass>(string.Format("/v1/enrolments/rollclass/{0}", id));
        }

        public List<Student> GetRollclassStudents(int rollclassId)
        {
            return GetAllData<Student>(string.Format("/v1/enrolments/rollclass/{0}/students", rollclassId));
        }


        public List<School> GetSchool(ICollection<SchoolIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters<SchoolIncludeOptions>("/v1/enrolments/school", p);

            return GetAllData<School>(uri);
        }

        public School GetSchool(int id, ICollection<SchoolIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters<SchoolIncludeOptions>(string.Format("/v1/enrolments/school/{0}", id), p);

            return GetData<School>(uri);
        }

        public School GetSchoolTenant(int schoolId)
        {
            return GetData<School>(string.Format("/v1/enrolments/school/{0}/tenant", schoolId));
        }

        public List<SpecialNeedsProgram> GetSpecialNeedsProgram(ICollection<SpecialNeedsProgramIncludeOptions> include = null,
                int[] ids = null, int[] studentIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["studentIds"] = studentIds
            };

            var uri = GetEndpointParameters<SpecialNeedsProgramIncludeOptions>("/v1/enrolments/special-needs-program", p);

            return GetAllData<SpecialNeedsProgram>(uri);
        }

        public SpecialNeedsProgram GetSpecialNeedsProgram(int id, ICollection<SpecialNeedsProgramIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters<SpecialNeedsProgramIncludeOptions>(string.Format("/v1/enrolments/special-needs-program/{0}", id), p);

            return GetData<SpecialNeedsProgram>(uri);
        }


        public List<Staff> GetStaff(ICollection<StaffIncludeOptions> include = null, int[] ids = null, string[] barcodes = null,
            string[] staffCodes = null, Guid[] refIds = null, string[] contactCodes = null, string[] externalIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["barcodes"] = barcodes,
                ["staffCodes"] = staffCodes,
                ["refIds"] = refIds,
                ["contactCodes"] = contactCodes,
                ["externalIds"] = externalIds
            };

            var uri = GetEndpointParameters<StaffIncludeOptions>("/v1/enrolments/staff", p);

            return GetAllData<Staff>(uri);
        }

        public Staff GetStaff(int id, ICollection<StaffIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/staff/{0}", id);
            var uri = GetEndpointParameters<StaffIncludeOptions>(endpoint, p);

            return GetData<Staff>(uri);
        }

        public Staff UpdateStaff(UpdateStaff updateData)
        {
            return UpdateData<Staff>("/v1/enrolments/staff", updateData);
        }


        public List<StaffAbsence> GetStaffAbsences(int id)
        {
            return GetAllData<StaffAbsence>(string.Format("/v1/enrolments/staff/{0}/absences", id));
        }

        public Person GetStaffPerson(int staffId)
        {
            return GetData<Person>(string.Format("/v1/enrolments/staff/{0}/person", staffId));
        }

        public List<StaffQualification> GetStaffQualifications(int staffId)
        {
            return GetAllData<StaffQualification>(string.Format("/v1/enrolments/staff/{0}/qualification", staffId));
        }

        public List<StaffEmployment> GetStaffEmployment(int[] ids = null, int[] staffIds = null,
            int[] schoolIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["staffIds"] = staffIds,
                ["schoolIds"] = schoolIds
            };

            var uri = GetEndpointParameters("/v1/enrolments/staff-employment", p);
            return GetAllData<StaffEmployment>(uri);
        }

        public StaffEmployment GetStaffEmployment(int id)
        {

            return GetData<StaffEmployment>(string.Format("/v1/enrolments/staff-employment/{0}", id));
        }


        public List<StaffQualification> GetQualification()
        {
            return GetAllData<StaffQualification>("/v1/enrolments/staff-qualification");
        }

        public StaffQualification GetQualification(int id)
        {
            return GetData<StaffQualification>(string.Format("/v1/enrolments/staff-qualification/{0}", id));
        }


        public StaffQualification UpdateQualification(UpdateStaffQualification updateData)
        {
            return UpdateData<StaffQualification>("/v1/enrolments/staff-qualification", updateData);
        }

        public StaffQualification CreateQualification(UpdateStaffQualification updateData)
        {
            return CreateData<StaffQualification>("/v1/enrolments/staff-qualification", updateData);
        }

        public void DeleteQualification(int id)
        {
            DeleteData("/v1/enrolments/staff-qualification", id);
        }


        public List<Student> GetStudent(ICollection<StudentIncludeOptions> include = null, int[] ids = null,
                string[] studentCodes = null, string[] examCodes = null, string[] refIds = null,
                string[] contactCodes = null, int[] externalIds = null, int[] academicPeriodIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["ids"] = ids,
                ["studentCodes"] = studentCodes,
                ["examCodes"] = examCodes,
                ["refIds"] = refIds,
                ["contactCodes"] = contactCodes,
                ["externalIds"] = externalIds,
                ["academicPeriodIds"] = academicPeriodIds
            };

            var uri = GetEndpointParameters<StudentIncludeOptions>("/v1/enrolments/student", p);

            return GetAllData<Student>(uri);

        }
        public Student GetStudent(int id, ICollection<StudentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}", id);
            var uri = GetEndpointParameters<StudentIncludeOptions>(endpoint, p);

            return GetData<Student>(uri);
        }


        public Student UpdateStudent(UpdateStudent updateData)
        {
            return UpdateData<Student>("/v1/enrolments/student", updateData);
        }

        // TODO Finish /student/:id/xxx endpoints

        public List<Model.Attendance.Absence> GetStudentAbsences(int id)
        {


            return GetAllData <Model.Attendance.Absence>(string.Format("/v1/enrolments/student/{0}/absences", id));

        }

        public List<Model.Activities.Activity> GetStudentActivities(int studentId,
            Model.Activities.Include.ActivityIncludeOptions include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            // Use Activites API query string helper
            var apiQueryStringHelper = new ApiQueryStringHelper();

            var endpoint = string.Format("/v1/enrolments/student/{0}/activities", studentId);
            var uri = GetEndpointParameters<StudentIncludeOptions>(endpoint, p, apiQueryStringHelper);

            return GetAllData<Model.Activities.Activity>(uri);
        }

        public List<Model.Activities.AttendeeLink> GetStudentActivityAttendeeLinks(int studentId)
        {

            var uri = string.Format("/v1/enrolments/student/{0}/activity-links", studentId);

            return GetAllData<Model.Activities.AttendeeLink>(uri);
        }

        public List<Enrolment> GetStudentEnrolment(int studentId, ICollection<EnrolmentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}/enrolment", studentId);
            var uri = GetEndpointParameters<EnrolmentIncludeOptions>(endpoint, p);

            return GetAllData<Enrolment>(uri);

        }

        public List<StudentFlagLink> GetStudentFlagLinkByStudentId(int studentId, ICollection<StudentFlagLinkIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}/student-flag-links", studentId);
            var uri = GetEndpointParameters<StudentFlagLinkIncludeOptions>(endpoint, p);

            return GetAllData<StudentFlagLink>(uri);
        }

        public List<Flag> GetStudentFlag(int studentId)
        {
            return GetAllData<Flag>(string.Format("/v1/enrolments/student/{0}/flags", studentId));
        }

        // TODO household relationhips

        public List<StudentHouseholdRelationship> GetStudentHouseholdRelationshisByStudentId(int studentId,
            ICollection<StudentHouseholdRelationIncludeOptions> include = null, string[] residentialHouseholdTypes = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["residentiualHouseholdTypes"] = residentialHouseholdTypes
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}/households", studentId);
            var uri = GetEndpointParameters<StudentHouseholdRelationIncludeOptions>(endpoint, p);
            return GetAllData<StudentHouseholdRelationship>(uri);
        }

        public Person GetStudentPerson(int studentId, ICollection<PersonIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}/person", studentId);
            var uri = GetEndpointParameters<PersonIncludeOptions>(endpoint, p);

            return GetData<Person>(uri);
        }

        public BinaryFile GetStudentPhoto(int studentId, int? width = null, int? height = null)
        {
            var p = new Dictionary<string, object>
            {
                ["width"] = width,
                ["height"] = height,
            };

            var uri = GetEndpointParameters(string.Format("/v1/enrolments/student/{0}/photo", studentId),p);

            return GetBinaryFile(uri);
        }

        public Enrolment GetStudentPrimaryEnrolment(int studentId, ICollection<EnrolmentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}/primary-enrolment", studentId);
            var uri = GetEndpointParameters<EnrolmentIncludeOptions>(endpoint, p);

            return GetData<Enrolment>(uri);
        }


        public List<Model.Reports.StudentAcademicReport> GetStudentRelatedAcademicReports(int studentId,
                Model.Reports.Include.StudentAcademicReportIncludeOptions[] include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}/academic-reports", studentId);

            // Use reports include helper 
            var queryStringHelper = new ApiQueryStringHelper();

            var uri = GetEndpointParameters<Model.Reports.Include.StudentAcademicReportIncludeOptions>(endpoint, p, queryStringHelper);

            return GetAllData<Model.Reports.StudentAcademicReport>(uri);

        }

        public List<SpecialNeedsProgram> GetStudentSpecialNeedsProgram(int studentId, ICollection<SpecialNeedsProgramIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student/{0}/special-needs-programs", studentId);
            var uri = GetEndpointParameters<SpecialNeedsProgramIncludeOptions>(endpoint, p);

            return GetAllData<SpecialNeedsProgram>(uri);
        }


        public List<Tenant> GetStudentTenant(int studentId)
        {
            return GetAllData<Tenant>(string.Format("/v1/enrolments/student/{0}/tenants", studentId));
        }


        public List<StudentPersonRelationship> GetStudentContact(ICollection<StudentContactIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters<StudentContactIncludeOptions>("/v1/enrolments/student-contact", p);

            return GetAllData<StudentPersonRelationship>(uri);
        }

        public StudentPersonRelationship GetStudentContact(int id, ICollection<StudentContactIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student-contact/{0}", id);
            var uri = GetEndpointParameters<StudentContactIncludeOptions>(endpoint, p);

            return GetData<StudentPersonRelationship>(uri);
        }

        public Student GetStudentContactStudent(int id, ICollection<StudentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student-contact/{0}/student", id);
            var uri = GetEndpointParameters<StudentIncludeOptions>(endpoint, p);

            return GetData<Student>(uri);
        }


        public List<StudentDocument> GetStudentDocument()
        {
            return GetAllData<StudentDocument>("/v1/enrolments/student-document");
        }

        public StudentDocument GetStudentDocument(int id)
        {
            var uri = string.Format("/v1/enrolments/student-document/{0}", id);

            return GetData<StudentDocument>(uri);
        }

        public StudentDocumentFile GetStudentDocumentFile(int id)
        {
            var uri = string.Format("/v1/enrolments/student-document/{0}/file", id);

            var docMetaData = GetStudentDocument(id);

            byte[] fileData = GetBinaryData(uri);

            return new StudentDocumentFile()
            {
                ID = docMetaData.ID,
                FileName = docMetaData.FileName,
                IsConfidential = docMetaData.IsConfidential,
                FileData = fileData
            };
        }

        public void DeleteStudentDocument(int id)
        {
            DeleteData("/v1/enrolments/student-document", id);
        }


        // TODO Implement Student Document, Document Category



        public List<StudentFlagLink> GetStudentFlagLink(ICollection<StudentFlagLinkIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters<StudentFlagLinkIncludeOptions>("/v1/enrolments/student-flag-links", p);

            return GetAllData<StudentFlagLink>(uri);
        }


        public StudentFlagLink GetStudentFlagLink(int id, ICollection<StudentFlagLinkIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/student-flag-links/{0}", id);
            var uri = GetEndpointParameters<StudentFlagLinkIncludeOptions>(endpoint, p);

            return GetData<StudentFlagLink>(uri);
        }

        // TODO Add Student Flag Link PATCH/POST/DEL enpoints


        public List<StudentHouseholdRelationship> GetStudentHouseholdRelationship(ICollection<StudentHouseholdRelationIncludeOptions> include = null,
            int[] studentIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
                ["studentIds"] = studentIds
            };

            var uri = GetEndpointParameters<StudentHouseholdRelationIncludeOptions>("/v1/enrolments/student-households", p);
            return GetAllData<StudentHouseholdRelationship>(uri);

        }
        public StudentHouseholdRelationship GetStudentHouseholdRelationship(int id, ICollection<StudentHouseholdRelationIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
            };

            var endpoint = string.Format("/v1/enrolments/student-household/{0}", id);
            var uri = GetEndpointParameters<StudentHouseholdRelationIncludeOptions>(endpoint, p);
            return GetData<StudentHouseholdRelationship>(uri);

        }
        public Household GetStudentHouseholdDetails(int id)
        {
            return GetData<Household>(string.Format("/v1/enrolments/student-household/{0}/household?include=addresses", id));

        }
        public List<Student> GetStudentHouseholdStudents(int studentHouseholdId, ICollection<StudentIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include,
            };

            var endpoint = string.Format("/v1/enrolments/student-household/{0}/student", studentHouseholdId);
            var uri = GetEndpointParameters<StudentIncludeOptions>(endpoint, p);
            return GetAllData<Student>(uri);
        }

        public List<StudentHistory> GetStudentSchoolHistory(int[] ids = null, int[] studentIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["studentIds"] = studentIds
            };

            var uri = GetEndpointParameters("/v1/enrolments/student-school-history", p);

            return GetAllData<StudentHistory>(uri);
        }


        public StudentHistory GetStudentSchoolHistory(int id)
        {
            return GetData<StudentHistory>(string.Format("/v1/enrolments/student-school-history/{0}", id));
        }


        public List<Vaccination> GetVaccination(ICollection<VaccinationIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var uri = GetEndpointParameters<VaccinationIncludeOptions>("/v1/enrolments/vaccination", p);

            return GetAllData<Vaccination>(uri);
        }


        public Vaccination GetVaccination(int id, ICollection<VaccinationIncludeOptions> include = null)
        {
            var p = new Dictionary<string, object>
            {
                ["include"] = include
            };

            var endpoint = string.Format("/v1/enrolments/vaccination/{0}", id);
            var uri = GetEndpointParameters<VaccinationIncludeOptions>(endpoint, p);

            return GetData<Vaccination>(uri);
        }

        public List<YearLevel> GetYearLevel(int[] ids = null, int[] schoolIds = null)
        {
            var p = new Dictionary<string, object>
            {
                ["ids"] = ids,
                ["schoolIds"] = schoolIds
            };

            var uri = GetEndpointParameters("/v1/enrolments/year-level", p);

            return GetAllData<YearLevel>(uri);
        }


        public YearLevel GetYearLevel(int id)
        {
            return GetData<YearLevel>(string.Format("/v1/enrolments/year-level/{0}", id));
        }




    }
}
