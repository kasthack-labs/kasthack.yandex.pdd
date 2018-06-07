namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Updated DNS record response
    /// </summary>
    public class EditDnsRecord
    {
        /// <summary>
        /// Absolute domain name (FQDN).
        /// </summary>
        public string Fqdn { get; set; }
        /// <summary>
        /// Subdomain name. For example, “my.domain.com” is the name of a subdomain of the “domain.com” domain. You can use “my” in place of “my.domain.com”.
        /// </summary>
        public string Subdomain { get; set; }
        public long RecordId { get; set; }
        public int? Ttl { get; set; }
        public int? Refresh { get; set; }
        public int? Retry { get; set; }
        public int? Expire { get; set; }
        public int? NegCache { get; set; }
    }
}