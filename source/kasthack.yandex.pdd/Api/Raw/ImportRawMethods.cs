using System.Collections.Generic;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Import;

namespace kasthack.yandex.pdd.RawMethods {
    public class ImportRawMethods : RawMethodsBase {
        internal ImportRawMethods( DomainRawContext context ) : base( context ) { }

        public async Task<string> CheckSettings( Settings settings ) =>
                await Context.ProcessRequestGet( "import/check_settings", new Dictionary<string, string> {
                        { nameof( settings.Method ).ToLowerInvariant(), settings.Method.ToNCString() },
                        { nameof( settings.Port ).ToLowerInvariant(), settings.Port.ToNCString() },
                        { nameof( settings.Ssl ).ToLowerInvariant(), settings.Ssl.ToYesNo() },
                        { nameof( settings.Server ).ToLowerInvariant(), settings.Server },
                    } ).ConfigureAwait( false );

        public async Task<string> StartOneImport( SignleImportSettings settings ) =>
                await Context.ProcessRequestPost( "import/start_one_import",
                    new Dictionary<string, string> {
                        { nameof( settings.Method ).ToLowerInvariant(), settings.Method.ToNCString() },
                        { nameof( settings.Port ).ToLowerInvariant(), settings.Port.ToNCString() },
                        { nameof( settings.Ssl ).ToLowerInvariant(), settings.Ssl.ToYesNo() },
                        { nameof( settings.Server ).ToLowerInvariant(), settings.Server },
                        { "ext-login", settings.ExternalLogin },
                        { "ext-passwd", settings.ExternalPassword },
                        { "int-login", settings.InternalLogin },
                        { "int-passwd", settings.InternalPassword },
                    } ).ConfigureAwait( false );

        public async Task<string> CheckImport( int? page = null, int? onPage = null ) =>
                await Context.ProcessRequestGet( "import/check_imports", new Dictionary<string, string> {
                        { nameof( page ), page.ToNCString() },
                        { nameof( onPage ).ToSnake(), onPage.ToNCString() }
                    } ).ConfigureAwait( false );

        public async Task<string> StopAllImports()
            => await Context.ProcessRequestPost( "import/stop_all_imports", EmptyParams ).ConfigureAwait( false );
    }
}