/*
        stuff from https://github.com/kasthack/VKSharp/blob/master/Sources/VKSharp/Helpers/
*/

using System;
using System.Globalization;
using System.Text;

namespace kasthack.yandex.pdd.Helpers {
    internal class BuiltInData {
        private static readonly Lazy<BuiltInData> Lazy = new Lazy<BuiltInData>( () => new BuiltInData() );

        internal static BuiltInData Instance => Lazy.Value;

        public string ApiDomain { get; }

        public string OAuthTokenUri { get; }

        public Encoding TextEncoding { get; } = Encoding.UTF8;

        public CultureInfo NC { get; } = CultureInfo.InvariantCulture;

        private BuiltInData() {
            ApiDomain = "https://pddimp.yandex.ru/api2/";
            OAuthTokenUri = "https://oauth.yandex.ru/authorize?response_type=token&client_id={0}";
        }
    }
}