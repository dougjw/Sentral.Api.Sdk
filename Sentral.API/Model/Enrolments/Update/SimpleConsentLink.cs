using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class SimpleConsentLink : AbstractSimpleLink
    {
        private const string _typeName = "consent";
        public SimpleConsentLink() : base(_typeName) { }
    }
}
