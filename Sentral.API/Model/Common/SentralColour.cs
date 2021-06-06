using Newtonsoft.Json;
using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sentral.API.Model.Common
{
    [JsonConverter(typeof(ToStringJsonConverter<SentralColour>))]
    public class SentralColour : IComparable, IComparable<SentralColour>, IEquatable<SentralColour>, IFormattedStringSerialiser
    {
        private const string ValidColourPattern = "^#[0-9A-F]{6}$";

        private string _colourCode;


        public SentralColour() : this (0,0,0)
        {
        }

        public SentralColour(byte red, byte green, byte blue)
        {
            _colourCode = string.Format("#{0}{1}{2}",
                    red.ToString(),
                    green.ToString(),
                    blue.ToString()
                );

        }
        public SentralColour(string colourCode)
        {
            if(colourCode == null || !ColourValid(colourCode))
            {
                throw new InvalidOperationException("Argument pattern does not represent a valid colour code.");
            }

            _colourCode = colourCode;
        }

        public string ColourCode
        {
            get
            {
                return _colourCode;
            }
        }

        private bool ColourValid(string colourCode)
        {
            return Regex.IsMatch(colourCode, ValidColourPattern);
        }

        public int CompareTo(object obj)
        {
            return _colourCode.CompareTo(obj);
        }

        public int CompareTo(SentralColour other)
        {
            return _colourCode.CompareTo(other.ColourCode);
        }

        public bool Equals(SentralColour other)
        {
            return _colourCode.Equals(other.ColourCode);
        }

        public override string ToString()
        {
            return _colourCode;
        }

        public object DeserialiseText(string colour)
        {
            return new SentralColour(colour);
        }

        public string SerialiseText()
        {
            return ToString();
        }
    }
}
