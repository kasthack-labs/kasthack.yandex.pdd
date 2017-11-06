using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    /// <summary>
    /// DKIM methods
    /// </summary>
    public interface IDkimMethods
    {
        /// <summary>
        /// Disable DKIM. <see href="https://tech.yandex.ru/pdd/doc/reference/dkim-disable-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> Disable();
        /// <summary>
        /// Enable DKIM. <see href="https://tech.yandex.ru/pdd/doc/reference/dkim-enable-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> Enable();
        /// <summary>
        /// Get DKIM status. <see href="https://tech.yandex.ru/pdd/doc/reference/dkim-status-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="secrectkey">Use secret key</param>
        /// <returns>Response JSON</returns>
        Task<string> Status(bool? secrectkey);
    }
}