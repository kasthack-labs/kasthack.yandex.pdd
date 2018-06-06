using kasthack.yandex.pdd.Helpers;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Domain registration statge
    /// </summary>
    [JsonConverter(typeof(WtfEnumConverter))]
    public enum RegistrationStage
    {
        /// <summary>
        /// Owner check
        /// </summary>
        OwnerCheck,
        /// <summary>
        /// MX check
        /// </summary>
        MxCheck,
        /// <summary>
        /// Added
        /// </summary>
        Added
    }
}