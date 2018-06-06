using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    /// <summary>
    /// DKIM methods
    /// </summary>
    public interface IDkimMethods
    {
        /// <summary>
        /// Disable DKIM. <see href="https://tech.yandex.ru/pdd/doc/reference/dkim-disable-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>New DKIM status</returns>
        Task<DkimStatusResponse> Disable();
        /// <summary>
        /// Enable DKIM. <see href="https://tech.yandex.ru/pdd/doc/reference/dkim-enable-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>New DKIM status</returns>
        Task<DkimStatusResponse> Enable();
        /// <summary>
        /// Get DKIM status. <see href="https://tech.yandex.ru/pdd/doc/reference/dkim-status-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="secretkey">Use secret key</param>
        /// <returns>DKIM status</returns>
        Task<DkimStatusResponse> Status(bool? secretkey);
    }
}