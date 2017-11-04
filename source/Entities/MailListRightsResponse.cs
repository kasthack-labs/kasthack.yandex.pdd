namespace kasthack.yandex.pdd.Entities
{
    public abstract class MailListRightsResponse : SubscriberResponse
    {
        public bool CanSendOnBehalf { get; set; }
    }
}