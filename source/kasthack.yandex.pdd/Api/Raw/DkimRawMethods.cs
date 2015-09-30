using System.Collections.Generic;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods {
    public class DkimRawMethods : RawMethodsBase {
        internal DkimRawMethods( DomainRawContext context ) : base( context ) { }

        public async Task<string> Status( string secrectkey ) =>
                await Context.ProcessRequestGet( "dkim/status", new Dictionary<string, string> {
                    { nameof( secrectkey ), secrectkey },
                } ) .ConfigureAwait( false );

        public async Task<string> Enable() => await Context.ProcessRequestPost( "dkim/enable", EmptyParams ).ConfigureAwait( false );

        public async Task<string> Disable() => await Context.ProcessRequestPost( "dkim/disable", EmptyParams ).ConfigureAwait( false );
    }
}