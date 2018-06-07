using kasthack.yandex.pdd.Entities;
using NUnit.Framework;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.test.Api
{
    [TestFixture]
    public class PddApiTests
    {
        private AccessData AccessData;
        [SetUp]
        public void GetOauthToken() => AccessData = SetupHelper.GetData();
        [Test]
        public void BasicConstructionWorks()
        {
            var api = ApiFactory.GetApi();
            ValidateApi(api);
        }

        private void ValidateApi(IPddApi api)
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
        public async Task AdminTokenConstructionWorks()
        {
            var api = GetAdminApi();
            ValidateApi(api);
            Assert.AreEqual(ApiMode.Admin, api.Mode);
        }

        [Test]
        public async Task RegistarTokenConstructionWorks()
        {
            var api = GetRegistarApi();
            ValidateApi(api);
            Assert.AreEqual(ApiMode.Registar, api.Mode);
        }

        private IPddApi GetAdminApi() => ApiFactory.GetApi(AccessData.PddToken);
        private IPddApi GetRegistarApi() => ApiFactory.GetApi(AccessData.PddToken, YaToken.FromRedirectUri(AccessData.OAuthToken));

        [Test]
        public async Task GetDomainsWorksForAdmin()
        {
            var api = GetAdminApi();

            var domainsResponse = await api.GetDomains().ConfigureAwait(false);

            Assert.NotNull(domainsResponse);
            Assert.True(domainsResponse.Success);
            Assert.AreEqual(null, domainsResponse.Error);

            Assert.NotZero(domainsResponse.Found);
            Assert.NotZero(domainsResponse.OnPage);
            Assert.NotZero(domainsResponse.Page);
            Assert.NotZero(domainsResponse.Total);

            var domains = domainsResponse.Domains;
            Assert.NotNull(domains);
            Assert.IsNotEmpty(domainsResponse.Domains);

            foreach (var domain in domains)
            {
                Assert.NotNull(domain);

                Assert.NotNull(domain.Aliases);
                Assert.IsNotEmpty(domain.Aliases);

                //domain.DkimReady
            }
        }
    }
}
