using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.RawMethods;
using System.Linq;

namespace kasthack.yandex.pdd
{
    internal class PddRawApi : IPddRawApi
    {
        private static readonly HttpClient Client;
        internal readonly DomainsMethods DomainMethods;
        public string PddToken { get; set; }
        public YaToken AuthToken { get; set; }
        public IDomainRawContext Domain(string domain) => new DomainRawContext(this, domain);
        static PddRawApi() => Client = new HttpClient { };
        public PddRawApi() => DomainMethods = new DomainsMethods(new DomainRawContext(this, null));
        private void UpdateHeaders(HttpRequestHeaders headers)
        {
            headers.Add("PddToken", PddToken);
            headers.Authorization = AuthenticationHeaderValue.Parse($"OAuth {AuthToken.Token}");
        }

        internal async Task<string> ProcessRequestPost(string method, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(parameters),
                RequestUri = BuildMethodUri(method),
            };
            UpdateHeaders(message.Headers);
            return await GetResponse(message).ConfigureAwait(false);
        }

        internal async Task<string> ProcessRequestGet(string method, IEnumerable<KeyValuePair<string, string>> parameters)
        {
            //var ps = System.Net.WebUtility.WE(string.Empty); //it's _NOT_ just namevaluecollection
            //foreach (var parameter in parameters) ps[parameter.Key] = parameter.Value;

            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new UriBuilder(BuildMethodUri(method)) { Query = string.Join("&", parameters.Select(a => $"{Uri.EscapeUriString(a.Key)}={Uri.EscapeUriString(a.Value)}")) }.Uri,
            };
            UpdateHeaders(message.Headers);
            return await GetResponse(message).ConfigureAwait(false);
        }

        internal async Task<string> ProcessRequestPostForm(string method, MultipartFormDataContent parameters)
        {
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = parameters,
                RequestUri = BuildMethodUri(method),
            };
            UpdateHeaders(message.Headers);
            return await GetResponse(message).ConfigureAwait(false);
        }
        public async Task<string> GetDomains(int? page = null, int? onPage = null) => await DomainMethods.GetDomains(page, onPage).ConfigureAwait(false);
        private async Task<string> GetResponse(HttpRequestMessage message) => await (await Client.SendAsync(message).ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);
        private static Uri BuildMethodUri(string method) => new Uri(new Uri(BuiltInData.Instance.ApiDomain), method);
    }


}