using System.IO;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IImportMethods
    {
        Task<string> CheckImport(int? page = null, int? onPage = null);
        Task<string> CheckSettings(ImportSettings settings);
        Task<string> StartImportFile(ImportSettings settings, Stream file);
        Task<string> StartImportFile(ImportSettings settings, string filename);
        Task<string> StartOneImport(SignleImportSettings settings);
        Task<string> StopAllImports();
    }
}