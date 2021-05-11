using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class StudentPersonRelationship
    {
        [JsonProperty(propertyName: "id")]
        public string ID { get; set; }

        [JsonProperty(propertyName: "priority")]
        public int Priority { get; set; }

        [JsonProperty(propertyName: "isAuthorisedPickup")]
        public bool IsAuthorisedPickup { get; set; }

        [JsonProperty(propertyName: "isEmergencyContact")]
        public bool IsEmergencyContact { get; set; }

        [JsonProperty(propertyName: "isFinanciallyResponsible")]
        public bool IsFinanciallyResponsible { get; set; }

        [JsonProperty(propertyName: "isFinanciallyResponsibleForActivities")]
        public bool IsFinanciallyResponsibleForActivities { get; set; }

        [JsonProperty(propertyName: "isPrimaryContact")]
        public bool IsPrimaryContact { get; set; }

        [JsonProperty(propertyName: "livesWith")]
        public bool LivesWith { get; set; }

        [JsonProperty(propertyName:"relationshipType")]
        public string RelationshipType { get; set; }
        [JsonProperty(propertyName: "relationshipName")]
        public string RelationshipName { get; set; }

        [JsonProperty(propertyName: "receivesMail")]
        public bool ReceivesMail { get; set; }

        [JsonProperty(propertyName: "receivesReports")]
        public bool ReceivesReports { get; set; }

        [JsonProperty(propertyName: "receivesPortalAccess")]
        public bool ReceivesPortalAccess { get; set; }

        [JsonProperty(propertyName: "receivesCorrespondence")]
        public bool ReceivesCorrespondence { get; set; }

        [JsonProperty(propertyName: "receivesAbsences")]
        public bool ReceivesAbsences { get; set; }

        [JsonProperty(propertyName:"student")]
        public Relationship<Student> Student { get; set; }

        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

        [JsonProperty(propertyName: "studentPerson")]
        public Relationship<Person> StudentPerson { get; set; }

    }
}
