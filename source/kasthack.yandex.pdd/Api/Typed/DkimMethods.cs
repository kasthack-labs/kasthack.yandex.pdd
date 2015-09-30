using System.Threading.Tasks;
using kasthack.yandex.pdd.Dkim;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd.Methods {

    public class DkimMethods : MethodsBase<DkimRawMethods> {

        internal DkimMethods( DkimRawMethods parent ) : base( parent ) { }

        public async Task<StatusResponse> Status( string secretkey ) => await Process<StatusResponse>( Parent.Status( secretkey ) ).ConfigureAwait( false );

        public async Task<StatusResponse> Enable() => await Process<StatusResponse>( Parent.Enable() ).ConfigureAwait( false );

        public async Task<StatusResponse> Disable() => await Process<StatusResponse>( Parent.Disable() ).ConfigureAwait( false );

    }

}