using kasthack.yandex.pdd.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    internal class DkimMethods : MethodsBase, IDkimMethods
    {
        internal DkimMethods(DomainRawContext context) : base(context) { }

        public async Task<string> Status(bool? secrectkey) =>
                await Context.ProcessRequestGet("dkim/status", new Dictionary<string, string> {
                    { nameof( secrectkey ), secrectkey.ToYesNo() },
                }).ConfigureAwait(false);

        public async Task<string> Enable() => await Context.ProcessRequestPost("dkim/enable", EmptyParams).ConfigureAwait(false);

        public async Task<string> Disable() => await Context.ProcessRequestPost("dkim/disable", EmptyParams).ConfigureAwait(false);
    }
}