using Newtonsoft.Json;
using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sentral.API.Model.Common
{

    public abstract class AbstractSentralColour : IComparable, IComparable<AbstractSentralColour>, IEquatable<AbstractSentralColour>, IFormattedStringSerialiser
    {
        protected const string ColourCodePrefix = "#";

        private string _colourCode;

        protected abstract AbstractSentralColour New(string colour);

        protected AbstractSentralColour(string prefix, byte red, byte green, byte blue)
        {
            _colourCode = string.Format("#{0}{1}{2}",
                    red.ToHexString(),
                    green.ToHexString(),
                    blue.ToHexString()
                );

        }
        public AbstractSentralColour(string colourCode)
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

        protected abstract bool ColourValid(string colourCode);

        public int CompareTo(object obj)
        {
            return _colourCode.CompareTo(obj);
        }

        public int CompareTo(AbstractSentralColour other)
        {
            return _colourCode.CompareTo(other.ColourCode);
        }

        public bool Equals(AbstractSentralColour other)
        {
            return _colourCode.Equals(other.ColourCode);
        }

        public override string ToString()
        {
            return _colourCode;
        }

        public object DeserialiseText<T>(string colour) where T : AbstractSentralColour, new()
        {
            T inst =  new T();

            return inst.New(colour);

        }

        public string SerialiseText()
        {
            return ToString();
        }

        abstract public object DeserialiseText(string objectData);
    }
}
