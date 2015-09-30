using System.Threading.Tasks;
using kasthack.yandex.pdd.Domain;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd.Methods {

    public class DomainMethods : MethodsBase<DomainRawMethods> {

        internal DomainMethods( DomainRawMethods parent ) : base( parent ) { }

        public async Task<RegisterResponse> Register() => await Process<RegisterResponse>( Parent.Register() ).ConfigureAwait( false );

        public async Task<RegistrationStatusResponse> RegistrationStatus() => await Process<RegistrationStatusResponse>( Parent.RegistrationStatus() ).ConfigureAwait( false );

        public async Task<DetailsResponse> Details() => await Process<DetailsResponse>( Parent.Details() ).ConfigureAwait( false );

        public async Task<Response> Delete() => await Process<Response>( Parent.Delete() ).ConfigureAwait( false );

        public async Task<Response> SetCountry( Country country ) => await Process<Response>( Parent.SetCountry( country ) ).ConfigureAwait( false );

        public async Task<LogoCheckResponse> GetLogo() => await Process<LogoCheckResponse>( Parent.GetLogo() ).ConfigureAwait( false );

        public async Task<Response> DeleteLogo() => await Process<Response>( Parent.DeleteLogo() ).ConfigureAwait( false );

    }

}