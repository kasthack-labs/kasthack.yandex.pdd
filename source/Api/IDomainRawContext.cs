namespace kasthack.yandex.pdd.RawMethods
{
    public interface IDomainRawContext
    {
        IDeputyMethods Deputy { get; }
        IDkimMethods Dkim { get; }
        IDnsMethods Dns { get; }
        IDomainMethods Domain { get; }
        IImportMethods Import { get; }
        IMailMethods Mail { get; }
        IMailListMethods MailList { get; }
    }
}