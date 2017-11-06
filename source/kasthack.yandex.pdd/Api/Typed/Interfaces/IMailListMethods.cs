using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    /// <summary>
    /// Maillist methods
    /// </summary>
    public interface IMailListMethods
    {
        /// <summary>
        /// Add a maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-add-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist"></param>
        /// <returns>Add result</returns>
        Task<AddMailListResponse> Add(string maillist);
        /// <summary>
        /// Delete a maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-del-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <returns>Deletion result</returns>
        Task<DeleteMailListResponse> Delete(MailListId maillist);
        /// <summary>
        /// Get maillists. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-list-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Maillists</returns>
        Task<ListMailListResponse> List();
        /// <summary>
        /// Add a subscriber to a maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-subscribe-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <param name="canSendOnBehalf">Is user allowed to send from maillist address</param>
        /// <returns>Subscription status</returns>
        Task<SubscribeMailListResponse> Subscribe(MailListId maillist, EmailAccountId subscriber, bool? canSendOnBehalf);
        /// <summary>
        /// Show maillist subscribers. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-subscribers-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <returns>Maillist subscribers</returns>
        Task<SubscribersMailListResponse> Subscribers(MailListId maillist);
        /// <summary>
        /// Remove a subscriber from a maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-unsubscribe-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <returns>SUbcription status</returns>
        Task<UnsubscribeMailListResponse> Unsubscribe(MailListId maillist, EmailAccountId subscriber);
        /// <summary>
        /// Check for user rights on maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-getcansend-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <param name="canSendOnBehalf">Is user allowed to send from maillist address</param>
        /// <returns>Rights status</returns>
        Task<SetCanSendToMailListResponse> SetCanSendToMailList(MailListId maillist, EmailAccountId subscriber, bool canSendOnBehalf);
        /// <summary>
        /// Check for user rights on maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-getcansend-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <returns>Rights status</returns>
        Task<GetCanSendToMailListResponse> GetCanSendToMailList(MailListId maillist, EmailAccountId subscriber);
    }
}