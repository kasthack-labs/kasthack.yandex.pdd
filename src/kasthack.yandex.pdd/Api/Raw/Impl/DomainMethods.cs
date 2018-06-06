using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{

    internal class DomainMethods : MethodsBase, IDomainMethods
    {

        internal DomainMethods(DomainRawContext context) : base(context) { }

        public async Task<string> Register() => await Context.ProcessRequestPost("domain/register", EmptyParams).ConfigureAwait(false);

        public async Task<string> RegistrationStatus() => await Context.ProcessRequestGet("domain/registration_status", EmptyParams).ConfigureAwait(false);

        public async Task<string> Details() => await Context.ProcessRequestGet("domain/details", EmptyParams).ConfigureAwait(false);

        public async Task<string> Delete() => await Context.ProcessRequestPost("domain/delete", EmptyParams).ConfigureAwait(false);

        public async Task<string> SetCountry(Country country)
            => await Context.ProcessRequestPost("domain/set_country", new Dictionary<string, string> { { nameof(country), country.ToNCString() } }).ConfigureAwait(false);

        public async Task<string> GetLogo() => await Context.ProcessRequestGet("domain/logo/check", EmptyParams).ConfigureAwait(false);

        public async Task<string> DeleteLogo() => await Context.ProcessRequestPost("domain/logo/del", EmptyParams).ConfigureAwait(false);

        public async Task<string> SetLogo(string file)
        {
            using (var stream = File.OpenRead(file))
                return await SetLogo(stream, file).ConfigureAwait(false);
        }

        public async Task<string> SetLogo(Stream source, string filename = null) =>
            await Context.ProcessRequestPostForm("domain/logo/set", new MultipartFormDataContent { MiscTools.StreamContent(filename ?? "file.png", source) }).ConfigureAwait(false);

    }

}