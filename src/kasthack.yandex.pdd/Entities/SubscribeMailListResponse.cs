namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Subscribe to maillist response
    /// </summary>
    public class SubscribeMailListResponse : SubscriberResponse {

        /// <summary>
        /// Subscriber's status. 
        /// </summary>
        public bool? CanSendOnBehalf { get; set; }
    }
}