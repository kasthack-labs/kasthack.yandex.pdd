using System.Threading.Tasks;
using kasthack.yandex.pdd.Email;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd.Methods {

    public class MailMethods : MethodsBase<MailRawMethods> {

        internal MailMethods( MailRawMethods parent ) : base( parent ) { }

        public async Task<AddResponse> Add( string login, string password ) => await Process<AddResponse>( Parent.Add( login, password ) ).ConfigureAwait( false );

        public async Task<DeleteResponse> Delete( AccountId id ) => await Process<DeleteResponse>( Parent.Delete( id ) ).ConfigureAwait( false );

        public async Task<CountersResponse> Counters( AccountId id ) => await Process<CountersResponse>( Parent.Counters( id ) ).ConfigureAwait( false );

        public async Task<ListResponse> List( int? page = null, int? onPage = null ) => await Process<ListResponse>( Parent.List( page, onPage ) ).ConfigureAwait( false );

        public async Task<EditResponse> Edit( AccountBase account ) => await Process<EditResponse>( Parent.Edit( account ) ).ConfigureAwait( false );

    }

}