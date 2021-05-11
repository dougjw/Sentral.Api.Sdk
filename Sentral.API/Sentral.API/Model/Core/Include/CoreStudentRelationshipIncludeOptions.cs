using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core.Include
{
    public class CoreStudentRelationshipIncludeOptions : AbstractIncludeOptions<EnumCoreIncludeOptions>
    {
        public CoreStudentRelationshipIncludeOptions(bool coreStudent = false) : 
            base(GetIncludeOptionList(coreStudent)) {}

        private static EnumCoreIncludeOptions[] GetIncludeOptionList(bool coreStudent)
        {
            List<EnumCoreIncludeOptions> inclOptions = new List<EnumCoreIncludeOptions>();

            if (coreStudent)
            {
                inclOptions.Add(EnumCoreIncludeOptions.CoreStudent);
            }
            return inclOptions.ToArray();
        }
    }
}
