using System;

namespace kasthack.yandex.pdd {
    public interface IResponse {
        string Domain { get; set; }
        bool Success { get; set; }
        ErrorCode Error { get; set; }
    }

    public abstract class Response : IResponse {
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

    public class YaException : Exception {}
}