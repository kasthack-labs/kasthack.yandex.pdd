namespace kasthack.yandex.pdd.Entities
{
    ///<summary>
    ///Information about enabling DKIM, and the public and private DKIM keys.
    ///</summary>
    public class DkimBase
    {
        ///<summary>
        ///Status of enabling DKIM for the domain.
        ///</summary>
        public bool Enabled { get; set; }
        ///<summary>
        ///A TXT record with a public DKIM key for independently making settings.
        ///</summary>
        public string Txtrecord { get; set; }
    }
}