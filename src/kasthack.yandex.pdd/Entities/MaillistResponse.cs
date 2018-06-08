namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Basic maillist response
    /// </summary>
    public abstract class MaillistResponse : Response
    {
        /// <summary>
        /// Subscribed maillist name
        /// </summary>
        public string Maillist { get; set; }
    }
}