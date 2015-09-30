using kasthack.yandex.pdd.Helpers;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd {
    public class PddApi {
        internal static readonly JsonSerializer Serializer = SerializerFactory.GetSerializer();
        internal readonly PddRawApi Raw;

        public string PddToken {
            get { return Raw.PddToken; }
            set { Raw.PddToken = value; }
        }

        public YaToken AuthToken {
            get { return Raw.AuthToken; }
            set { Raw.AuthToken = value; }
        }

        public PddApi() : this( null, null ) { }

        public PddApi( string pddtoken, YaToken authtoken ) {
            Raw = new PddRawApi();
            if ( pddtoken != null ) PddToken = pddtoken;
            if ( authtoken != null ) AuthToken = authtoken;
        }

        public DomainContext Domain( string domain ) => new DomainContext( this, domain );
    }

    public class DomainContext {
        private readonly PddApi _api;
        private readonly string _domain;

        internal DomainContext( PddApi api, string domain ) {
            _api = api;
            _domain = domain;
            var rawContext = _api.Raw.Domain( _domain );
            Deputy = new DeputyMethods( rawContext.Deputy );
            Dns = new DnsMethods( rawContext.Dns );
            Dkim = new DkimMethods( rawContext.Dkim );
            Domain = new DomainMethods( rawContext.Domain );
            Import = new ImportMethods( rawContext.Import );
            MailList = new MailListMethods( rawContext.MailList );
            Mail = new MailMethods( rawContext.Mail );
        }

        public DeputyMethods Deputy { get; }
        public DnsMethods Dns { get; }
        public DkimMethods Dkim { get; }
        public DomainMethods Domain { get; }
        public ImportMethods Import { get; }
        public MailListMethods MailList { get; }
        public MailMethods Mail { get; }
    }
}