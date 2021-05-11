using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Core.Include
{
    public class CoreStudentIncludeOptions : AbstractIncludeOptions<EnumCoreIncludeOptions>
    {
        public CoreStudentIncludeOptions(bool additionalDetails = false, bool coreRollclass = false,
            bool attendedClasses = false, bool holidays = false, bool studentRelationships = false,
            bool coreHouse = false, bool contacts = false) : 
            base(GetIncludeOptionList(additionalDetails, coreRollclass, attendedClasses, holidays,
                studentRelationships, coreHouse, contacts)) {}

        private static EnumCoreIncludeOptions[] GetIncludeOptionList(bool additionalDetails, 
            bool coreRollclass, bool attendedClasses, bool holidays, bool studentRelationships,
            bool coreHouse, bool contacts)
        {
            List<EnumCoreIncludeOptions> inclOptions = new List<EnumCoreIncludeOptions>();

            if (additionalDetails)
            {
                inclOptions.Add(EnumCoreIncludeOptions.AdditionalDetails);
            }
            if (coreRollclass)
            {
                inclOptions.Add(EnumCoreIncludeOptions.CoreRollclass);
            }
            if (attendedClasses)
            {
                inclOptions.Add(EnumCoreIncludeOptions.AttendedClasses);
            }
            if (holidays)
            {
                inclOptions.Add(EnumCoreIncludeOptions.Holidays);
            }
            if (studentRelationships)
            {
                inclOptions.Add(EnumCoreIncludeOptions.StudentRelationships);
            }
            if (coreHouse)
            {
                inclOptions.Add(EnumCoreIncludeOptions.CoreHouse);
            }
            if (contacts)
            {
                inclOptions.Add(EnumCoreIncludeOptions.Contacts);
            }
            return inclOptions.ToArray();
        }
    }
}
