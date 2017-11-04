using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IMailListMethods
    {
        Task<string> Add(string maillist);
        Task<string> Delete(MailListId maillist);
        Task<string> GetCanSendOnBehalf(MailListId maillist, EmailAccountId subscriber);
        Task<string> List();
        Task<string> SetCanSendOnBehalf(MailListId maillist, EmailAccountId subscriber, bool canSendOnBehalf);
        Task<string> Subscribe(MailListId maillist, EmailAccountId subscriber, bool? canSendOnBehalf);
        Task<string> Subscribers(MailListId maillist);
        Task<string> Unsubscribe(MailListId maillist, EmailAccountId subscriber);
    }
}