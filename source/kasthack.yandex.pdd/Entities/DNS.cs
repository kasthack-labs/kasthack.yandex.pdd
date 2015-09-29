namespace kasthack.yandex.pdd.Dns {
    public class RecordRespone : Response {
        public Record Record { get; set; }
    }

    public class AddRecord {
        public Type Type { get; set; }
        public string AdminMail { get; set; }
        public string Content { get; set; }
        public int? Priority { get; set; }
        public int? Weight { get; set; }
        public int? Port { get; set; }
        public string Target { get; set; }
    }

    public class EditRecord : AddRecord {
        public string Fqdn { get; set; }
        public string Subdomain { get; set; }
        public long RecordId { get; set; }
        public int? Ttl { get; set; }
        public int? Refresh { get; set; }
        public int? Retry { get; set; }
        public int? Expire { get; set; }
        public int? NegCache { get; set; }
    }

    public class Record : EditRecord {
        public string Domain { get; set; }
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