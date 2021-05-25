using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class SimplePersonLink : AbstractSimpleLink
    {
        private const string _typeName = "person";
        public SimplePersonLink() : base(_typeName) { }
    }
}
