using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IDkimMethods
    {
        Task<DkimStatusResponse> Disable();
        Task<DkimStatusResponse> Enable();
        Task<DkimStatusResponse> Status(string secretkey);
    }
}