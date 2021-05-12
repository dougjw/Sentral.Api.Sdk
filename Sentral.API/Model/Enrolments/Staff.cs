using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class Staff
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "staffCode")]
        public string StaffCode { get; set; }

        [JsonProperty(propertyName: "timetableCode")]
        public string TimetableCode { get; set; }

        [JsonProperty(propertyName: "barcode")]
        public string Barcode { get; set; }

        [JsonProperty(propertyName: "emergencyContactName")]
        public string EmergencyContactName { get; set; }

        [JsonProperty(propertyName: "emergencyContactPhone")]
        public string EmergencyContactPhone { get; set; }

        [JsonProperty(propertyName: "emergencyContactMobile")]
        public string EmergencyContactMobile { get; set; }

        [JsonProperty(propertyName: "employmentStatus")]
        public string EmploymentStatus { get; set; }

        [JsonProperty(propertyName: "employmentClassification")]
        public string EmploymentClassification { get; set; }

        [JsonProperty(propertyName: "jobTitle")]
        public string JobTitle { get; set; }

        [JsonProperty(propertyName: "contractCommencementDate")]
        public DateTime? ContractCommencementDate { get; set; }

        [JsonProperty(propertyName: "contractExpiryDate")]
        public DateTime? ContractExpiryDate { get; set; }

        [JsonProperty(propertyName: "wWCCNumber")]
        public string WWCCNumber { get; set; }

        [JsonProperty(propertyName: "wWCCStatus")]
        public string WWCCStatus { get; set; }

        [JsonProperty(propertyName: "wWCCExpiryDate")]
        public string WWCCExpiryDate { get; set; }

        [JsonProperty(propertyName: "codeOfConductDateSigned")]
        public DateTime? CodeOfConductDateSigned { get; set; }

        [JsonProperty(propertyName: "socialNetworkingPolicyDateSigned")]
        public DateTime? SocialNetworkingPolicyDateSigned { get; set; }

        [JsonProperty(propertyName: "childProtectionPolicyDateSigned")]
        public DateTime? ChildProtectionPolicyDateSigned { get; set; }

        [JsonProperty(propertyName: "iCTPolicyDateSigned")]
        public DateTime? ICTPolicyDateSigned { get; set; }

        [JsonProperty(propertyName: "firstAidExpiryDate")]
        public DateTime? FirstAidExpiryDate { get; set; }

        [JsonProperty(propertyName: "resuscitationExpiryDate")]
        public DateTime? ResuscitationExpiryDate { get; set; }

        [JsonProperty(propertyName: "publicLiabilityExpiryDate")]
        public DateTime? PublicLiabilityExpiryDate { get; set; }

        [JsonProperty(propertyName: "aGSNumber")]
        public string AGSNumber { get; set; }

        [JsonProperty(propertyName: "positionNumber")]
        public string PositionNumber { get; set; }

        [JsonProperty(propertyName: "payRate")]
        public string PayRate { get; set; }

        [JsonProperty(propertyName: "createdAt")]
        public SentralDateTime CreatedAt { get; set; }

        [JsonProperty(propertyName: "updatedAt")]
        public SentralDateTime UpdatedAt { get; set; }

        [JsonProperty(propertyName: "isActive")]
        public bool IsActive { get; set; }

        // Related Entities

        [JsonProperty(propertyName:"person")]
        public Relationship<Person> Person { get; set; }

    }
}
