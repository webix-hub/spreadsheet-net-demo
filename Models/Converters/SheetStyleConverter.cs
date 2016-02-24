using System;
using SpreadSheet.Models;
using Newtonsoft.Json;

namespace SpreadSheet.Models
{
    internal class SheetStyleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SheetStyle);
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

            var obj = (SheetStyle)value;

            writer.WriteStartArray();
            writer.WriteValue(obj.Name);
            writer.WriteValue(obj.Text);
            writer.WriteEndArray();
        }
    }
}
