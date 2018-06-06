namespace kasthack.yandex.pdd.Entities
{

    public class AddDnsRecord
    {
        public DnsRecordType Type { get; set; }
        public string AdminMail { get; set; }
        public string Content { get; set; }
        public int? Priority { get; set; }
        public int? Weight { get; set; }
        public int? Port { get; set; }
        public string Target { get; set; }
    }
}