/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kasthack.yandex.pdd.Helpers
{
    internal class DelimiterEnumConverter : StringEnumConverter
    {
        private readonly char _separator;

        public DelimiterEnumConverter(char separator) => _separator = separator;
        public override bool CanConvert(Type objectType)
        {
            if (IsNullableType(objectType)) objectType = Nullable.GetUnderlyingType(objectType);
            return objectType.IsEnum;
        }

        public override bool CanWrite => false;

        private static bool IsNullableType(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var isNullable = IsNullableType(objectType);
            var t = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;
            if (reader.TokenType == JsonToken.Null)
            {
                if (!IsNullableType(objectType)) throw new JsonSerializationException($"Cannot convert null value to {objectType}.");
                return null;
            }
            try
            {
                switch (reader.TokenType)
                {
                    case JsonToken.String:
                        return Enum.Parse(t, reader.Value.ToString().ToMeth(separator: _separator), true);
                    case JsonToken.Integer:
                        return base.ReadJson(reader, objectType, existingValue, serializer);
                }
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException($"Error converting value {reader.Value} to type '{objectType}'.", ex);
            }
            throw new JsonSerializationException($"Unexpected token {reader.TokenType.ToNCString()} when parsing enum.");
        }
    }
}