namespace kasthack.yandex.pdd.Entities
{
    public class EditDnsRecord : AddDnsRecord
    {
        public string Fqdn { get; set; }
        public string Subdomain { get; set; }
        public long RecordId { get; set; }
        public int? Ttl { get; set; }
        public int? Refresh { get; set; }
        public int? Retry { get; set; }
        public int? Expire { get; set; }
        public int? NegCache { get; set; }
    }
}