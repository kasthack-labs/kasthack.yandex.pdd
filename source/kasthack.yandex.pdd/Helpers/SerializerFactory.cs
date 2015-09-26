/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/
using System.Reflection;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Helpers {
    public static class SerializerFactory {
        public static JsonSerializer GetSerializer() {
            //snake case parsing
            var snakeCaseContractResolver = new SnakeCaseContractResolver();
#pragma warning disable 618
            snakeCaseContractResolver.DefaultMembersSearchFlags |= BindingFlags.NonPublic;
#pragma warning restore 618
            var ser = new JsonSerializer { ContractResolver = snakeCaseContractResolver };
            ser.Converters.Add( new SnakeCaseEnumConverter { AllowIntegerValues = true, CamelCaseText = false } );
            ser.Converters.Add( new CustomIntConverter() );
            return ser;
        }
    }
}