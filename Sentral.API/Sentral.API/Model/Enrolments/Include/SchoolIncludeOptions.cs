using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class SchoolIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        
        public SchoolIncludeOptions(
                bool tenant = false

            ) : base(GetIncludeOptionList(
                    tenant
                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool tenant = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (tenant)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Tenant);
            }

            return inclOptions.ToArray();
        }
    }
}
