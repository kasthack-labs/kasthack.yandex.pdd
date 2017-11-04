using System.Threading.Tasks;
using kasthack.yandex.pdd.RawMethods;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{

    internal class MailListMethods : MethodsBase<RawMethods.IMailListMethods>, IMailListMethods
    {

        internal MailListMethods(RawMethods.IMailListMethods parent) : base(parent) { }

        public async Task<AddMailListResponse> Add(string maillist) => await Process<AddMailListResponse>(Parent.Add(maillist)).ConfigureAwait(false);

        public async Task<ListMailListResponse> List() => await Process<ListMailListResponse>(Parent.List()).ConfigureAwait(false);

        public async Task<DeleteMailListResponse> Delete(MailListId maillist) => await Process<DeleteMailListResponse>(Parent.Delete(maillist)).ConfigureAwait(false);

        public async Task<SubscribeMailListResponse> Subscribe(MailListId maillist, EmailAccountId subscriber, bool? canSendOnBehalf) => await Process<SubscribeMailListResponse>(Parent.Subscribe(maillist, subscriber, canSendOnBehalf)).ConfigureAwait(false);

        public async Task<SubscribersMailListResponse> Subscribers(MailListId maillist) => await Process<SubscribersMailListResponse>(Parent.Subscribers(maillist)).ConfigureAwait(false);

        public async Task<UnsubscribeMailListResponse> Unsubscribe(MailListId maillist, EmailAccountId subscriber) => await Process<UnsubscribeMailListResponse>(Parent.Unsubscribe(maillist, subscriber)).ConfigureAwait(false);

    }

}