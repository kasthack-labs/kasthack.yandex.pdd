using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kasthack.yandex.pdd.Helpers
{
    //https://stackoverflow.com/questions/17745866
    //converts doubles|strings -> ints
    internal class CustomIntConverter : JsonConverter {
        public override bool CanConvert( Type objectType ) => objectType == typeof( int ) || objectType == typeof(int?);

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer ) {
            var jsonValue = serializer.Deserialize<JValue>( reader );
            switch ( jsonValue.Type ) {
                case JTokenType.Float:
                    return (int) Math.Round( jsonValue.Value<double>() );
                case JTokenType.Integer:
                    return jsonValue.Value<int>();
                case JTokenType.String:
                    return int.Parse( jsonValue.Value<string>() );
                case JTokenType.Null:
                    return (int?)null;
            }
            throw new FormatException();
        }

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer ) => JObject.FromObject( value ).WriteTo( writer );
    }
}