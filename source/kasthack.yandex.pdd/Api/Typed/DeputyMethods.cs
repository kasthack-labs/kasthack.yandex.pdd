using System.Threading.Tasks;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd.Methods {
    public class DeputyMethods : MethodsBase<DeputyRawMethods> {
        internal DeputyMethods( DeputyRawMethods parent ) : base( parent ) { }

        public async Task<Response> Delete( string login )
            => await Process<Response>( Parent.Delete( login ) ).ConfigureAwait( false );
        public async Task<Response> Add(string login)
            => await Process<Response>(Parent.Add(login)).ConfigureAwait(false);
        public async Task<Response> List() => await Process<Response>(Parent.List()).ConfigureAwait(false);
    }
}