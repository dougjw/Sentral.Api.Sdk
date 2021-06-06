using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sentral.API.Common
{
    public class ToStringJsonConverter<T> : JsonConverter where T: IFormattedStringSerialiser, new()
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            T objectTemplate = new T();
            return objectTemplate.DeserialiseText((string)reader.Value);
        }
    }
}
