using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Common
{
    public abstract class AbstractSimpleLink
    {
        protected AbstractSimpleLink(string typeName)
        {
            Type = typeName;

        }


        [JsonProperty(propertyName: "id")]
        public int ID { get; set; }

        public string Type { get; private set; }
    }
}
