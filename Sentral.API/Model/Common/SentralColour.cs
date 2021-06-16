﻿using Newtonsoft.Json;
using Sentral.API.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sentral.API.Model.Common
{
    [JsonConverter(typeof(ToStringJsonConverter<SentralColour>))]
    public sealed class SentralColour : AbstractSentralColour
    {
        private const string ValidColourPattern = "^#[0-9A-F]{6}$";

        public SentralColour() : base(ColourCodePrefix, 0, 0, 0)
        {
        }

        public SentralColour(byte red, byte green, byte blue) : base(ColourCodePrefix, red, green, blue)
        {
        }

        public SentralColour(string colourCode) : base(colourCode)
        {
        }

        protected override bool ColourValid(string colourCode)
        {
            return Regex.IsMatch(colourCode, ValidColourPattern);
        }

        protected override AbstractSentralColour New(string colour)
        {
            return new SentralColour(colour);
        }

        public override object DeserialiseText(string objectData)
        {
            return DeserialiseText<SentralColour>(objectData);
        }
    }
}