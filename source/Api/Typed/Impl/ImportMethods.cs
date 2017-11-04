using System.IO;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{

    internal class ImportMethods : MethodsBase<RawMethods.IImportMethods>, IImportMethods
    {

        internal ImportMethods(RawMethods.IImportMethods parent) : base(parent) { }

        public async Task<ImportResponse> CheckSettings(ImportSettings settings) => await Process<ImportResponse>(Parent.CheckSettings(settings)).ConfigureAwait(false);

        public async Task<StartImportResponse> StartOneImport(SignleImportSettings settings) => await Process<StartImportResponse>(Parent.StartOneImport(settings)).ConfigureAwait(false);

        public async Task<CheckImportResponse> CheckImport(int? page = null, int? onPage = null) => await Process<CheckImportResponse>(Parent.CheckImport(page, onPage)).ConfigureAwait(false);

        public async Task<Response> StopAllImports() => await Process<Response>(Parent.StopAllImports()).ConfigureAwait(false);

        public async Task<ImportResponse> StartImportFile(ImportSettings settings, string filename) => await Process<ImportResponse>(Parent.StartImportFile(settings, filename)).ConfigureAwait(false);

        public async Task<ImportResponse> StartImportFile(ImportSettings settings, Stream file) => await Process<ImportResponse>(Parent.StartImportFile(settings, file)).ConfigureAwait(false);

    }

}