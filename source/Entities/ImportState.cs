namespace kasthack.yandex.pdd.Entities
{
    public enum ImportState
    {
        TaskJustCreated,
        Paused,
        InProgress,
        PauseCauseOfError,
        Failed,
        Done,
        Removed
    }
}