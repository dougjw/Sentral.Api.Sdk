using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public enum StudentIncludeOptions
    {
        PrimaryEnrolment,
        Person,
        Activities,
        ActivityInstances,
        Tenants,
        Flags,
        FlagLinks,
        Contacts,
        Holidays,
        SpecialNeedsPrograms,
        SchoolHistory
    }
}
