using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core.Include
{
    public class CoreStaffIncludeOptions : AbstractIncludeOptions<EnumCoreIncludeOptions>
    {
        public CoreStaffIncludeOptions(bool assignedClasses = false) : 
            base(GetIncludeOptionList(assignedClasses)) {}

        private static EnumCoreIncludeOptions[] GetIncludeOptionList( bool assignedClasses)
        {
            List<EnumCoreIncludeOptions> inclOptions = new List<EnumCoreIncludeOptions>();

            if (assignedClasses)
            {
                inclOptions.Add(EnumCoreIncludeOptions.AssignedClasses);
            }
            return inclOptions.ToArray();
        }
    }
}
