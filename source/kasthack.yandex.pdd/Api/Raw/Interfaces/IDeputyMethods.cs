using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
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
        /// <returns>Response json</returns>
        Task<string> Add(string login);
        /// <summary>
        /// Remove a deputy. <see href="https://tech.yandex.ru/pdd/doc/reference/deputy-delete-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="login">Deputy login. Must be a @yandex.*</param>
        /// <returns>Response json</returns>
        Task<string> Delete(string login);
        /// <summary>
        /// Get deputies. <see href="https://tech.yandex.ru/pdd/doc/reference/deputy-list-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response json</returns>
        Task<string> List();
    }
}