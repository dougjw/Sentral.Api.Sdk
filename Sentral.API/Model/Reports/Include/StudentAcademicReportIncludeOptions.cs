using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Reports.Include
{
    public class StudentAcademicReportIncludeOptions : AbstractIncludeOptions<EnumReportsIncludeOptions>
    {
        
        public StudentAcademicReportIncludeOptions(
                bool period = false

            ) : base(GetIncludeOptionList(
                    period
                )) {}

        private static EnumReportsIncludeOptions[] GetIncludeOptionList(
                bool period = false
            )
        {
            List<EnumReportsIncludeOptions> inclOptions = new List<EnumReportsIncludeOptions>();

            if (period)
            {
                inclOptions.Add(EnumReportsIncludeOptions.Period);
            }

            return inclOptions.ToArray();
        }
    }
}
