using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd.Methods
{

    internal class DnsMethods : MethodsBase<RawMethods.IDnsMethods>, IDnsMethods
    {

        internal DnsMethods(RawMethods.IDnsMethods parent) : base(parent) { }

        public async Task<DnsRecordResponse> Add(AddDnsRecord record) => await Process<DnsRecordResponse>(Parent.Add(record)).ConfigureAwait(false);

        public async Task<DnsRecordsResponse> List() => await Process<DnsRecordsResponse>(Parent.List()).ConfigureAwait(false);

        public async Task<DnsRecordsResponse> Edit(DnsRecord record) => await Process<DnsRecordsResponse>(Parent.Edit(record)).ConfigureAwait(false);

        public async Task<DeleteDnsRespone> Delete(long recordId) => await Process<DeleteDnsRespone>(Parent.Delete(recordId)).ConfigureAwait(false);

    }

}