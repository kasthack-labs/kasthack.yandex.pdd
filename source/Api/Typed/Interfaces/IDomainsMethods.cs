using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IDomainsMethods
    {
        Task<DomainsResponse> GetDomains(int? page = null, int? onPage = null);
    }
}