using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.Enrolments.Include
{
    public class PersonConsentIncludeOptions : AbstractIncludeOptions<EnumEnrolmentsIncludeOptions>
    {
        public PersonConsentIncludeOptions(
                bool person = false, bool consent = false, bool consentedBy = false

            ) : base(GetIncludeOptionList(
                    person, consent, consentedBy

                )) {}

        private static EnumEnrolmentsIncludeOptions[] GetIncludeOptionList(
                bool person = false, bool consent = false, bool consentedBy = false
            )
        {
            List<EnumEnrolmentsIncludeOptions> inclOptions = new List<EnumEnrolmentsIncludeOptions>();

            if (person)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Person);
            }
            if (consent)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.Consent);
            }

            if (consentedBy)
            {
                inclOptions.Add(EnumEnrolmentsIncludeOptions.ConsentedBy);
            }
            return inclOptions.ToArray();
        }
    }
}
