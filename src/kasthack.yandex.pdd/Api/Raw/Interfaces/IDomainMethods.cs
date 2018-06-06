using kasthack.yandex.pdd.Entities;
using System.IO;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    /// <summary>
    /// Domain methods
    /// </summary>
    public interface IDomainMethods
    {
        /// <summary>
        /// Delete current domain. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-delete-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> Delete();
        /// <summary>
        /// Delete domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-del-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> DeleteLogo();
        /// <summary>
        /// Get domain info. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-details-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> Details();
        /// <summary>
        /// Get domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-check-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> GetLogo();
        /// <summary>
        /// Register current domain. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-register-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> Register();
        /// <summary>
        /// Get domain registration status. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-registrationstatus-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> RegistrationStatus();
        /// <summary>
        /// Set domain country. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-settings-set-country-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="country">Domain country</param>
        /// <returns>Response JSON</returns>
        Task<string> SetCountry(Country country);
        /// <summary>
        /// Upload domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-set-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> SetLogo(Stream source, string filename = null);
        /// <summary>
        /// Upload domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-set-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Response JSON</returns>
        Task<string> SetLogo(string file);
    }
}