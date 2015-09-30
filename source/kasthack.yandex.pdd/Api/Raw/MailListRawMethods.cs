using System.Collections.Generic;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Email;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.MailLists;

namespace kasthack.yandex.pdd {
    public class MailListRawMethods : RawMethodsBase {
        internal MailListRawMethods( DomainRawContext context ) : base( context ) { }

        public async Task<string> Add( string maillist ) =>
                await Context.ProcessRequestPost( "email/ml/add", new Dictionary<string, string> {
                    { nameof( maillist ), maillist }
                } ).ConfigureAwait( false );

        public async Task<string> List() => await Context.ProcessRequestGet( "email/ml/list", EmptyParams ).ConfigureAwait( false );

        public async Task<string> Delete( MailListId maillist ) =>
            await Context.ProcessRequestPost( "email/ml/del", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { "maillist_uid", maillist.Uid.ToNCString() }
                    } ).ConfigureAwait( false );

        public async Task<string> Subscribe( MailListId maillist, AccountId subscriber, bool? canSendOnBehalf ) =>
                await Context.ProcessRequestPost( "email/ml/subscribe", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { "maillist_uid", maillist.Uid.ToNCString() },
                        { "subscriber", subscriber.Login },
                        { "subscriber_uid", subscriber.Uid.ToNCString() },
                        { nameof( canSendOnBehalf ).ToSnake(), canSendOnBehalf.ToYesNo() }
                    } ).ConfigureAwait( false );

        public async Task<string> Subscribers( MailListId maillist ) =>
            await Context.ProcessRequestGet( "email/ml/subscribers", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { "maillist_uid", maillist.Uid.ToNCString() },
                    } ).ConfigureAwait( false );

        public async Task<string> Unsubscribe( MailListId maillist, AccountId subscriber ) =>
                await Context.ProcessRequestPost( "email/ml/unsubscribe", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { "maillist_uid", maillist.Uid.ToNCString() },
                        { "subscriber", subscriber.Login },
                        { "subscriber_uid", subscriber.Uid.ToNCString() }
                    } ).ConfigureAwait( false );

        public async Task<string> GetCanSendOnBehalf( MailListId maillist, AccountId subscriber ) =>
                await Context.ProcessRequestGet( "email/ml/get_can_send_on_behalf", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { "maillist_uid", maillist.Uid.ToNCString() },
                        { "subscriber", subscriber.Login },
                        { "subscriber_uid", subscriber.Uid.ToNCString() }
                    } ).ConfigureAwait( false );

        public async Task<string> SetCanSendOnBehalf( MailListId maillist, AccountId subscriber, bool canSendOnBehalf ) =>
                await Context.ProcessRequestPost( "email/ml/set_can_send_on_behalf", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { "maillist_uid", maillist.Uid.ToNCString() },
                        { "subscriber", subscriber.Login },
                        { "subscriber_uid", subscriber.Uid.ToNCString() },
                        { nameof( canSendOnBehalf ).ToSnake(), canSendOnBehalf.ToYesNo() }
                    } ).ConfigureAwait( false );
    }
}