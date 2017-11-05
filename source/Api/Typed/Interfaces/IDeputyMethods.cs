using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IDeputyMethods
    {
        Task<Response> Add(string login);
        Task<Response> Delete(string login);
        Task<ListDeputiesResponse> List();
    }
}