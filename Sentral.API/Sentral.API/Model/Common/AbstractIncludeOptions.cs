using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Common
{
    public abstract class AbstractIncludeOptions<T> where T: Enum
    {
        private readonly T[] _options;

        internal AbstractIncludeOptions(T[] options)
        {
            _options = options;
        }

        override public string ToString()
        {
            StringBuilder includeList = new StringBuilder();

            foreach(var option in _options)
            {
                includeList.Append(GetOptionString(option));
                includeList.Append(",");
            }
            // strip last comma
            includeList.Remove(includeList.Length - 1, 1);
            return includeList.ToString();
        }

        private string GetOptionString(T option)
        {
            var temp = option.ToString().ToCharArray();

            // Change to camel case
            temp[0] = char.ToLower(temp[0]);

            return new string(temp);
        }



    }
}
