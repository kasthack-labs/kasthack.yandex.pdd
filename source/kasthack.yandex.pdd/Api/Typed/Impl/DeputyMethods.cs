using kasthack.yandex.pdd.Entities;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.Methods
{
    internal class DeputyMethods : MethodsBase<RawMethods.IDeputyMethods>, IDeputyMethods
    {
        internal DeputyMethods(RawMethods.IDeputyMethods parent) : base(parent) { }

        public async Task<Response> Delete(string login)
            => await Process<Response>(Parent.Delete(login)).ConfigureAwait(false);
        public async Task<Response> Add(string login)
            => await Process<Response>(Parent.Add(login)).ConfigureAwait(false);
        public async Task<ListDeputiesResponse> List() => await Process<ListDeputiesResponse>(Parent.List()).ConfigureAwait(false);
    }
}