using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{
    public interface IDnsMethods
    {
        Task<DnsRecordResponse> Add(AddDnsRecord record);
        Task<DeleteDnsRespone> Delete(long recordId);
        Task<DnsRecordsResponse> Edit(DnsRecord record);
        Task<DnsRecordsResponse> List();
    }
}