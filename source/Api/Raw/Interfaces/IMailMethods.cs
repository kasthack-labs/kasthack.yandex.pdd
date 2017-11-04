using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IMailMethods
    {
        Task<string> Add(string login, string password);
        Task<string> Counters(EmailAccountId id);
        Task<string> Delete(EmailAccountId id);
        Task<string> Edit(EmailAccountBase account);
        Task<string> List(int? page = null, int? onPage = null);
    }
}