using kasthack.yandex.pdd.Entities;
using System.IO;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IDomainMethods
    {
        Task<string> Delete();
        Task<string> DeleteLogo();
        Task<string> Details();
        Task<string> GetLogo();
        Task<string> Register();
        Task<string> RegistrationStatus();
        Task<string> SetCountry(Country country);
        Task<string> SetLogo(Stream source, string filename = null);
        Task<string> SetLogo(string file);
    }
}