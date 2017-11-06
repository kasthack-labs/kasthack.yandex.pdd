using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Helpers.JsonConverters;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Settinns check result
    /// </summary>
    [JsonConverter(typeof(CheckResultConverter))]
    public enum CheckResult
    {
        /// <summary>
        /// OK
        /// </summary>
        Ok,
        /// <summary>
        /// No CNAME, no file
        /// </summary>
        NoCnameNoFile,
        /// <summary>
        /// Invalid CNAME, invalid file
        /// </summary>
        BadCnameBadFile,
        /// <summary>
        /// Invalid CNAME, no file
        /// </summary>
        BadCnameNoFile,
        /// <summary>
        /// No cname, invalid file
        /// </summary>
        NoCnameBadFile,
        /// <summary>
        /// Domain not found
        /// </summary>
        DomainNotFound,
        /// <summary>
        /// Domain is already occupied
        /// </summary>
        Occupied,
        /// <summary>
        /// Invalid MX
        /// </summary>
        MxWrong,
        /// <summary>
        /// MX not found
        /// </summary>
        MxNotFound
    }
}