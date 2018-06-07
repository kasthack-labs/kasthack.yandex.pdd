namespace kasthack.yandex.pdd.Entities
{
    ///<summary>
    ///
    ///</summary>
    public class EmailAccountId
    {
        ///<summary>
        ///Login
        ///</summary>
        public string Login { get; set; }
        ///<summary>
        ///Account user ID
        ///</summary>
        public long? Uid { get; set; }

        public static implicit operator EmailAccountId(string login) => new EmailAccountId { Login = login };
        public static implicit operator EmailAccountId(long? uid) => new EmailAccountId { Uid = uid };
        public static implicit operator EmailAccountId(long uid) => new EmailAccountId { Uid = uid };
        public override string ToString() => $"{Login} [UID={Uid}]";
    }
}