using System.Collections.Generic;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{
    internal class MailListMethods : MethodsBase, IMailListMethods
    {
        private const string MaillistUid = "maillist_uid";
        private const string Subscriber = "subscriber";
        private const string SubscriberUid = "subscriber_uid";
        internal MailListMethods(DomainRawContext context) : base(context) { }

        public async Task<string> Add(string maillist) =>
                await Context.ProcessRequestPost("email/ml/add", new Dictionary<string, string> {
                    { nameof( maillist ), maillist }
                }).ConfigureAwait(false);

        public async Task<string> List() => await Context.ProcessRequestGet("email/ml/list", EmptyParams).ConfigureAwait(false);

        public async Task<string> Delete(MailListId maillist) =>
            await Context.ProcessRequestPost("email/ml/del", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { MaillistUid, maillist.Uid.ToNCString() }
                    }).ConfigureAwait(false);

        public async Task<string> Subscribe(MailListId maillist, EmailAccountId subscriber, bool? canSendOnBehalf) =>
                await Context.ProcessRequestPost("email/ml/subscribe", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { MaillistUid, maillist.Uid.ToNCString() },
                        { Subscriber, subscriber.Login },
                        { SubscriberUid, subscriber.Uid.ToNCString() },
                        { nameof( canSendOnBehalf ).ToSnake(), canSendOnBehalf.ToYesNo() }
                    }).ConfigureAwait(false);

        public async Task<string> Subscribers(MailListId maillist) =>
            await Context.ProcessRequestGet("email/ml/subscribers", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { MaillistUid, maillist.Uid.ToNCString() },
                    }).ConfigureAwait(false);

        public async Task<string> Unsubscribe(MailListId maillist, EmailAccountId subscriber) =>
                await Context.ProcessRequestPost("email/ml/unsubscribe", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { MaillistUid, maillist.Uid.ToNCString() },
                        { Subscriber, subscriber.Login },
                        { SubscriberUid, subscriber.Uid.ToNCString() }
                    }).ConfigureAwait(false);

        public async Task<string> GetCanSendOnBehalf(MailListId maillist, EmailAccountId subscriber) =>
                await Context.ProcessRequestGet("email/ml/get_can_send_on_behalf", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { MaillistUid, maillist.Uid.ToNCString() },
                        { Subscriber, subscriber.Login },
                        { SubscriberUid, subscriber.Uid.ToNCString() }
                    }).ConfigureAwait(false);

        public async Task<string> SetCanSendOnBehalf(MailListId maillist, EmailAccountId subscriber, bool canSendOnBehalf) =>
                await Context.ProcessRequestPost("email/ml/set_can_send_on_behalf", new Dictionary<string, string> {
                        { nameof( maillist.Maillist ).ToLowerInvariant(), maillist.Maillist },
                        { MaillistUid, maillist.Uid.ToNCString() },
                        { Subscriber, subscriber.Login },
                        { SubscriberUid, subscriber.Uid.ToNCString() },
                        { nameof( canSendOnBehalf ).ToSnake(), canSendOnBehalf.ToYesNo() }
                    }).ConfigureAwait(false);
    }
}