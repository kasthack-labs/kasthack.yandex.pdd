using System.IO;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    /// <summary>
    /// Domain methods
    /// </summary>
    public interface IDomainMethods
    {
        /// <summary>
        /// Delete current domain. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-delete-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Deletion status</returns>
        Task<Response> Delete();
        /// <summary>
        /// Delete domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-del-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Deletion status</returns>
        Task<Response> DeleteLogo();
        /// <summary>
        /// Get domain info. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-details-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Domain info</returns>
        Task<DomainDetailsResponse> Details();
        /// <summary>
        /// Get domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-check-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Domain logo</returns>
        Task<LogoCheckResponse> GetLogo();
        /// <summary>
        /// Register current domain. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-register-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Registration status</returns>
        Task<RegisterResponse> Register();
        /// <summary>
        /// Get domain registration status. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-registrationstatus-docpage/">Yandex doc</see>
        /// </summary>
        /// <returns>Registration status</returns>
        Task<RegistrationStatusResponse> RegistrationStatus();
        /// <summary>
        /// Set domain country. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-settings-set-country-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="country">Domain country</param>
        /// <returns>Update status</returns>
        Task<SetCountryResponse> SetCountry(Country country);
        /// <summary>
        /// Upload domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-set-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="source">Source file stream</param>
        /// <param name="filename">Upload file name</param>
        /// <returns>Upload status</returns>
        Task<Response> SetLogo(Stream source, string filename);
        /// <summary>
        /// Upload domain logo. <see href="https://tech.yandex.ru/pdd/doc/reference/domain-logo-set-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="file">Path to source file</param>
        /// <returns>Upload status</returns>
        Task<Response> SetLogo(string file);
    }
}