namespace kasthack.yandex.pdd.Entities
{
    ///<summary>
    ///List deputies response
    ///</summary>
    public class ListDeputiesResponse : Response
    {
        ///<summary>
        ///Deputy usernames
        ///</summary>
        public string[][] Deputies { get; set; }
    }
}