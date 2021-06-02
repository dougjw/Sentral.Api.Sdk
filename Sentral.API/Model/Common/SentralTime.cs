using Newtonsoft.Json;
using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sentral.API.Model.Common
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public class SentralTime : IComparable, IComparable<SentralTime>, IEquatable<SentralTime>
    {
        private DateTime _time;


        public SentralTime(int hours, int minutes, int seconds)
        {
            if (!HoursValid(hours) || !MinOrSecValid(minutes) || !MinOrSecValid(seconds))
            {
                throw new InvalidOperationException("Argument values do not represent a valid time.");
            }

            _time = DateTime.MinValue.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
        }
        public SentralTime(string timePattern)
        {
            if(timePattern == null)
            {
                return;
            }
            if (!TimePatternValid(timePattern))
            {
                throw new InvalidOperationException("Argument pattern does not represent a valid time.");
            }

            _time = DateTime.Parse("01/01/0001 " + timePattern);
        }

        private bool TimePatternValid(string timePattern)
        {
            return Regex.IsMatch(timePattern, "^([01][0-9]|2[0-3])(:[0-5][0-9]){2}$");
        }

        private bool HoursValid(int hours)
        {
            return hours >= 0 || hours <= 23;
        }
        private bool MinOrSecValid(int number)
        {
            return number >= 0 || number <= 59;
        }

        public int CompareTo(object obj)
        {
            return _time.CompareTo(obj);
        }

        public int CompareTo(SentralTime other)
        {
            return _time.CompareTo(other.GetDateTimeValue);
        }

        public bool Equals(SentralTime other)
        {
            return _time.Equals(other.GetDateTimeValue);
        }

        public override string ToString()
        {
            return _time.ToString("HH:mm:ss");
        }

        private DateTime GetDateTimeValue{
            get {
                return _time;
            }
        }
    }
}
