using System.Threading.Tasks;
using kasthack.yandex.pdd.Dns;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd.Methods {

    public class DnsMethods : MethodsBase<DnsRawMethods> {

        internal DnsMethods( DnsRawMethods parent ) : base( parent ) { }

        public async Task<RecordResponse> Add( AddRecord record ) => await Process<RecordResponse>( Parent.Add( record ) ).ConfigureAwait( false );

        public async Task<RecordsResponse> List() => await Process<RecordsResponse>( Parent.List() ).ConfigureAwait( false );

        public async Task<RecordsResponse> Edit( Record record ) => await Process<RecordsResponse>( Parent.Edit( record ) ).ConfigureAwait( false );

        public async Task<DeleteRespone> Delete( long recordId ) => await Process<DeleteRespone>( Parent.Delete( recordId ) ).ConfigureAwait( false );

    }

}