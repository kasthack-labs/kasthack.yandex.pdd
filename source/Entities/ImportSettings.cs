namespace kasthack.yandex.pdd.Entities
{
    public class ImportSettings
    {
        public ImportMethod Method { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }
}