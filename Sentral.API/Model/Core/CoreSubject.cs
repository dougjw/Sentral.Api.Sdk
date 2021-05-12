using JsonApiSerializer.JsonApi;
using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;

namespace Sentral.API.Model.Core
{
    public class CoreSubject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExternalId { get; set; }
        public string ExternalSource { get; set; }
        public bool IsActive { get; set; }

    }
}