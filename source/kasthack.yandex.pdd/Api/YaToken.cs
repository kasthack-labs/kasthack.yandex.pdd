/*
    almost copypasted from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Core/Api/VKToken.cs
*/
using System;
using System.Linq;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd
{
    public class YaToken
    {
        public string Token { get; private set; }
        public long Expires { get; private set; }

        public YaToken(string token, long expires = -1) {
            Token = token;
            Expires = expires;
        }

        public static implicit  operator YaToken(string source) => new YaToken( source );

        public static string GetOAuthURL(string client_id) => String.Format( BuiltInData.Instance.OAuthURL, client_id);

        public static YaToken FromRedirectUrl(string url)
        {
            const string accessTokenPn = @"access_token";
            const string signPn = @"expires_in";
            var query = new Uri(url)
                .Fragment
                .TrimStart('#')
                .Split('&')
                .Select(a => a.Split('='))
                .Where(a => a.Length == 2)
                .GroupBy(a => a[0])
                .ToDictionary(a => a.Key, a => a.First()[1]);
            
            return new YaToken( query[accessTokenPn], long.Parse( query[signPn] ) );
        }
    }
}
