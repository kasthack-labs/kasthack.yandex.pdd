namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Subscriber base response
    /// </summary>
    public abstract class SubscriberResponse : MaillistUidResponse
    {
        /// <summary>
        /// Subscriber address
        /// </summary>
        public string Subscriber { get; set; }
    }
}