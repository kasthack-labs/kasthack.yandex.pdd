namespace kasthack.yandex.pdd.Entities
{
    ///<summary>
    ///DKIM status response
    ///</summary>
    public class DkimStatusResponse : Response
    {
        ///<summary>
        ///Information about enabling DKIM, and the public and private DKIM keys.
        ///</summary>
        public Dkim Dkim { get; set; }
    }
}