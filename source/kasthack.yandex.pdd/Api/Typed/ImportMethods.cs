using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Import;

namespace kasthack.yandex.pdd {
    public class ImportMethods : MethodsBase<ImportRawMethods> {
        internal ImportMethods( ImportRawMethods parent ) : base( parent ) { }

        public async Task<ImportResponse> CheckSettings( Settings settings ) =>
                PddApi.Serializer.Deserialize<ImportResponse>( ( await Parent.CheckSettings( settings ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<StartOneResponse> StartOneImport( SignleImportSettings settings ) =>
                PddApi.Serializer.Deserialize<StartOneResponse>( ( await Parent.StartOneImport( settings ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<CheckImportResponse> CheckImport( int? page = null, int? onPage = null ) =>
                PddApi.Serializer.Deserialize<CheckImportResponse>( ( await Parent.CheckImport( page, onPage ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<Response> StopAllImports() =>
            PddApi.Serializer.Deserialize<Response>( ( await Parent.StopAllImports().ConfigureAwait( false ) ).ToJSONReader() );
    }
}