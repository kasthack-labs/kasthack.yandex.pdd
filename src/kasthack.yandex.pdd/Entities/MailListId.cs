namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Mailing list identifier
    /// </summary>
    public class MailListId
    {
        /// <summary>
        /// Address
        /// </summary>
        public string Maillist { get; set; }
        /// <summary>
        /// Unique identifier
        /// </summary>
        public long? Uid { get; set; }
        /// <summary>
        /// string -> identifier
        /// </summary>
        public static implicit operator MailListId(string maillist) => new MailListId { Maillist = maillist };
        /// <summary>
        /// long -> identifier
        /// </summary>
        public static implicit operator MailListId(long uid) => new MailListId { Uid = uid };
    }
}