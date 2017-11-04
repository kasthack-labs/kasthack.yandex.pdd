namespace kasthack.yandex.pdd.Entities
{
    public class EmailAccount : EmailAccountBase
    {
        public bool Ready { get; set; }
        public bool MailList { get; set; }
        public string[] Aliases { get; set; }
    }
}