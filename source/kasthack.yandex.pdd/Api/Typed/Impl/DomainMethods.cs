using System.IO;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{

    internal class DomainMethods : MethodsBase<RawMethods.IDomainMethods>, IDomainMethods
    {

        internal DomainMethods(RawMethods.IDomainMethods parent) : base(parent) { }

        public async Task<RegisterResponse> Register() => await Process<RegisterResponse>(Parent.Register()).ConfigureAwait(false);

        public async Task<RegistrationStatusResponse> RegistrationStatus() => await Process<RegistrationStatusResponse>(Parent.RegistrationStatus()).ConfigureAwait(false);

        public async Task<DomainDetailsResponse> Details() => await Process<DomainDetailsResponse>(Parent.Details()).ConfigureAwait(false);

        public async Task<Response> Delete() => await Process<Response>(Parent.Delete()).ConfigureAwait(false);

        public async Task<SetCountryResponse> SetCountry(Country country) => await Process<SetCountryResponse>(Parent.SetCountry(country)).ConfigureAwait(false);

        public async Task<LogoCheckResponse> GetLogo() => await Process<LogoCheckResponse>(Parent.GetLogo()).ConfigureAwait(false);

        public async Task<Response> DeleteLogo() => await Process<Response>(Parent.DeleteLogo()).ConfigureAwait(false);

        public async Task<Response> SetLogo(string file) => await Process<Response>(Parent.SetLogo(file)).ConfigureAwait(false);

        public async Task<Response> SetLogo(Stream source, string filename) => await Process<Response>(Parent.SetLogo(source, filename)).ConfigureAwait(false);

    }
}