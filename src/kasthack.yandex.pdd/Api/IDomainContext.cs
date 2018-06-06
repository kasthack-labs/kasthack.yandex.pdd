using kasthack.yandex.pdd.Methods;

namespace kasthack.yandex.pdd
{
    /// <summary>
    /// Typed domain context
    /// </summary>
    public interface IDomainContext
    {
        /// <summary>
        /// Deputy methods
        /// </summary>
        IDeputyMethods Deputy { get; }
        /// <summary>
        /// DKIM methods
        /// </summary>
        IDkimMethods Dkim { get; }
        /// <summary>
        /// DNS methods
        /// </summary>
        IDnsMethods Dns { get; }
        /// <summary>
        /// Domain methods
        /// </summary>
        IDomainMethods Domain { get; }
        /// <summary>
        /// Import methods
        /// </summary>
        IImportMethods Import { get; }
        /// <summary>
        /// Mail methods
        /// </summary>
        IMailMethods Mail { get; }
        /// <summary>
        /// Maillist methods
        /// </summary>
        IMailListMethods MailList { get; }
    }
}