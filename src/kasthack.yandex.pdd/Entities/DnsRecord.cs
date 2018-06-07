namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Created DNS record info
    /// </summary>
    public class DnsRecord : AddDnsRecord
    {
        /// <summary>
        /// Name of the domain.
        /// </summary>
        public string Domain { get; set; }
    }
}