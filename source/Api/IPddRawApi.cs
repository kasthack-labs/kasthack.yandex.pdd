using System.Threading.Tasks;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd
{
    public interface IPddRawApi
    {
        YaToken AuthToken { get; set; }
        string PddToken { get; set; }

        IDomainRawContext Domain(string domain);
        Task<string> GetDomains(int? page = null, int? onPage = null);
    }
}