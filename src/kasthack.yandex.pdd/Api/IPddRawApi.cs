using System.Threading.Tasks;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd
{
    /// <summary>
    /// PDD raw(strings) api
    /// </summary>
    public interface IPddRawApi : ITokenModedApi
    {
        /// <summary>
        /// Get exectuion context for a domain
        /// </summary>
        /// <param name="domain">domain name</param>
        /// <returns>Context</returns>
        IDomainRawContext Domain(string domain);
        /// <summary>
        /// Get available domains
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="onPage">Page size</param>
        /// <returns>Domains json</returns>
        Task<string> GetDomains(int? page = null, int? onPage = null);
    }
}