namespace kasthack.yandex.pdd.Entities
{
    ///<summary>
    ///Information about enabling DKIM, and the public and private DKIM keys.
    ///</summary>
    public class Dkim : DkimBase
    {
        ///<summary>
        ///Whether there is a TXT record.
        ///</summary>
        public bool Nsready { get; set; }
        ///<summary>
        ///Whether Yandex.Mail for Domain is ready to sign email using DKIM.
        ///</summary>
        public bool Mailready { get; set; }
        ///<summary>
        ///Private DKIM key.
        ///</summary>
        public string Secretkey { get; set; }
    }
}