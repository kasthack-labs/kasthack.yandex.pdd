using System.IO;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    /// <summary>
    /// Import methods
    /// </summary>
    public interface IImportMethods
    {
        /// <summary>
        /// Check import status. <see href="https://tech.yandex.ru/pdd/doc/reference/import-check-imports-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <param name="onPage">Page size</param>
        /// <returns>Import status</returns>
        Task<CheckImportResponse> CheckImport(int? page = null, int? onPage = null);
        /// <summary>
        /// Check import settings. <see href="https://tech.yandex.ru/pdd/doc/reference/import-settings-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="settings">Import settings</param>
        /// <returns>Check result</returns>
        Task<ImportResponse> CheckSettings(ImportSettings settings);
        /// <summary>
        /// Import emails from file. <see href="https://tech.yandex.ru/pdd/doc/reference/import-start-import-file-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="settings">import settings</param>
        /// <param name="file">Emails file</param>
        Task<ImportResponse> StartImportFile(ImportSettings settings, Stream file);
        /// <summary>
        /// Import emails from file. <see href="https://tech.yandex.ru/pdd/doc/reference/import-start-import-file-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="settings">import settings</param>
        /// <param name="filename">Path to emails file</param>
        Task<ImportResponse> StartImportFile(ImportSettings settings, string filename);
        /// <summary>
        /// Import a single mailbox. <see href="https://tech.yandex.ru/pdd/doc/reference/import-start-one-docpage/">Yandex doc</see>
        /// </summary>
        /// <param name="settings">Import settings</param>
        Task<StartImportResponse> StartOneImport(SingleImportSettings settings);
        /// <summary>
        /// Stop all imports. <see href="https://tech.yandex.ru/pdd/doc/reference/import-stop-all-imports-docpage/">Yandex doc</see>
        /// </summary>
        Task<Response> StopAllImports();
    }
}