namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// DNS record creation response
    /// </summary>
    public class DnsRecordResponse : Response
    {
        /// <summary>
        /// Information about the DNS record.
        /// </summary>
        public DnsRecord Record { get; set; }
    }
}