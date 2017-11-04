using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IDomainsMethods
    {
        Task<string> GetDomains(int? page, int? onPage);
    }
}