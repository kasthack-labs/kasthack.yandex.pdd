namespace kasthack.yandex.pdd.Entities
{
    public class ImportInfo
    {
        public ImportState State { get; set; }
        public int DoneBoxCount { get; set; }
        public int TotalBoxCount { get; set; }
        public int CompleteBoxCount { get; set; }
        public int FailedBoxesCount { get; set; }
        public int FailedBoxesPages { get; set; }
        public int FailedBoxesCurrentPage { get; set; }
        public int ImportedMessageCount { get; set; }
        public int TotalMessageCount { get; set; }
        public int ProgressPercent { get; set; }
        public ImportItemStatus[] FailedBoxes { get; set; }
    }
}