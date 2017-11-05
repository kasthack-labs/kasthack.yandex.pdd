using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kasthack.yandex.pdd.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DnsRecordType
    {
        SRV,
        TXT,
        NS,
        MX,
        SOA,
        A,
        AAAA,
        CNAME
    }
}