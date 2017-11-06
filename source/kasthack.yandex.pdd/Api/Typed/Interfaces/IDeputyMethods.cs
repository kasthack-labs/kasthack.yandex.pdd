using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    /// <summary>
    /// Domain deputy methods
    /// </summary>
    public interface IDeputyMethods
    {
        /// <summary>
        /// Add a deputy. <see href="https://tech.yandex.ru/pdd/doc/reference/deputy-add-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="login">Deputy login. Must be a @yandex.*</param>
        /// <returns>Add status</returns>
        Task<Response> Add(string login);
        /// <summary>
        /// Remove a deputy. <see href="https://tech.yandex.ru/pdd/doc/reference/deputy-delete-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="login">Deputy login. Must be a @yandex.*</param>
        /// <returns>Deletion status</returns>
        Task<Response> Delete(string login);
        /// <summary>
        /// Get deputies. <see href="https://tech.yandex.ru/pdd/doc/reference/deputy-list-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Deputies list</returns>
        Task<ListDeputiesResponse> List();
    }
}