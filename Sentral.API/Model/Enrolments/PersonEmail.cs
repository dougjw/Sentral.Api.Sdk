﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Enrolments.Update;
using Sentral.API.Model.Common;

namespace Sentral.API.Model.Enrolments
{
    public class PersonEmail : IToUpdatable<UpdatePersonEmail>
    {
        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Email { get; set; }

        [JsonProperty(propertyName: "type")]
        public string EmailType { get; set; }

        [JsonProperty(propertyName: "typeName")]
        public string EmailTypeName { get; set; }

        public bool CanContact { get; set; }

        public Relationship<SimpleRelationshipLink> Owner { get; set; }

        public UpdatePersonEmail ToUpdatable()
        {
            return new UpdatePersonEmail(ID)
            {
                Email = Email,
                EmailType = Email,
                Owner = Owner
            };
        }
    }
}
