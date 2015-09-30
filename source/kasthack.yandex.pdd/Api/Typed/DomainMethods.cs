using System.Threading.Tasks;
using kasthack.yandex.pdd.Domain;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd {
    public class DomainMethods : MethodsBase<DomainRawMethods> {
        internal DomainMethods( DomainRawMethods parent ) : base( parent ) { }

        public async Task<RegisterResponse> Register() =>
            PddApi.Serializer.Deserialize<RegisterResponse>( ( await Parent.Register().ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<RegistrationStatusResponse> RegistrationStatus() =>
                PddApi.Serializer.Deserialize<RegistrationStatusResponse>( ( await Parent.RegistrationStatus().ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<DetailsResponse> Details() =>
            PddApi.Serializer.Deserialize<DetailsResponse>( ( await Parent.Details().ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<Response> Delete() =>
            PddApi.Serializer.Deserialize<Response>( ( await Parent.Delete().ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<Response> SetCountry( Country country ) =>
            PddApi.Serializer.Deserialize<Response>( ( await Parent.SetCountry( country ).ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<LogoCheckResponse> GetLogo() =>
            PddApi.Serializer.Deserialize<LogoCheckResponse>( ( await Parent.GetLogo().ConfigureAwait( false ) ).ToJSONReader() );

        public async Task<Response> DeleteLogo() =>
            PddApi.Serializer.Deserialize<Response>( ( await Parent.DeleteLogo().ConfigureAwait( false ) ).ToJSONReader() );
    }
}