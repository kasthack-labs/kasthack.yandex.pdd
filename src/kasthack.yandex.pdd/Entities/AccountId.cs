namespace kasthack.yandex.pdd.Entities
{
    public class EmailAccountId
    {
        public string Login { get; set; }
        public long? Uid { get; set; }

        public static implicit operator EmailAccountId(string login) => new EmailAccountId { Login = login };
        public static implicit operator EmailAccountId(long? uid) => new EmailAccountId { Uid = uid };
        public static implicit operator EmailAccountId(long uid) => new EmailAccountId { Uid = uid };
        public override string ToString() => $"{Login} [UID={Uid}]";
    }
}