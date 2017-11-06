namespace kasthack.yandex.pdd.Entities
{
    public class ImportItemStatus : ImportItemBase
    {
        public int ImportedMail { get; set; }
        public string LastError { get; set; }
        public string LastErrorCount { get; set; }
    }
}