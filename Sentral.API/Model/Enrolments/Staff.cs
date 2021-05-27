using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.Enrolments.Update;

namespace Sentral.API.Model.Enrolments
{
    public class Staff : IToUpdatable<UpdateStaff>
    {

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string StaffCode { get; set; }

        public string TimetableCode { get; set; }

        public string Barcode { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public string EmergencyContactMobile { get; set; }

        public string EmploymentStatus { get; set; }

        public string EmploymentClassification { get; set; }

        public string JobTitle { get; set; }

        public DateTime? ContractCommencementDate { get; set; }

        public DateTime? ContractExpiryDate { get; set; }

        [JsonProperty(propertyName: "wWCCNumber")]
        public string WWCCNumber { get; set; }

        [JsonProperty(propertyName: "wWCCStatus")]
        public string WWCCStatus { get; set; }

        [JsonProperty(propertyName: "wWCCExpiryDate")]
        public DateTime? WWCCExpiryDate { get; set; }

        public DateTime? CodeOfConductDateSigned { get; set; }

        public DateTime? SocialNetworkingPolicyDateSigned { get; set; }

        public DateTime? ChildProtectionPolicyDateSigned { get; set; }

        [JsonProperty(propertyName: "iCTPolicyDateSigned")]
        public DateTime? ICTPolicyDateSigned { get; set; }

        public DateTime? FirstAidExpiryDate { get; set; }

        public DateTime? ResuscitationExpiryDate { get; set; }

        public DateTime? PublicLiabilityExpiryDate { get; set; }

        [JsonProperty(propertyName: "aGSNumber")]
        public string AGSNumber { get; set; }

        public string PositionNumber { get; set; }

        public string PayRate { get; set; }

        public SentralDateTime CreatedAt { get; set; }

        public SentralDateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }

        // Related Entities

        [JsonProperty(propertyName:"person")]
        public Relationship<Person> Person { get; set; }

        public UpdateStaff ToUpdatable()
        {
            return new UpdateStaff(ID)
            {
                StaffCode = StaffCode,
                TimetableCode = TimetableCode,
                Barcode = Barcode,
                EmergencyContactName = EmergencyContactName,
                EmergencyContactPhone = EmergencyContactPhone,
                EmergencyContactMobile = EmergencyContactMobile,
                EmploymentStatus = EmploymentStatus,
                EmploymentClassification = EmploymentClassification,
                JobTitle = JobTitle,
                ContractCommencementDate = ContractCommencementDate,
                ContractExpiryDate = ContractExpiryDate,
                WWCCNumber = WWCCNumber,
                WWCCStatus = WWCCStatus,
                WWCCExpiryDate = WWCCExpiryDate,
                CodeOfConductDateSigned = CodeOfConductDateSigned,
                SocialNetworkingPolicyDateSigned = SocialNetworkingPolicyDateSigned,
                ChildProtectionPolicyDateSigned = ChildProtectionPolicyDateSigned,
                ICTPolicyDateSigned = ICTPolicyDateSigned,
                FirstAidExpiryDate = FirstAidExpiryDate,
                ResuscitationExpiryDate = ResuscitationExpiryDate,
                PublicLiabilityExpiryDate = PublicLiabilityExpiryDate,
                AGSNumber = AGSNumber
            };
        }
    }
}
