using System.Threading.Tasks;
using kasthack.yandex.pdd.Import;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd.Methods {

    public class ImportMethods : MethodsBase<ImportRawMethods> {

        internal ImportMethods( ImportRawMethods parent ) : base( parent ) { }

        public async Task<ImportResponse> CheckSettings( Settings settings ) => await Process<ImportResponse>( Parent.CheckSettings( settings ) ).ConfigureAwait( false );

        public async Task<StartOneResponse> StartOneImport( SignleImportSettings settings ) => await Process<StartOneResponse>( Parent.StartOneImport( settings ) ).ConfigureAwait( false );

        public async Task<CheckImportResponse> CheckImport( int? page = null, int? onPage = null ) => await Process<CheckImportResponse>( Parent.CheckImport( page, onPage ) ).ConfigureAwait( false );

        public async Task<Response> StopAllImports() => await Process<Response>( Parent.StopAllImports() ).ConfigureAwait( false );

    }

}