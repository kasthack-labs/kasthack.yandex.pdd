/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kasthack.yandex.pdd.Helpers
{

    /*
        true/1/yes/ok -> true
        false/0/no/error -> false
    */

    internal class PerdonBoolConverter : JsonConverter {
        public override bool CanWrite => false;

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer ) {
            throw new NotImplementedException();
        }

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer ) {
            var jsonValue = serializer.Deserialize<JValue>( reader );
            switch ( jsonValue.Type ) {
                case JTokenType.Boolean:
                    return jsonValue.Value<bool>();
                case JTokenType.Integer: {
                    var value = jsonValue.Value<int>();
                    if ( value == 1 ) return true;
                    if ( value == 0 ) return false;
                    break; //anything else -> formatException
                }
                case JTokenType.String: {
                    var value = jsonValue.Value<string>();
                    if ( value == "yes"
                         || value == "ok" ) return true;
                    if ( value == "no"
                         || value == "error" ) return true;
                    break;
                }
                case JTokenType.Null:
                    return null;
            }
            throw new FormatException();
        }

        public override bool CanConvert( Type objectType ) => objectType == typeof( bool ) || objectType == typeof( bool? );
    }
}