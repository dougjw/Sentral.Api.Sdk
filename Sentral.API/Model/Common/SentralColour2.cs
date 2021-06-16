using Newtonsoft.Json;
using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sentral.API.Model.Common
{
    [JsonConverter(typeof(ToStringJsonConverter<SentralColour2>))]
    public sealed class SentralColour2 : AbstractSentralColour
    {
        private const string ValidColourPattern = "^[0-9A-F]{6}$";
        
        public SentralColour2() : base(ColourCodePrefix, 0, 0, 0)
        {
        }

        private SentralColour2(byte red, byte green, byte blue) : base("", red, green, blue)
        {
        }

        private SentralColour2(string colourCode) : base(colourCode)
        {
        }
        protected override bool ColourValid(string colourCode)
        {
            return Regex.IsMatch(colourCode, ValidColourPattern);
        }

        protected override AbstractSentralColour New(string colour)
        {
            return new SentralColour2(colour);
        }

        public override object DeserialiseText(string objectData)
        {
            return DeserialiseText<SentralColour2>(objectData);
        }
    }
}
