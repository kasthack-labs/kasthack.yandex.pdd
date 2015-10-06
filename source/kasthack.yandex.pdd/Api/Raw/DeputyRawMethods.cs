using System.Collections.Generic;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods {
    public class DeputyRawMethods : RawMethodsBase {
        internal DeputyRawMethods( DomainRawContext context ) : base( context ) { }

        public async Task<string> Delete(string login) =>
                await Context.ProcessRequestPost(
                    "deputy/delete",
                    new Dictionary<string, string> {
                        { nameof( login ).ToLowerInvariant(), login },
                    }).ConfigureAwait(false);

        public async Task<string> Add(string login) =>
                await Context.ProcessRequestPost(
                    "deputy/add",
                    new Dictionary<string, string> {
                        { nameof( login ).ToLowerInvariant(), login },
                    }).ConfigureAwait(false);
        public async Task<string> List() => await Context.ProcessRequestPost( "deputy/list", EmptyParams).ConfigureAwait(false);
    }
}