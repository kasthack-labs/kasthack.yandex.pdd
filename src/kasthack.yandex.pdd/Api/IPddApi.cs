using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd
{
    /// <summary>
    /// Typed PDD api
    /// </summary>
    public interface IPddApi : ITokenModedApi
    {
        /// <summary>
        /// Get exectuion context for a domain
        /// </summary>
        /// <param name="domain">domain name</param>
        /// <returns>Context</returns>
        IDomainContext Domain(string domain);
        /// <summary>
        /// Get available domains
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="onPage">Page size</param>
        /// <returns>Domains</returns>
        Task<DomainsResponse> GetDomains(int? page = null, int? onPage = null);
    }
}