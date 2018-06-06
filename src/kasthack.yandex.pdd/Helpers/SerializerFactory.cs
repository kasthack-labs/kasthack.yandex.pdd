/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace kasthack.yandex.pdd.Helpers {
    internal static class SerializerFactory {
        public static JsonSerializer GetSerializer() {
            //snake case parsing
            var snakeCaseContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            var ser = new JsonSerializer { ContractResolver = snakeCaseContractResolver };
            ser.Converters.Add( new SnakeCaseEnumConverter { AllowIntegerValues = true, CamelCaseText = false } );
            ser.Converters.Add( new CustomIntConverter() );
            ser.Converters.Add( new PerdonBoolConverter() );
            return ser;
        }
    }
}