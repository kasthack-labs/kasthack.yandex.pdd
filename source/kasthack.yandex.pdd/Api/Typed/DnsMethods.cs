using System.Threading.Tasks;
using kasthack.yandex.pdd.Dns;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd {
    public class DnsMethods : MethodsBase<DnsRawMethods> {
        internal DnsMethods( DnsRawMethods parent ) : base( parent ) { }

        public async Task<RecordResponse> Add( AddRecord record )
            => PddApi.Serializer.Deserialize<RecordResponse>( ( await Parent.Add( record ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<RecordsResponse> List()
            => PddApi.Serializer.Deserialize<RecordsResponse>( ( await Parent.List().ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<RecordsResponse> Edit( Record record )
            => PddApi.Serializer.Deserialize<RecordsResponse>( ( await Parent.Edit( record ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<DeleteRespone> Delete( long recordId )
            => PddApi.Serializer.Deserialize<DeleteRespone>( ( await Parent.Delete( recordId ).ConfigureAwait( false ) ).ToJSONReader() );
    }
}