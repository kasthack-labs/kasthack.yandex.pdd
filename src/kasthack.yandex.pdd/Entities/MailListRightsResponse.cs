namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Maillist rights response
    /// </summary>
    public abstract class MailListRightsResponse : SubscriberResponse
    {
        /// <summary>
        /// ubscriber's status.
        /// </summary>
        public bool CanSendOnBehalf { get; set; }
    }
}