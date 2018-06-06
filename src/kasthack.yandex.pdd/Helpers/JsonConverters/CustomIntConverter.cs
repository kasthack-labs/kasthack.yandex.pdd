using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kasthack.yandex.pdd.Helpers
{
    //https://stackoverflow.com/questions/17745866
    //converts doubles|strings -> ints
    internal class CustomIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(int) || objectType == typeof(int?);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Float:
                    return (int)Math.Round((double)reader.Value);
                case JsonToken.Integer:
                    return (int)reader.Value;
                case JsonToken.String:
                    return int.Parse((string)reader.Value);
                case JsonToken.Null:
                    return (int?)null;
            }
            throw new FormatException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => JObject.FromObject(value).WriteTo(writer);
    }
}