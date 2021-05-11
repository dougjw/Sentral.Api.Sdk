using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class Student
    {
         [JsonProperty(propertyName:"id")]

         public int ID { get; set; }

        //TODO: Complete Stub

        [JsonProperty(propertyName:"studentCode")]
        public string StudentCode { get; set; }

        [JsonProperty(propertyName: "barcode")]
        public string Barcode { get; set; }

        [JsonProperty(propertyName: "permissionToPhotograph")]
        public bool PermissionToPhotograph { get; set; }

        [JsonProperty(propertyName: "examNumber")]
        public string ExamNumber { get; set; }

        [JsonProperty(propertyName: "usiId")]
        public string UsiId { get; set; }

        [JsonProperty(propertyName: "isEligibleForDiscount")]
        public bool IsEligibleForDiscount { get; set; }

        [JsonProperty(propertyName: "acaraId")]
        public string AcaraId { get; set; }

        [JsonProperty(propertyName: "systemStudentId")]
        public string SystemStudentId { get; set; }

        [JsonProperty(propertyName: "refId")]
        public Guid RefId { get; set; }

        [JsonProperty(propertyName: "ealStage")]
        public string EalStage { get; set; }

        [JsonProperty(propertyName: "ealIsReceivingSupport")]
        public bool? EalIsReceivingSupport { get; set; }

        [JsonProperty(propertyName: "ealLastAssessmentAt")]
        public DateTime? EalLastAssessmentAt { get; set; }

        [JsonProperty(propertyName: "isSubjectToCourtOrders")]
        public bool IsSubjectToCourtOrders { get; set; }

        [JsonProperty(propertyName: "courtOrderInformation")]
        public string CourtOrderInformation { get; set; }

        [JsonProperty(propertyName: "studentFirstLanguage")]
        public string StudentFirstLanguageCode { get; set; }

        [JsonProperty(propertyName: "indigenousStatus")]
        public string IndigenousStatus { get; set; }

        [JsonProperty(propertyName: "languageOtherThanEnglishSpokenAtHome")]
        public bool LanguageOtherThanEnglishSpokenAtHome { get; set; }

        [JsonProperty(propertyName: "studentMainlySpeaksEnglishAtHome")]
        public bool StudentMainlySpeaksEnglishAtHome { get; set; }

        [JsonProperty(propertyName: "loteBackground")]
        public string LoteBackground { get; set; }

        [JsonProperty(propertyName: "createdAt")]
        public SentralDateTime CreatedAt { get; set; }

        [JsonProperty(propertyName: "updatedAt")]
        public SentralDateTime UpdatedAt { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(propertyName: "primaryEnrolment")]
        public Relationship<Enrolment> PrimaryEnrolment { get; set; }

        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

        [JsonProperty(propertyName: "contacts")]
        public Relationship<List<StudentPersonRelationship>> Contacts { get; set; }

        [JsonProperty(propertyName: "activities")]
        public Relationship<List<Model.Activities.Activity>> Activities { get; set; }

        //[JsonProperty(propertyName: "activityLinks")]
        //public Relationship<ActivityLink> ActivityLink { get; set; }

        [JsonProperty(propertyName: "tenants")]
        public Relationship<List<Tenant>> Tenants { get; set; }

        [JsonProperty(propertyName: "flags")]
        public Relationship<List<Flag>> Flags { get; set; }

        [JsonProperty(propertyName: "flagLinks")]
        public Relationship<List<Enrolment>> FlagLinks { get; set; }

        //TODO Implement Awards
        //[JsonProperty(propertyName: "awards")]
        //public List<Award> Awards { get; set; }
        //
        //[JsonProperty(propertyName: "awardLinks")]
        //public Relationship<AwardLink> AwardLinks { get; set; }
        //
        [JsonProperty(propertyName: "households")]
        public Relationship<List<Household>> Households { get; set; }
    }
}
