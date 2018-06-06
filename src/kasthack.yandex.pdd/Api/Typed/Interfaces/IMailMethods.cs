using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    /// <summary>
    /// Email methods
    /// </summary>
    public interface IMailMethods
    {
        /// <summary>
        /// Add an email. <see href="https://tech.yandex.ru/pdd/doc/reference/email-add-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <returns>Mailbox</returns>
        Task<AddEmailResponse> Add(string login, string password);
        /// <summary>
        /// Get mailbox counters. <see href="https://tech.yandex.ru/pdd/doc/reference/email-counters-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="id">User id (email/uid)</param>
        /// <returns>Mailbox counters</returns>
        Task<EmailCountersResponse> Counters(EmailAccountId id);
        /// <summary>
        /// Delete an email. <see href="https://tech.yandex.ru/pdd/doc/reference/email-del-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="id">User id (email/uid)</param>
        /// <returns>Deletion status</returns>
        Task<DeleteEmailResponse> Delete(EmailAccountId id);
        /// <summary>
        /// Update an email. <see href="https://tech.yandex.ru/pdd/doc/reference/email-edit-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="account">User data</param>
        /// <returns>Mailbox info</returns>
        Task<EditEmailResponse> Edit(EmailAccountBase account);
        /// <summary>
        /// Get emails. <see href="https://tech.yandex.ru/pdd/doc/reference/email-list-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="onPage">Page size</param>
        /// <returns>Mailboxes</returns>
        Task<ListEmailResponse> List(int? page = null, int? onPage = null);
    }
}