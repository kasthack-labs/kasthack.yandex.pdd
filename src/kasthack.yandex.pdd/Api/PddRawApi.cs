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
    /// <summary>
    /// PDD raw API
    /// </summary>
    public class PddRawApi : IPddRawApi
    {
        private static readonly HttpClient Client;
        internal readonly DomainsMethods DomainMethods;
        /// <inheritdoc/>
        public string PddToken { get; set; }
        /// <inheritdoc/>
        public YaToken AuthToken { get; set; }
        /// <inheritdoc/>
        public ApiMode Mode { get; set; }
        /// <inheritdoc/>
        public IDomainRawContext Domain(string domain) => new DomainRawContext(this, domain);
        static PddRawApi() => Client = new HttpClient { };
        /// <summary>
        /// Creates raw api instance
        /// <param name="pddToken">PDD token</param>
        /// <param name="token">OAuth token(if required)</param>
        /// </summary>
        public PddRawApi(string pddToken = null, YaToken token = null)
        {
            PddToken = pddToken;
            AuthToken = token;
            Mode = token == null ? ApiMode.Registar : ApiMode.Admin;
            DomainMethods = new DomainsMethods(new DomainRawContext(this, null));
        }

        private void UpdateHeaders(HttpRequestHeaders headers)
        {
            headers.Add("PddToken", PddToken);
            if (Mode == ApiMode.Registar)
            {
                if (AuthToken == null) {
                    throw new InvalidOperationException($"You have to set {nameof(AuthToken)} to make call as a registar");
                }
                headers.Authorization = AuthenticationHeaderValue.Parse($"OAuth {AuthToken.Token}");
            }
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
        /// <inheritdoc/>
        public async Task<string> GetDomains(int? page = null, int? onPage = null) => await DomainMethods.GetDomains(page, onPage).ConfigureAwait(false);
        private async Task<string> GetResponse(HttpRequestMessage message) => await (await Client.SendAsync(message).ConfigureAwait(false)).Content.ReadAsStringAsync().ConfigureAwait(false);
        private Uri BuildMethodUri(string method) => new Uri(new Uri($"{BuiltInData.Instance.ApiDomain}{Mode.ToString().ToLowerInvariant()}/"), method);
    }
}