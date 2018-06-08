namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Maillist UID response
    /// </summary>
    public abstract class MaillistUidResponse : MaillistResponse
    {
        /// <summary>
        /// Maillist identifier
        /// </summary>
        public long Uid { get; set; }
    }
}