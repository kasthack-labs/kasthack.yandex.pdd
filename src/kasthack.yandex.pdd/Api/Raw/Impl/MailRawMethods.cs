using System.Collections.Generic;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{
    internal class MailMethods : MethodsBase, IMailMethods
    {
        internal MailMethods(DomainRawContext context) : base(context) { }

        public async Task<string> Add(string login, string password) =>
                await Context.ProcessRequestPost("email/add",
                    new Dictionary<string, string> {
                        { nameof( login ), login },
                        { nameof( password ), password }
                    }).ConfigureAwait(false);

        public async Task<string> List(int? page = null, int? onPage = null) =>
                await Context.ProcessRequestGet("email/list", new Dictionary<string, string> {
                        { nameof( page ), page.ToNCString() },
                        { nameof( onPage ).ToSnake(), onPage.ToNCString() }
                    }).ConfigureAwait(false);

        public async Task<string> Edit(EmailAccountBase account) =>
                await Context.ProcessRequestPost("email/del", new Dictionary<string, string> {
                        { nameof( account.Enabled ).ToLowerInvariant(), account.Enabled.ToYesNo() },
                        { nameof( account.Uid ).ToLowerInvariant(), account.Uid.ToNCString() },
                        { nameof( account.Login ).ToLowerInvariant(), account.Login },
                        { nameof( account.Fname ).ToLowerInvariant(), account.Fname },
                        { nameof( account.Hinta ).ToLowerInvariant(), account.Hinta },
                        { nameof( account.Hintq ).ToLowerInvariant(), account.Hintq },
                        { nameof( account.Iname ).ToLowerInvariant(), account.Iname },
                        { nameof( account.BirthDate ).ToSnake(), account.BirthDate?.ToString( "YYYY-MM-DD" ) },
                        { nameof( account.Password ).ToLowerInvariant(), account.Password },
                    }).ConfigureAwait(false);

        public async Task<string> Delete(EmailAccountId id) =>
                await Context.ProcessRequestPost(
                    "email/del",
                    new Dictionary<string, string> {
                        { nameof( id.Uid ).ToLowerInvariant(), id.Uid.ToNCString() },
                        { nameof( id.Login ).ToLowerInvariant(), id.Login }
                    }).ConfigureAwait(false);

        public async Task<string> Counters(EmailAccountId id) =>
                await Context.ProcessRequestGet(
                    "email/counters",
                    new Dictionary<string, string> {
                        { nameof( id.Uid ).ToLowerInvariant(), id.Uid.ToNCString() },
                        { nameof( id.Login ).ToLowerInvariant(), id.Login }
                    }).ConfigureAwait(false);
    }
}