namespace kasthack.yandex.pdd.RawMethods
{
    /// <summary>
    /// Domain raw(strings) context
    /// </summary>
    public interface IDomainRawContext
    {
        /// <summary>
        /// Deputy methods
        /// </summary>
        IDeputyMethods Deputy { get; }
        /// <summary>
        /// Dkim methods
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