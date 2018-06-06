using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
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
        /// <returns>Response JSON</returns>
        Task<string> GetDomains(int? page, int? onPage);
    }
}