namespace kasthack.yandex.pdd.Entities
{
    public enum CheckResult
    {
        OK,
        NoCNameNoFile,
        BadCNameBadFile,
        BadCNameNoFile,
        DomainNotFound,
        Occupied,
        MXWrong,
        MXNotFound
    }
}