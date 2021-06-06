using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sentral.API.Common
{
    public static class ByteExtensions
    {
        private const string _hexAlphabet = "0123456789ABCDEF";
        private static readonly Regex _hexBytePattern = new Regex("^([0-9A-F]{2})+$");
        private static readonly int[] _hexValue = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
               0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
               0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

        public static string ToHexString(this ICollection<byte> Bytes)
        {
            StringBuilder output = new StringBuilder(Bytes.Count * 2);

            foreach (byte byt in Bytes)
            {
                ToHexString(byt, output);
            }

            return output.ToString();
        }

        public static string ToHexString(this byte byt)
        {
            StringBuilder output = new StringBuilder(2);

            ToHexString(byt, output);

            return output.ToString();
        }


        private static void ToHexString(this byte byt, StringBuilder output)
        {
            output.Append(_hexAlphabet[(byt >> 4)]);
            output.Append(_hexAlphabet[(byt & 0xF)]);
        }

        public static byte[] ToByteArray(this string Hex)
        {
            if (!_hexBytePattern.IsMatch(Hex))
            {
                throw new ArgumentException("The string provided is not a valid hexidecimal code for a byte collection");
            }

            byte[] bytes = new byte[Hex.Length / 2];

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                bytes[x] = (byte)(_hexValue[char.ToUpper(Hex[i + 0]) - '0'] << 4 |
                                  _hexValue[char.ToUpper(Hex[i + 1]) - '0']);
            }

            return bytes;
        }
    }
}
