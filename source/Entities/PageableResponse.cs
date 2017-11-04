namespace kasthack.yandex.pdd.Entities
{
    public abstract class PageableResponse : Response
    {
        public int Page { get; set; }
        public int OnPage { get; set; }
        public int Total { get; set; }
        public int Found { get; set; }
    }
}