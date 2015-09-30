using System.Threading.Tasks;
using kasthack.yandex.pdd.Email;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd {
    public class MailMethods : MethodsBase<MailRawMethods> {
        internal MailMethods( MailRawMethods parent ) : base( parent ) { }

        public async Task<AddResponse> Add( string login, string password ) =>
            PddApi.Serializer.Deserialize<AddResponse>( ( await Parent.Add( login, password ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<DelResponse> Delete( AccountId id ) =>
            PddApi.Serializer.Deserialize<DelResponse>( ( await Parent.Delete( id ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<CountersResponse> Counters( AccountId id ) =>
            PddApi.Serializer.Deserialize<CountersResponse>( ( await Parent.Counters( id ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<ListResponse> List( int? page = null, int? onPage = null ) =>
            PddApi.Serializer.Deserialize<ListResponse>( ( await Parent.List( page, onPage ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<EditResponse> Edit( AccountBase account ) =>
            PddApi.Serializer.Deserialize<EditResponse>( ( await Parent.Edit( account ).ConfigureAwait( false ) ).ToJSONReader() );
    }
}