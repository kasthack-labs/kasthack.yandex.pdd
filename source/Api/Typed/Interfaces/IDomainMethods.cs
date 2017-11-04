using System.IO;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IDomainMethods
    {
        Task<Response> Delete();
        Task<Response> DeleteLogo();
        Task<DomainDetailsResponse> Details();
        Task<LogoCheckResponse> GetLogo();
        Task<RegisterResponse> Register();
        Task<RegistrationStatusResponse> RegistrationStatus();
        Task<Response> SetCountry(Country country);
        Task<Response> SetLogo(Stream source, string filename);
        Task<Response> SetLogo(string file);
    }
}