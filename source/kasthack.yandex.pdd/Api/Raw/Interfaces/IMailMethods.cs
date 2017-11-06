using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
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
        /// <returns>Response JSON</returns>
        Task<string> Add(string login, string password);
        /// <summary>
        /// Get mailbox counters. <see href="https://tech.yandex.ru/pdd/doc/reference/email-counters-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="id">User id (email/uid)</param>
        /// <returns>Response JSON</returns>
        Task<string> Counters(EmailAccountId id);
        /// <summary>
        /// Delete an email. <see href="https://tech.yandex.ru/pdd/doc/reference/email-del-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="id">User id (email/uid)</param>
        /// <returns>Response JSON</returns>
        Task<string> Delete(EmailAccountId id);
        /// <summary>
        /// Update an email. <see href="https://tech.yandex.ru/pdd/doc/reference/email-edit-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="account">User data</param>
        /// <returns>Response JSON</returns>
        Task<string> Edit(EmailAccountBase account);
        /// <summary>
        /// Get emails. <see href="https://tech.yandex.ru/pdd/doc/reference/email-list-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="onPage">Page size</param>
        /// <returns>Response JSON</returns>
        Task<string> List(int? page = null, int? onPage = null);
    }
}