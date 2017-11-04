using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IMailMethods
    {
        Task<AddEmailResponse> Add(string login, string password);
        Task<EmailCountersResponse> Counters(EmailAccountId id);
        Task<DeleteEmailResponse> Delete(EmailAccountId id);
        Task<EditEmailResponse> Edit(EmailAccountBase account);
        Task<ListEmailResponse> List(int? page = null, int? onPage = null);
    }
}