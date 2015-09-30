using System;

namespace kasthack.yandex.pdd {

    public abstract class Response {
        public string Domain { get; set; }
        public bool Success { get; set; }
        public ErrorCode Error { get; set; }
    }

    public enum ErrorCode {
        Unknown,
        NoToken,
        BadDomain,
        Prohibited,
        BadToken,
        NoAuth,
        NotAllowed,
        Blocked,
        Occupied,
        DomainLimitReached,
        NoReply
    }

    public abstract class PageableResponse : Response {
        public int Page { get; set; }
        public int OnPage { get; set; }
        public int Total { get; set; }
        public int Found { get; set; }
    }
}