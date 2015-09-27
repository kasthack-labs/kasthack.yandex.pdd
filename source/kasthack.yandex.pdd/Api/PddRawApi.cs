using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace kasthack.yandex.pdd {

    public class PddRawApi {
        private static readonly HttpClient Client;
        public string Token { get; set; }
        public DomainRawContext Domain(string domain) => new DomainRawContext( this, domain );
        static PddRawApi() { Client = new HttpClient() { BaseAddress = new Uri( "https://pddimp.yandex.ru/api2/admin" ) }; }
        internal async Task<string> ProcessRequestPost( string method, IEnumerable<KeyValuePair<string, string>> parameters) {
            return
                await
                ( await
                  Client.SendAsync(
                      new HttpRequestMessage() {
                          Method = HttpMethod.Post,
                          Headers = { { "PddToken", Token } },
                          Content = new FormUrlEncodedContent(parameters),
                          RequestUri = new Uri( method, UriKind.Relative ),
                      } ).ConfigureAwait( false ) ).Content.ReadAsStringAsync().ConfigureAwait( false );
        }
        internal async Task<string> ProcessRequestGet(string method, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var ps = HttpUtility.ParseQueryString( string.Empty );//it's _NOT_ just namevaluecollection
            foreach ( var parameter in parameters) ps[ parameter.Key ] = parameter.Value;
            var urin = new UriBuilder( new Uri( method, UriKind.Relative ) ) { Query = ps.ToString() };
            return await ( await Client.SendAsync(
                new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    Headers = { { "PddToken", Token } },
                    RequestUri = urin.Uri,
                }).ConfigureAwait( false ) ).Content.ReadAsStringAsync().ConfigureAwait( false );
        }
    }

    public class DomainRawContext {
        private readonly PddRawApi _api;
        private readonly string _domain;

        internal DomainRawContext( PddRawApi api, string domain ) {
            _api = api;
            _domain = domain;
            Mail = new MailRawMethods( this );
        }

        public MailRawMethods Mail { get; }

        private IEnumerable<KeyValuePair<string, string>> PrepareParams(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var ret = parameters.Where(a => a.Key != null && a.Value != null).ToList();
            if (_domain != null)
                ret.Add(new KeyValuePair<string, string>("domain", _domain));
            return ret;
        }
        internal async Task<string> ProcessRequestPost(string method, IEnumerable<KeyValuePair<string, string>> parameters)
            => await _api.ProcessRequestPost(method, PrepareParams(parameters));
        internal async Task<string> ProcessRequestGet( string method, IEnumerable<KeyValuePair<string, string>> parameters )
            => await _api.ProcessRequestGet( method, PrepareParams( parameters ) );
    }
}