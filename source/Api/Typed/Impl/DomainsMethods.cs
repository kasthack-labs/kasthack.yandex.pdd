using kasthack.yandex.pdd.Entities;
using kasthack.yandex.pdd.RawMethods;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.Methods
{
    public class DomainsMethods : MethodsBase<RawMethods.IDomainsMethods>, IDomainsMethods
    {
        internal DomainsMethods(RawMethods.IDomainsMethods parent) : base(parent) { }
        public async Task<DomainsResponse> GetDomains(int? page = null, int? onPage = null) => await Process<DomainsResponse>(Parent.GetDomains(page, onPage)).ConfigureAwait(false);
    }
}
