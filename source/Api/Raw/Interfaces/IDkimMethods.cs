using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IDkimMethods
    {
        Task<string> Disable();
        Task<string> Enable();
        Task<string> Status(string secrectkey);
    }
}