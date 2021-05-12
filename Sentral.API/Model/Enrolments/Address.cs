using System;
using System.Collections.Generic;
using System.Text;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class Address
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "type")]
        public string Type;

        [JsonProperty(propertyName: "lotNumber")]
        public string LotNumber;

        [JsonProperty(propertyName: "unitNumber")]
        public string UnitNumber;

        [JsonProperty(propertyName: "streetNumber")]
        public string StreetNumber;

        [JsonProperty(propertyName: "houseNumber")]
        public string HouseNumber;

        [JsonProperty(propertyName: "blockNumber")]
        public string BlockNumber;

        [JsonProperty(propertyName: "floorNumber")]
        public string FloorNumber;

        [JsonProperty(propertyName: "propertyName")]
        public string PropertyName;

        [JsonProperty(propertyName: "streetName")]
        public string StreetName;

        [JsonProperty(propertyName: "streetType")]
        public string StreetType;

        [JsonProperty(propertyName: "addressLine1")]
        public string AddressLine1;

        [JsonProperty(propertyName: "addressLine2")]
        public string AddressLine2;

        [JsonProperty(propertyName: "addressLine3")]
        public string AddressLine3;

        [JsonProperty(propertyName: "suburb")]
        public string Suburb;

        [JsonProperty(propertyName: "section")]
        public string Section;

        [JsonProperty(propertyName: "city")]
        public string City;

        [JsonProperty(propertyName: "state")]
        public string State;

        [JsonProperty(propertyName: "country")]
        public string Country;

        [JsonProperty(propertyName: "postcode")]
        public string Postcode;

        [JsonProperty(propertyName: "comment")]
        public string Comment;

        [JsonProperty(propertyName: "locality")]
        public string Locality;

        [JsonProperty(propertyName: "province")]
        public string Province;

        [JsonProperty(propertyName: "startDate")]
        public DateTime? StartDate;

        [JsonProperty(propertyName: "endDate")]
        public DateTime? EndDAte;

        [JsonProperty(propertyName: "mailingTitle")]
        public string MailingTitle;

        [JsonProperty(propertyName: "isBillingAddress")]
        public bool IsBillingAddress;

        [JsonProperty(propertyName: "isValid")]
        public bool IsValid;

        [JsonProperty(propertyName: "isSimpleAddress")]
        public bool IsSimpleAddress;

        public override string ToString()
        {
            if (IsSimpleAddress)
            {
                return GetAddressFromSimpleFields();
            }
            return GetAddressFromAtomicFields();
        }

        private string GetAddressFromSimpleFields()
        {
            StringBuilder address = new StringBuilder();
            address.Append(GetAddressLine(AddressLine1));
            address.Append(GetAddressLine(AddressLine2));
            address.Append(GetAddressLine(AddressLine3));
            address.Append(GetAddressLine(Suburb, " "));
            address.Append(GetAddressLine(State, " "));
            address.Append(GetAddressLine(Postcode));
            address.Append(Country);
            return address.ToString();
        }

        private string GetAddressFromAtomicFields()
        {
            StringBuilder address = new StringBuilder();
            // TODO: Implement address from complex fields.
            return address.ToString();
        }

        private string GetAddressLine(string addressPart, string appendChars = " ")
        {
            if(string.IsNullOrWhiteSpace(addressPart))
            {
                return "";
            }
            return addressPart + "\r\n";
        }
    }
}
