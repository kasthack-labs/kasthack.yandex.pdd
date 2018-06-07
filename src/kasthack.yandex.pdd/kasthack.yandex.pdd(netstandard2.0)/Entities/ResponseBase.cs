namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Basic api response
    /// </summary>
    public class ResponseBase
    {
        ///<summary>
        ///Status of request execution
        ///</summary>
        public bool Success { get; set; }
        ///<summary>
        ///Error code
        ///</summary>
        public ErrorCode? Error { get; set; }
    }
}