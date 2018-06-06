namespace kasthack.yandex.pdd.Entities
{
    public class MailListId
    {
        public string Maillist { get; set; }
        public long? Uid { get; set; }
        public static implicit operator MailListId(string maillist) => new MailListId { Maillist = maillist };
        public static implicit operator MailListId(long uid) => new MailListId { Uid = uid };
    }
}