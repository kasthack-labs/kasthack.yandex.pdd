using System.Collections.Generic;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd.RawMethods
{
    internal class DomainsMethods : MethodsBase, IDomainsMethods
    {

        internal DomainsMethods(DomainRawContext context) : base(context) { }

        public async Task<string> GetDomains(int? page, int? onPage) => await Context.ProcessRequestGet("domain/domains", new Dictionary<string, string> {
            {nameof(page), page.ToNCString()},
            { nameof( onPage ).ToSnake(), onPage.ToNCString()}
        }).ConfigureAwait(false);

    }

}