using System.IO;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IImportMethods
    {
        Task<CheckImportResponse> CheckImport(int? page = null, int? onPage = null);
        Task<ImportResponse> CheckSettings(ImportSettings settings);
        Task<ImportResponse> StartImportFile(ImportSettings settings, Stream file);
        Task<ImportResponse> StartImportFile(ImportSettings settings, string filename);
        Task<StartImportResponse> StartOneImport(SingleImportSettings settings);
        Task<Response> StopAllImports();
    }
}