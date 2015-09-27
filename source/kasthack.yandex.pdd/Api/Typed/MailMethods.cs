using System.Threading.Tasks;
using kasthack.yandex.pdd.Email;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd.Api {
    public class MailMethods {
        private readonly MailRawMethods _parent;

        internal MailMethods( MailRawMethods parent) { _parent = parent; }

        public async Task<AddResponse> Add( string login, string password )
            =>
                PddApi.Serializer.Deserialize<AddResponse>(
                    ( await _parent.Add( login, password ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<DelResponse> Del( AccountId id )
            => PddApi.Serializer.Deserialize<DelResponse>( ( await _parent.Del( id ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<CountersResponse> Counters( AccountId id )
            =>
                PddApi.Serializer.Deserialize<CountersResponse>(
                    ( await _parent.Counters( id ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<ListResponse> List( int? page = null, int? on_page = null )
            =>
                PddApi.Serializer.Deserialize<ListResponse>(
                    ( await _parent.List( page, on_page ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<EditResponse> Edit( AccountBase account )
            =>
                PddApi.Serializer.Deserialize<EditResponse>(
                    ( await _parent.Edit( account ).ConfigureAwait( false ) ).ToJSONReader() );
    }
}