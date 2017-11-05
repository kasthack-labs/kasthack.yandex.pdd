namespace kasthack.yandex.pdd.Entities
{
    public class SingleImportSettings : ImportSettings
    {
        public string ExternalLogin { get; set; }
        public string ExternalPassword { get; set; }
        public string InternalLogin { get; set; }
        public string InternalPassword { get; set; }
    }
}