namespace kasthack.yandex.pdd.Import {
    public abstract class ImportResponse : Response {
        public Settings Settings { get; set; }
    }
    
    public class StartResponse : ImportResponse {
        public Item[] ImportList { get; set; }
    }
    
    public class CheckImportResponse : ImportResponse {
        public Info Import { get; set; }
    }

    public class Info {
        public State State { get; set; }
        public int DoneBoxCount { get; set; }
        public int TotalBoxCount { get; set; }
        public int CompleteBoxCount { get; set; }
        public int FailedBoxesCount { get; set; }
        public int FailedBoxesPages { get; set; }
        public int FailedBoxesCurrentPage { get; set; }
        public int ImportedMessageCount { get; set; }
        public int TotalMessageCount { get; set; }
        public int ProgressPercent { get; set; }
        public ItemStatus[] FailedBoxes { get; set; }
    }

    public class ItemBase {
        public string ExternalLogin { get; set; }
        public string ExternalPassword { get; set; }
        public string InternalLogin { get; set; }
        public string InternalPassword { get; set; }
    }

    public class Item : ItemBase {
        public bool Started { get; set; }
    }

    public class ItemStatus : ItemBase {
        public int ImportedMail { get; set; }
        public string LastError { get; set; }
        public string LastErrorCount { get; set; }
    }

    public class Settings {
        public Method Method { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }

    public class SignleImportSettings : Settings {
        public string ExternalLogin { get; set; }
        public string ExternalPassword { get; set; }
        public string InternalLogin { get; set; }
        public string InternalPassword { get; set; }
    }

    public enum State {
        TaskJustCreated,
        Paused,
        InProgress,
        PauseCauseOfError,
        Failed,
        Done,
        Removed
    }

    public enum Method {
        Imap,
        Imap4,
        Pop,
        Pop3
    }
}