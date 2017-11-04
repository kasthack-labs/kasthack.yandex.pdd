using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IDeputyMethods
    {
        Task<string> Add(string login);
        Task<string> Delete(string login);
        Task<string> List();
    }
}