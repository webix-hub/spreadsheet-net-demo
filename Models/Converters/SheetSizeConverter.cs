using System;
using SpreadSheet.Models;
using Newtonsoft.Json;

namespace SpreadSheet.Models
{
    internal class SheetSizeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SheetSize);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var obj = (SheetSize)value;

            writer.WriteStartArray();
            writer.WriteValue(obj.Row);
            writer.WriteValue(obj.Column);
            writer.WriteValue(obj.Size);
            writer.WriteEndArray();
        }
    }
}
