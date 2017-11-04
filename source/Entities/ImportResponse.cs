namespace kasthack.yandex.pdd.Entities
{
    public abstract class ImportResponse : Response
    {
        public ImportSettings Settings { get; set; }
    }
}