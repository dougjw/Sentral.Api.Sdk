using System;
using System.Collections.Generic;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json;
using Sentral.API.Model.Common;
using System.Linq;

namespace Sentral.API.Model.Enrolments
{
    public class Household
    {
        private const string HomeAddressSifCode = "0765";
        private const string MailingAddressSifCode = "0123";

        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        [JsonProperty(propertyName: "addresses")]
        public List<Address> Addresses { get; set; }

        // Address Helper Functions
        public Address HomeAddress
        {
            get {
                if (Addresses != null)
                {
                    return Addresses.Where(x => x.Type == HomeAddressSifCode).FirstOrDefault();
                }
                return null;
            }
        }
        public Address MailingAddress
        {
            get
            {
                if (Addresses != null)
                {
                    return Addresses.Where(x => x.Type == MailingAddressSifCode).FirstOrDefault();
                }
                return null;
            }
        }
    }
}
