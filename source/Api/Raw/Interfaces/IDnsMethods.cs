using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.RawMethods
{
    public interface IDnsMethods
    {
        Task<string> Add(AddDnsRecord record);
        Task<string> Delete(long recordId);
        Task<string> Edit(DnsRecord record);
        Task<string> List();
    }
}