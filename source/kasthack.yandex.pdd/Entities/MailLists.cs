using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.MailLists
{
    public abstract class MaillistResponse : Response
    {
        public string Maillist { get; set; }
    }

    public abstract class MaillistUidResponse : MaillistResponse {
        public long Uid { get; set; }
    }
    public abstract class SubscriberResponse : MaillistUidResponse
    {
        public string Subscriber { get; set; }
    }
    public abstract class RightsResponse : SubscriberResponse
    {
        public bool CanSendOnBehalf { get; set; }
    }
    //===============================

    public class AddResponse : MaillistUidResponse { }

    public class LisResponse {
        public MailList[] Maillists { get; set; }
    }
    public class DelResponse : MaillistResponse { }

    public class SubscribeResponse : SubscriberResponse {
    }

    public class SubscribersResponse : MaillistUidResponse {
        public string[] Subscribers { get; set; }
    }
    public class UnsubscribeResponse : SubscriberResponse
    {
        public long Uid { get; set; }
    }

    public class GetCanSendResponse : RightsResponse
    {
        public string SubscriberUid { get; set; }
    }
    public class SetCanSendResponse : RightsResponse
    {
        
    }
    public class MailListBase
    {
        public string Maillist { get; set; }
        public long Uid { get; set; }
    }

    public class MailList : MailListBase {
        public int Cnt { get; set; }
    }
}
