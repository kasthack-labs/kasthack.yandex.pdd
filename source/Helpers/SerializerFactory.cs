/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/

using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace kasthack.yandex.pdd.Helpers {
    public static class SerializerFactory {
        public static JsonSerializer GetSerializer() {
            //snake case parsing
            var snakeCaseContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            snakeCaseContractResolver.DefaultMembersSearchFlags |= BindingFlags.NonPublic;
            var ser = new JsonSerializer { ContractResolver = snakeCaseContractResolver };
            ser.Converters.Add( new SnakeCaseEnumConverter { AllowIntegerValues = true, CamelCaseText = false } );
            ser.Converters.Add( new CustomIntConverter() );
            ser.Converters.Add( new PerdonBoolConverter() );
            return ser;
        }
    }
}