using System.Threading.Tasks;
using kasthack.yandex.pdd.MailLists;
using kasthack.yandex.pdd.RawMethods;
using AccountId = kasthack.yandex.pdd.Email.AccountId;

namespace kasthack.yandex.pdd.Methods {

    public class MailListMethods : MethodsBase<MailListRawMethods> {

        internal MailListMethods( MailListRawMethods parent ) : base( parent ) { }

        public async Task<AddResponse> Add( string maillist ) => await Process<AddResponse>( Parent.Add( maillist ) ).ConfigureAwait( false );

        public async Task<ListResponse> List() => await Process<ListResponse>( Parent.List() ).ConfigureAwait( false );

        public async Task<DeleteResponse> Delete( MailListId maillist ) => await Process<DeleteResponse>( Parent.Delete( maillist ) ).ConfigureAwait( false );

        public async Task<SubscribeResponse> Subscribe( MailListId maillist, AccountId subscriber, bool? canSendOnBehalf ) => await Process<SubscribeResponse>( Parent.Subscribe( maillist, subscriber, canSendOnBehalf ) ).ConfigureAwait( false );

        public async Task<SubscribersResponse> Subscribers( MailListId maillist ) => await Process<SubscribersResponse>( Parent.Subscribers( maillist ) ).ConfigureAwait( false );

        public async Task<UnsubscribeResponse> Unsubscribe( MailListId maillist, AccountId subscriber ) => await Process<UnsubscribeResponse>( Parent.Unsubscribe( maillist, subscriber ) ).ConfigureAwait( false );

    }

}