/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kasthack.yandex.pdd.Helpers
{

    // "enum_value" -> Enum.EnumValue
    internal class SnakeCaseEnumConverter : DelimiterEnumConverter
    {
        public SnakeCaseEnumConverter() : base('_') { }
    }
}