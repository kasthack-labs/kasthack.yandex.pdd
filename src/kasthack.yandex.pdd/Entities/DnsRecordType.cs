using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// DNS record type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DnsRecordType
    {
        /// <summary>
        /// SRV
        /// </summary>
        SRV,
        /// <summary>
        /// TXT
        /// </summary>
        TXT,
        /// <summary>
        /// NS
        /// </summary>
        NS,
        /// <summary>
        /// NX
        /// </summary>
        MX,
        /// <summary>
        /// SOA
        /// </summary>
        SOA,
        /// <summary>
        /// A
        /// </summary>
        A,
        /// <summary>
        /// AAAA
        /// </summary>
        AAAA,
        /// <summary>
        /// CNAME
        /// </summary>
        CNAME
    }
}