using System.Threading.Tasks;
using kasthack.yandex.pdd.Dkim;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd {
    public class DkimMethods : MethodsBase<DkimRawMethods> {
        internal DkimMethods( DkimRawMethods parent ) : base( parent ) { }

        public async Task<StatusResponse> Status( string secretkey ) =>
            PddApi.Serializer.Deserialize<StatusResponse>( ( await Parent.Status( secretkey ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<StatusResponse> Enable() =>
            PddApi.Serializer.Deserialize<StatusResponse>( ( await Parent.Enable().ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<StatusResponse> Disable() =>
            PddApi.Serializer.Deserialize<StatusResponse>( ( await Parent.Disable().ConfigureAwait( false ) ).ToJSONReader() );
    }
}