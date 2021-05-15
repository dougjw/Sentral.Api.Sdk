using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Activities.Include
{
    public class ActivityIncludeOptions : AbstractIncludeOptions<EnumActivitiesIncludeOptions>
    {
        
        public ActivityIncludeOptions( bool venue = false) : base(GetIncludeOptionList(venue)) {}

        private static EnumActivitiesIncludeOptions[] GetIncludeOptionList( bool venue)
        {
            List<EnumActivitiesIncludeOptions> inclOptions = new List<EnumActivitiesIncludeOptions>();

            if (venue)
            {
                inclOptions.Add(EnumActivitiesIncludeOptions.Venue);
            }

            return inclOptions.ToArray();
        }
    }
}
