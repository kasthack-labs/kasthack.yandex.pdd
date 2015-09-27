using kasthack.yandex.pdd.Helpers;
using Newtonsoft.Json;

namespace kasthack.yandex.pdd.Api {
    public class PddApi {
        internal static readonly JsonSerializer Serializer = SerializerFactory.GetSerializer();
        internal readonly PddRawApi Raw;
        public string Token
        {
            get { return Raw.Token; }
            set { Raw.Token = value; }
        }

        public PddApi() : this( null ) { }

        public PddApi(string token) {
            Raw = new PddRawApi();
            if ( token != null ) Token = token;
        }

        public DomainContext Domain(string domain) => new DomainContext( this, domain );
    }

    public class DomainContext {
        private readonly PddApi _api;
        private readonly string _domain;

        internal DomainContext( PddApi api, string domain ) {
            _api = api;
            _domain = domain;
            Mail = new MailMethods( _api.Raw.Domain( _domain ).Mail );
            
        }

        public MailMethods Mail { get; }
    }
}