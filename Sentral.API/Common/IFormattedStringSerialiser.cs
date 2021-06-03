using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Common
{
    public interface IFormattedStringSerialiser
    {
        object DeserialiseText(string objectData);

        string SerialiseText();
    }
}
