using kasthack.yandex.pdd.Methods;

namespace kasthack.yandex.pdd
{
    internal class DomainContext : IDomainContext
    {
        protected internal readonly PddApi Api;
        protected internal readonly string DomainName;

        internal DomainContext(PddApi api, string domain)
        {

            Api = api;
            DomainName = domain;

            var rawContext = Api.Raw.Domain(DomainName);
            Deputy = new DeputyMethods(rawContext.Deputy);
            Dns = new DnsMethods(rawContext.Dns);
            Dkim = new DkimMethods(rawContext.Dkim);
            Domain = new DomainMethods(rawContext.Domain);
            Import = new ImportMethods(rawContext.Import);
            MailList = new MailListMethods(rawContext.MailList);
            Mail = new MailMethods(rawContext.Mail);
        }

        public IDeputyMethods Deputy { get; }
        public IDnsMethods Dns { get; }
        public IDkimMethods Dkim { get; }
        public IDomainMethods Domain { get; }
        public IImportMethods Import { get; }
        public IMailListMethods MailList { get; }
        public IMailMethods Mail { get; }
    }
}