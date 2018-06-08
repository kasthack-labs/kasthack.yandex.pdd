namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Full mailing list
    /// </summary>
    public class MailList : MailListId
    {
        /// <summary>
        /// Number of subscribers to the mailing list.
        /// </summary>
        public int Cnt { get; set; }
    }
}