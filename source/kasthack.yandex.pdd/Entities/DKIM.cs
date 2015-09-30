namespace kasthack.yandex.pdd.Dkim {
    public class StatusResponse : Response {
        public DKIM Dkim { get; set; }
    }

    public class EnableResponse : Response {
        public DKIMBase Dkim { get; set; }
    }

    public class DKIMBase {
        public bool Enabled { get; set; }
        public string Txtrecord { get; set; }
    }

    public class DKIM : DKIMBase {
        public bool Nsready { get; set; }
        public bool Mailready { get; set; }
        public string Secretkey { get; set; }
    }
}