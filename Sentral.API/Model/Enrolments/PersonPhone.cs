using Newtonsoft.Json;
using Sentral.API.Model.Common;
using Sentral.API.Model.Enrolments.Update;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments
{
    public class PersonPhone :IToUpdatable<UpdatePersonPhone>
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Number { get; set; }

        public string Extension { get; set; }

        [JsonProperty(propertyName: "type")]
        public string PhoneType { get; set; }

        [JsonProperty(propertyName: "typeName")]
        public string TypeName { get; set; }

        public bool IsListed { get; set; }

        public bool CanContact { get; set; }

        public UpdatePersonPhone ToUpdatable()
        {
            return new UpdatePersonPhone(ID)
            {
                Number = Number,
                Extension = Extension,
                PhoneType = PhoneType,
                IsListed = IsListed,
                CanContact = CanContact
            };
        }
    }
}
