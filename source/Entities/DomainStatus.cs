using kasthack.yandex.pdd.Helpers;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Entities
{
    [JsonConverter(typeof(WtfEnumConverter))]
    public enum DomainStatus
    {
        DomainActivate,
        MxActivate,
        Added
    }
}