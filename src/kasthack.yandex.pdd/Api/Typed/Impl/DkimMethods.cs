using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{

    internal class DkimMethods : MethodsBase<RawMethods.IDkimMethods>, IDkimMethods
    {

        internal DkimMethods(RawMethods.IDkimMethods parent) : base(parent) { }

        public async Task<DkimStatusResponse> Status(bool? secretkey) => await Process<DkimStatusResponse>(Parent.Status(secretkey)).ConfigureAwait(false);

        public async Task<DkimStatusResponse> Enable() => await Process<DkimStatusResponse>(Parent.Enable()).ConfigureAwait(false);

        public async Task<DkimStatusResponse> Disable() => await Process<DkimStatusResponse>(Parent.Disable()).ConfigureAwait(false);

    }

}