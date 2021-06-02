using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core.Update
{
    public class SimpleCoreAdministrativeUserLink : AbstractSimpleLink
    {
        private const string _typeName = "coreAdministrativeUser";
        public SimpleCoreAdministrativeUserLink() : base(_typeName) { }
    }
}
