using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.RawMethods;

namespace kasthack.yandex.pdd {
    public class PddRawApi {
        private static readonly HttpClient Client;
        public string PddToken { get; set; }
        public YaToken AuthToken { get; set; }
        public DomainRawContext Domain( string domain ) => new DomainRawContext( this, domain );
        static PddRawApi() { Client = new HttpClient { }; }

        private void UpdateHeaders( HttpRequestHeaders headers ) {
            headers.Add( "PddToken", PddToken );
            headers.Authorization = AuthenticationHeaderValue.Parse( $"OAuth {AuthToken.Token}" );
        }

        internal async Task<string> ProcessRequestPost( string method, IEnumerable<KeyValuePair<string, string>> parameters ) {
            var message = new HttpRequestMessage {
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent( parameters ),
                RequestUri = BuildMethodUri( method ),
            };
            UpdateHeaders( message.Headers );
            return await ( await Client.SendAsync( message ).ConfigureAwait( false ) ).Content.ReadAsStringAsync().ConfigureAwait( false );
        }

        internal async Task<string> ProcessRequestGet( string method, IEnumerable<KeyValuePair<string, string>> parameters ) {
            var ps = HttpUtility.ParseQueryString( string.Empty ); //it's _NOT_ just namevaluecollection
            foreach ( var parameter in parameters ) ps[ parameter.Key ] = parameter.Value;
            var message = new HttpRequestMessage {
                Method = HttpMethod.Get,
                RequestUri = new UriBuilder( BuildMethodUri( method ) ) { Query = ps.ToString() }.Uri,
            };
            UpdateHeaders( message.Headers );
            return await ( await Client.SendAsync( message ).ConfigureAwait( false ) ).Content.ReadAsStringAsync().ConfigureAwait( false );
        }

        private static Uri BuildMethodUri( string method ) { return new Uri( new Uri( BuiltInData.Instance.ApiDomain ), method ); }
    }

    public class DomainRawContextBase {

        protected internal readonly PddRawApi Api;
        protected internal readonly string DomainName;

        internal DomainRawContextBase( PddRawApi api, string domain ) {
            Api = api;
            DomainName = domain;
        }
        private IEnumerable<KeyValuePair<string, string>> PrepareParams(IEnumerable<KeyValuePair<string, string>> parameters) {
            var ret = new List<KeyValuePair<string, string>>();
            if (DomainName != null) ret.Add(new KeyValuePair<string, string>("domain", DomainName));
            ret.AddRange(parameters.Where(a => a.Key != null && a.Value != null));
            return ret;
        }

        internal async Task<string> ProcessRequestPost(string method, IEnumerable<KeyValuePair<string, string>> parameters) =>
            await Api.ProcessRequestPost(method, PrepareParams(parameters));

        internal async Task<string> ProcessRequestGet(string method, IEnumerable<KeyValuePair<string, string>> parameters) =>
            await Api.ProcessRequestGet(method, PrepareParams(parameters));
    }

    public class DomainRawContext : DomainRawContextBase
    {

        internal DomainRawContext( PddRawApi api, string domain ) : base( api, domain) {
            Deputy = new DeputyRawMethods( this );
            Dns = new DnsRawMethods( this );
            Dkim = new DkimRawMethods( this );
            Domain = new DomainRawMethods( this );
            Import = new ImportRawMethods( this );
            MailList = new MailListRawMethods( this );
            Mail = new MailRawMethods( this );
        }

        public DeputyRawMethods Deputy { get; }
        public DnsRawMethods Dns { get; }
        public DkimRawMethods Dkim { get; }
        public DomainRawMethods Domain { get; }
        public ImportRawMethods Import { get; }
        public MailListRawMethods MailList { get; }
        public MailRawMethods Mail { get; }
    }
}