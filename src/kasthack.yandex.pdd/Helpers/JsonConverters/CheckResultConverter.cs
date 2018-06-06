using kasthack.yandex.pdd.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace kasthack.yandex.pdd.Helpers.JsonConverters
{
    internal class CheckResultConverter : JsonConverter
    {
        private readonly Dictionary<string, CheckResult> _values = new Dictionary<string, CheckResult> {
            { "ok", CheckResult.Ok },
            { "no-cname,no-file", CheckResult.NoCnameNoFile },
            { "bad-cname,bad-file", CheckResult.BadCnameBadFile },
            { "bad-cname,no-file", CheckResult.BadCnameNoFile },
            { "no-cname,bad-file", CheckResult.NoCnameBadFile },
            { "domain-not-found", CheckResult.DomainNotFound },
            { "occupied", CheckResult.Occupied },
            { "mx-wrong", CheckResult.MxWrong },
            { "mx-not-found", CheckResult.MxNotFound },
        };
        public override bool CanConvert(Type objectType) => objectType == typeof(CheckResult) || objectType == typeof(CheckResult?);
        public override bool CanWrite => false;
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    return _values[(string)reader.Value];
                case JsonToken.Null:
                    return (CheckResult?)null;
                default:
                    throw new JsonSerializationException($"Unexpected token type {reader.TokenType} for {nameof(CheckResultConverter)}");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotSupportedException();
    }
}
