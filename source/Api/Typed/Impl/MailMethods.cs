using kasthack.yandex.pdd.Entities;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.Methods
{

    internal class MailMethods : MethodsBase<RawMethods.IMailMethods>, IMailMethods
    {

        internal MailMethods(RawMethods.IMailMethods parent) : base(parent) { }

        public async Task<AddEmailResponse> Add(string login, string password) => await Process<AddEmailResponse>(Parent.Add(login, password)).ConfigureAwait(false);

        public async Task<DeleteEmailResponse> Delete(EmailAccountId id) => await Process<DeleteEmailResponse>(Parent.Delete(id)).ConfigureAwait(false);

        public async Task<EmailCountersResponse> Counters(EmailAccountId id) => await Process<EmailCountersResponse>(Parent.Counters(id)).ConfigureAwait(false);

        public async Task<ListEmailResponse> List(int? page = null, int? onPage = null) => await Process<ListEmailResponse>(Parent.List(page, onPage)).ConfigureAwait(false);

        public async Task<EditEmailResponse> Edit(EmailAccountBase account) => await Process<EditEmailResponse>(Parent.Edit(account)).ConfigureAwait(false);

    }

}