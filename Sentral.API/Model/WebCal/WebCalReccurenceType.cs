using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Model.WebCal
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebCalRecurrenceType
    {
        day1,
        day2,
        day3,
        day4,
        day5,
        week,
        fortnight_even,
        fortnight_odd,
        month,
        year
    }
}
