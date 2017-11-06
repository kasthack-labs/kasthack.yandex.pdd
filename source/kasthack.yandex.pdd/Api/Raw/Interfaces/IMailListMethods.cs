using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
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
        /// <returns>Response JSON</returns>
        Task<string> Add(string maillist);
        /// <summary>
        /// Delete a maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-del-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <returns>Response JSON</returns>
        Task<string> Delete(MailListId maillist);
        /// <summary>
        /// Check for user rights on maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-getcansend-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <returns>Response JSON</returns>
        Task<string> GetCanSendOnBehalf(MailListId maillist, EmailAccountId subscriber);
        /// <summary>
        /// Get maillists. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-list-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> List();
        /// <summary>
        /// Allow/disallow sending from maillist address for a user. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-setcansend-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <param name="canSendOnBehalf">Is user allowed to send from maillist address</param>
        /// <returns>Response JSON</returns>
        Task<string> SetCanSendOnBehalf(MailListId maillist, EmailAccountId subscriber, bool canSendOnBehalf);
        /// <summary>
        /// Add a subscriber to a maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-subscribe-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <param name="canSendOnBehalf">Is user allowed to send from maillist address</param>
        /// <returns>Response JSON</returns>
        Task<string> Subscribe(MailListId maillist, EmailAccountId subscriber, bool? canSendOnBehalf);
        /// <summary>
        /// Show maillist subscribers. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-subscribers-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <returns>Response JSON</returns>
        Task<string> Subscribers(MailListId maillist);
        /// <summary>
        /// Remove a subscriber from a maillist. <see href="https://tech.yandex.ru/pdd/doc/reference/email-ml-unsubscribe-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="maillist">Maillist id (email/uid)</param>
        /// <param name="subscriber">User id (email/uid)</param>
        /// <returns>Response JSON</returns>
        Task<string> Unsubscribe(MailListId maillist, EmailAccountId subscriber);
    }
}