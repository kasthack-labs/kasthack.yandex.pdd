namespace kasthack.yandex.pdd.MailLists {
    public abstract class MaillistResponse : Response {
        public string Maillist { get; set; }
    }

    public abstract class MaillistUidResponse : MaillistResponse {
        public long Uid { get; set; }
    }

    public abstract class SubscriberResponse : MaillistUidResponse {
        public string Subscriber { get; set; }
    }

    public abstract class RightsResponse : SubscriberResponse {
        public bool CanSendOnBehalf { get; set; }
    }

    //===============================

    public class AddResponse : MaillistUidResponse {}

    public class ListResponse {
        public MailList[] Maillists { get; set; }
    }

    public class DeleteResponse : MaillistResponse {}

    public class SubscribeResponse : SubscriberResponse {}

    public class SubscribersResponse : MaillistUidResponse {
        public string[] Subscribers { get; set; }
    }

    public class UnsubscribeResponse : SubscriberResponse {
        public long Uid { get; set; }
    }

    public class GetCanSendResponse : RightsResponse {
        public string SubscriberUid { get; set; }
    }

    public class SetCanSendResponse : RightsResponse {}

    public class MailListId {
        public string Maillist { get; set; }
        public long? Uid { get; set; }
        public static implicit operator MailListId( string maillist ) => new MailListId { Maillist = maillist };
        public static implicit operator MailListId( long uid ) => new MailListId { Uid = uid };
    }

    public class MailList : MailListId {
        public int Cnt { get; set; }
    }
}