using System.Threading.Tasks;
using kasthack.yandex.pdd.Domain;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Methods;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd {
    public class PddApi {
        internal static readonly JsonSerializer Serializer = SerializerFactory.GetSerializer();
        internal readonly PddRawApi Raw;
        private readonly DomainsMethods DomainsMethods;

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
            DomainsMethods = new DomainsMethods( Raw.DomainMethods );
        }

        public DomainContext Domain( string domain ) => new DomainContext( this, domain );

        public async Task<DomainsResponse> GetDomains(int? page=null, int? onPage=null) => await DomainsMethods.GetDomains(page, onPage).ConfigureAwait(false);
    }

    public class DomainContextBase {

        protected internal readonly PddApi Api;
        protected internal readonly string DomainName;

        internal DomainContextBase( PddApi api, string domain ) {
            Api = api;
            DomainName = domain;
        }
    }

    public class DomainContext : DomainContextBase {
        internal DomainContext( PddApi api, string domain ) : base(api, domain) {
            var rawContext = Api.Raw.Domain(DomainName);
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