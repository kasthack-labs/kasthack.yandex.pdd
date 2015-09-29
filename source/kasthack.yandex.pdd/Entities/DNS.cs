namespace kasthack.yandex.pdd.Dns {
    public class RecordRespone : Response {
        public Record Record { get; set; }
    }

    public class Record {
        public Type Type { get; set; }
        public string Domain { get; set; }
        public string Fqdn { get; set; }
        public int Ttl { get; set; }
        public string Subdomain { get; set; }
        public string Content { get; set; }
        public int? Priority { get; set; }
        public string AdminMail { get; set; }
        public string Weight { get; set; }
        public string Port { get; set; }
        public string Target { get; set; }
        public int? Refresh { get; set; }
        public int? Retry { get; set; }
        public int? Expire { get; set; }
        public int? NegCache { get; set; }
    }

    public class YaRecord : Record {
        public long RecordId { get; set; }
    }

    public enum Type {
        SRV,
        TXT,
        NS,
        MX,
        SOA,
        A,
        AAAA,
        CNAME
    }
}