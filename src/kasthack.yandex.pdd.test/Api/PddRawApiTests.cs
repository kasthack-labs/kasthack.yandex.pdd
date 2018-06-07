using NUnit.Framework;

namespace kasthack.yandex.pdd.test.Api
{
    [TestFixture]
    public class PddRawApiTests
    {
        private AccessData AccessData;
        [SetUp]
        public void GetOauthToken() => AccessData = SetupHelper.GetData();
        [Test]
        public void BasicConstructionWorks()
        {
            var api = ApiFactory.GetRawApi();
            ValidateApi(api);
        }

        private void ValidateApi(IPddRawApi api)
        {
            Assert.NotNull(api);
            var context = api.Domain(AccessData.Domain);
            Assert.NotNull(context);

            foreach (var methodGroup in new object[] {
                context.Deputy,
                context.Dkim,
                context.Dns,
                context.Domain,
                context.Import,
                context.Mail,
                context.MailList,
            })
            {
                Assert.NotNull(methodGroup);
            }
        }

        [Test]
        public void AdminTokenConstructionWorks()
        {
            var api = ApiFactory.GetRawApi(AccessData.PddToken);
            ValidateApi(api);
            Assert.AreEqual(ApiMode.Admin, api.Mode);
        }
        [Test]
        public void RegistarTokenConstructionWorks()
        {
            var api = ApiFactory.GetRawApi(AccessData.PddToken, YaToken.FromRedirectUri(AccessData.OAuthToken));
            ValidateApi(api);
            Assert.AreEqual(ApiMode.Registar, api.Mode);
        }
    }
}
