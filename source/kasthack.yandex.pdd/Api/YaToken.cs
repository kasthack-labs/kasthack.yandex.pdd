using System;
using System.Linq;
using System.Security.Authentication;
using kasthack.yandex.pdd.Helpers;

namespace kasthack.yandex.pdd {
    public class YaToken {
        public string Token { get; private set; }
        public long Expires { get; private set; }

        public YaToken( string token, long expires = -1 ) {
            Token = token;
            Expires = expires;
        }

        public static implicit operator YaToken( string source ) => new YaToken( source );

        public static string GetOAuthUri( string client_id ) => String.Format( BuiltInData.Instance.OAuthTokenUri, client_id );

        public static YaToken FromRedirectUri( string url ) {
            const string accessTokenPn = @"access_token";
            const string expiresIn = @"expires_in";
            const string errorPn = @"error";
            var query = new Uri( url ).Fragment.TrimStart( '#' )
                              .Split( '&' )
                              .Select( a => a.Split( '=' ) )
                              .Where( a => a.Length == 2 )
                              .GroupBy( a => a[ 0 ] )
                              .ToDictionary( a => a.Key, a => a.First()[ 1 ] );
            if (query.ContainsKey( errorPn ))
                throw new AuthenticationException( $"Error: {query[errorPn]}" );

            string token;
            if (!query.TryGetValue( accessTokenPn, out token ))
                throw new FormatException("Can't parse Ya response from URL");

            long expiresv;
            {
                string expires;
                query.TryGetValue( expiresIn, out expires );
                if ( !long.TryParse( expires, out expiresv ) ) expiresv = -1;
            }
            return new YaToken( token, expiresv );
        }
    }
}