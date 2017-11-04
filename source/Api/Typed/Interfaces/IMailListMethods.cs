using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IMailListMethods
    {
        Task<AddMailListResponse> Add(string maillist);
        Task<DeleteMailListResponse> Delete(MailListId maillist);
        Task<ListMailListResponse> List();
        Task<SubscribeMailListResponse> Subscribe(MailListId maillist, EmailAccountId subscriber, bool? canSendOnBehalf);
        Task<SubscribersMailListResponse> Subscribers(MailListId maillist);
        Task<UnsubscribeMailListResponse> Unsubscribe(MailListId maillist, EmailAccountId subscriber);
    }
}