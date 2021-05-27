using Sentral.API.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Update
{
    public class SimpleStaffLink : AbstractSimpleLink
    {
        private const string _typeName = "staff";
        public SimpleStaffLink() : base(_typeName) { }
    }
}
