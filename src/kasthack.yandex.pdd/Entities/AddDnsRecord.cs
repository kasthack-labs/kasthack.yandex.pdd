namespace kasthack.yandex.pdd.Entities
{
    ///<summary>
    ///DNS record creation parameters
    ///</summary>
    public class AddDnsRecord : EditDnsRecord
    {
        ///<summary>
        ///Type of DNS record.
        ///</summary>
        public DnsRecordType Type { get; set; }
        ///<summary>
        ///The email address of the domain administrator.This parameter is required only for SOA records.
        ///</summary>
        public string AdminMail { get; set; }
        ///<summary>
        /// Contents of the DNS record.
        ///</summary>
        public string Content { get; set; }
        ///<summary>
        ///Priority of the DNS record (the smaller the value, the higher its priority). 
        ///This parameter is required only for SRV and MX records.
        ///</summary>
        public int? Priority { get; set; }
        ///<summary>
        ///The weight of the SRV record in relation to other SRV records for the same domain and with the same priority.
        ///This parameter is required only for SRV records.
        ///</summary>
        public int? Weight { get; set; }
        ///<summary>
        ///The TCP or UDP port of the host where the service resides. The service may be, for example, jabber.
        ///This parameter is required only for SRV records.
        ///</summary>
        public int? Port { get; set; }
        ///<summary>
        ///The canonical name of the host providing the service.
        ///This parameter is required only for SRV records.
        ///</summary>
        public string Target { get; set; }
    }
}