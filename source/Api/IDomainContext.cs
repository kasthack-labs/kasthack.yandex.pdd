using kasthack.yandex.pdd.Methods;

namespace kasthack.yandex.pdd
{
    public interface IDomainContext
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