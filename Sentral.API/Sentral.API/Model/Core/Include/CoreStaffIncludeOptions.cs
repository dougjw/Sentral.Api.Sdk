using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core.Include
{
    public class CoreClassIncludeOptions : AbstractIncludeOptions<EnumCoreIncludeOptions>
    {
        public CoreClassIncludeOptions(
                bool assignedStaff = false, bool AssignedStudents = false

            ) : base(GetIncludeOptionList(
                    assignedStaff, AssignedStudents

                )) {}

        private static EnumCoreIncludeOptions[] GetIncludeOptionList(
                bool assignedStaff, bool assignedStudents
            )
        {
            List<EnumCoreIncludeOptions> inclOptions = new List<EnumCoreIncludeOptions>();

            if (assignedStaff)
            {
                inclOptions.Add(EnumCoreIncludeOptions.AssignedStaff);
            }
            if (assignedStudents)
            {
                inclOptions.Add(EnumCoreIncludeOptions.AssignedStudents);
            }
            return inclOptions.ToArray();
        }
    }
}
