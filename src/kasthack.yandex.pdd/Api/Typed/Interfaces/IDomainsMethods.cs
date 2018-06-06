using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    /// <summary>
    /// Domains methods
    /// </summary>
    public interface IDomainsMethods
    {
        /// <summary>
        /// Get registered domains for current user. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-domains-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="onPage">Page size</param>
        /// <returns>Domains list</returns>
        Task<DomainsResponse> GetDomains(int? page = null, int? onPage = null);
    }
}