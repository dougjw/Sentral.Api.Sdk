using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class PersonMedicalMisc
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "hasLongTermMedication")]
        public bool HasLongTermMedication { get; set; }

        [JsonProperty(propertyName: "wasMedicationAdviceFormReceived")]
        public bool WasMedicationAdviceFormReceived { get; set; }

        [JsonProperty(propertyName: "lastDateOfTetanusInjection")]
        public DateTime? LastDateOfTetanusInjection { get; set; }

        [JsonProperty(propertyName: "canOverCounterMedicineSalbutamol")]
        public bool CanOverCounterMedicineSalbutamol { get; set; }

        [JsonProperty(propertyName: "canOverCounterMedicineParacetamol")]
        public bool CanOverCounterMedicineParacetamol { get; set; }

        [JsonProperty(propertyName: "canOverCounterMedicineIbuprofen")]
        public bool CanOverCounterMedicineIbuprofen { get; set; }

        [JsonProperty(propertyName: "canOverCounterMedicineAntihistamine")]
        public bool CanOverCounterMedicineAntihistamine { get; set; }

        [JsonProperty(propertyName: "ambulanceCoverProvider")]
        public string AmbulanceCoverProvider { get; set; }

        [JsonProperty(propertyName: "medicareNumber")]
        public string MedicareNumber { get; set; }

        [JsonProperty(propertyName: "medicareExpiryDate")]
        public DateTime? MedicareExpiryDate { get; set; }

        [JsonProperty(propertyName: "medicarePositionOnCard")]
        public string MedicarePositionOnCard { get; set; }

        [JsonProperty(propertyName: "privateMedicalFund")]
        public string PrivateMedicalFund { get; set; }

        [JsonProperty(propertyName: "privateMedicalFundNumber")]
        public string PrivateMedicalFundNumber { get; set; }

        [JsonProperty(propertyName: "privateMedicalFundExpiryDate")]
        public DateTime? PrivateMedicalFundExpiryDate { get; set; }

        [JsonProperty(propertyName: "hasParentAcknowledged")]
        public bool HasParentAcknowledged { get; set; }

        [JsonProperty(propertyName: "areVaccinationsUpToDate")]
        public bool VaccinationsUpToDate { get; set; }

        [JsonProperty(propertyName: "hasMeaslesExclusion")]
        public bool HasMeaslesExclusion { get; set; }

        [JsonProperty(propertyName: "hasAmbulanceCover")]
        public bool HasAmbulanceCover { get; set; }



        [JsonProperty(propertyName: "person")]
        public Relationship<Person> Person { get; set; }

    }
}
