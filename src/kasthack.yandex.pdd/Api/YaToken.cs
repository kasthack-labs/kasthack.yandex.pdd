using System;
using System.Linq;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd
{
    /// <summary>
    /// Yandex OAuth token
    /// </summary>
    public class YaToken
    {
        /// <summary>
        /// Token value
        /// </summary>
        public string Token { get; private set; }
        /// <summary>
        /// Expiration timeout in seconds
        /// </summary>
        public long Expires { get; private set; }
        /// <summary>
        /// Creates yandex token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="expires"></param>
        public YaToken(string token, long expires = -1)
        {
            Token = token;
            Expires = expires;
        }
        /// <summary>
        /// Implicitly casts string to YaToken
        /// </summary>
        /// <param name="source">source string</param>
        public static implicit operator YaToken(string source) => new YaToken(source);
        /// <summary>
        /// Get oauth uri for client id
        /// </summary>
        /// <param name="client_id">client id</param>
        /// <returns>OAuth uri</returns>
        public static string GetOAuthUri(string client_id) => String.Format(BuiltInData.Instance.OAuthTokenUri, client_id);
        /// <summary>
        /// Parses yandex redirect uri
        /// </summary>
        /// <param name="url">Redirect uri</param>
        /// <returns>Parsed token</returns>
        public static YaToken FromRedirectUri(string url)
        {
            const string accessTokenPn = @"access_token";
            const string expiresIn = @"expires_in";
            const string errorPn = @"error";
            var query = new Uri(url).Fragment.TrimStart('#')
                              .Split('&')
                              .Select(a => a.Split('='))
                              .Where(a => a.Length == 2)
                              .GroupBy(a => a[0])
                              .ToDictionary(a => a.Key, a => a.First()[1]);
            if (query.ContainsKey(errorPn)) throw new Exception($"Error: {query[errorPn]}");

            string token;
            if (!query.TryGetValue(accessTokenPn, out token)) throw new FormatException("Can't parse Ya response from URL");

            long expiresv;
            {
                string expires;
                query.TryGetValue(expiresIn, out expires);
                if (!long.TryParse(expires, out expiresv)) expiresv = -1;
            }
            return new YaToken(token, expiresv);
        }
    }
}