using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sentral.API.Common
{
    public class RandomStringBuilder
    {
        private static Random _random = new Random();
        private static string _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(int length)
        {
            
            return new string(Enumerable.Repeat(_characters, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
