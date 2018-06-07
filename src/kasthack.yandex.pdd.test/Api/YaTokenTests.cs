using NUnit.Framework;
using System;

namespace kasthack.yandex.pdd.test.Api
{
    [TestFixture]
    public class YaTokenTests
    {
        [Test]
        public void FromRedirectUriWorks() {
            const string tokenValue = "token_value";
            const int expires = 1234;

            var token = YaToken.FromRedirectUri($"https://localhost/oauth#access_token={tokenValue}&token_type=bearer&expires_in={expires}");
            Assert.AreEqual(expires, token.Expires);
            Assert.AreEqual(tokenValue, token.Token);
        }
        [Test]
        public void FromRedirectUriThrowsOnError()
        {
            Assert.Throws<Exception>(() => YaToken.FromRedirectUri($"https://localhost/oauth#error=lol"));
        }
    }
}
