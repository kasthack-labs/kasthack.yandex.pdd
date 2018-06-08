using kasthack.yandex.pdd.Entities;
using NUnit.Framework;
using System;
using System.Linq;
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
            ValidateApi(api, checkPddToken: false);
        }

        private void ValidateApi(IPddApi api, bool checkPddToken = true)
        {
            Assert.NotNull(api);
            var context = api.Domain(AccessData.Domain);
            Assert.NotNull(context);
            if (checkPddToken)
                Assert.AreEqual(AccessData.PddToken, api.PddToken);

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
        public async Task RegistrarTokenConstructionWorks()
        {
            var api = GetRegistrarApi();
            ValidateApi(api);
            Assert.NotNull(api.AuthToken);
            Assert.AreEqual(ApiMode.Registrar, api.Mode);
        }

        private IPddApi GetAdminApi() => ApiFactory.GetApi(AccessData.PddToken);
        private IPddApi GetRegistrarApi() => ApiFactory.GetApi(AccessData.PddToken, YaToken.FromRedirectUri(AccessData.OAuthToken));

        [Test]
        public async Task GetDomainsWorksForAdmin() => await DomainResponseWorks(this.GetAdminApi());

        //[Test]
        //public async Task GetDomainsWorksForRegistrar() => await DomainResponseWorks(this.GetRegistrarApi());

        private static async Task DomainResponseWorks(IPddApi api)
        {
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

                //todo: more consistent ...
                Assert.NotNull(domain.Name);
                Assert.IsNotEmpty(domain.Name);
                Assert.NotZero(domain.EmailsMaxCount);
            }
        }
        //-------------------------
        private IDomainContext GetDomainContext() => GetAdminApi().Domain(AccessData.Domain);

        [Test]
        public async Task DeputyMethodsWork()
        {
            var context = GetDomainContext();

            var deputyName = $"pdddebug@yandex.ru";

            var addResponse = await context.Deputy.Add(deputyName).ConfigureAwait(false);
            ValidateBasicResponse(addResponse);

            //cached responses workaround
            await Task.Delay(3000).ConfigureAwait(false);

            var getDeputiesResponse = await context.Deputy.List().ConfigureAwait(false);
            ValidateBasicResponse(getDeputiesResponse);
            var deputyNames = getDeputiesResponse.Deputies;
            Assert.NotNull(deputyNames);
            Assert.IsNotEmpty(deputyNames);
            Assert.IsTrue(deputyNames.Any(a => a.Contains(deputyName)));

            var removeDeputiesResponse = await context.Deputy.Delete(deputyName);
            ValidateBasicResponse(getDeputiesResponse);

            //cached responses workaround
            await Task.Delay(3000).ConfigureAwait(false);

            var getDeputiesResponseCheck = await context.Deputy.List().ConfigureAwait(false);
            Assert.IsFalse(getDeputiesResponseCheck.Deputies.Any(a => a.Contains(deputyName)));
        }

        [Test]
        public async Task DkimMethodsWork()
        {
            var context = GetDomainContext();

            var statusResponse = await context.Dkim.Status(true);
            ValidateBasicResponse(statusResponse);
            var dkim = statusResponse.Dkim;
            Assert.NotNull(dkim);
            //well-known data
            Assert.IsTrue(dkim.Enabled);
            Assert.IsTrue(dkim.Mailready);
            Assert.IsTrue(dkim.Nsready);

            //todo: investigate
            //Assert.IsNotNull(dkim.Secretkey);
            //Assert.IsNotEmpty(dkim.Secretkey);

            Assert.IsNotNull(dkim.Txtrecord);
            Assert.IsNotEmpty(dkim.Txtrecord);

            Assert.IsNotNull(dkim.TxtrecordContent);
            Assert.IsNotEmpty(dkim.TxtrecordContent);

            //todo: enable/disable
        }
        [Test]
        public async Task DomainMethodsWork()
        {
            var context = GetDomainContext();

            var details = await context.Domain.Details().ConfigureAwait(false);
            ValidateBasicResponse(details);
            //well-known data
            Assert.AreEqual(Country.RU, details.Country);
            Assert.AreEqual(string.Empty, details.DefaultTheme);
            Assert.IsFalse(details.Delegated);
            Assert.IsTrue(details.ImapEnabled);
            Assert.IsTrue(details.PopEnabled);
            Assert.AreEqual(RegistrationStage.Added, details.Stage);
            Assert.AreEqual(DomainStatus.Added, details.Status);

            var logo = await context.Domain.GetLogo();
            ValidateBasicResponse(logo);
            Assert.IsNotEmpty(logo.LogoUrl);

            //todo: rw methods
        }
        [Test]
        public async Task MailListMethodsWork()
        {
            var context = GetDomainContext();

            var maillistName = $"maillist_{DateTimeOffset.Now.ToUnixTimeMilliseconds()}";
            string subscriber = $"shit@{AccessData.Domain}";
            string maillistAddress = $"{maillistName}@{AccessData.Domain}";

            var addd = await context.MailList.Add(maillistName).ConfigureAwait(false);
            ValidateBasicResponse(addd);
            Assert.NotZero(addd.Uid);
            Assert.AreEqual(maillistAddress, addd.Maillist);

            var list = await context.MailList.List().ConfigureAwait(false);
            ValidateBasicResponse(list);
            Assert.NotNull(list.Maillists);
            Assert.IsNotEmpty(list.Maillists);
            foreach (var maillist in list.Maillists)
            {
                Assert.NotNull(maillist);
                Assert.IsNotEmpty(maillist.Maillist);
                Assert.NotNull(maillist.Uid);
                Assert.NotZero(maillist.Uid.Value);
            }

            var subscribe = await context.MailList.Subscribe(addd.Uid, subscriber, true).ConfigureAwait(false);
            ValidateBasicResponse(subscribe);
            Assert.AreEqual(maillistAddress, subscribe.Maillist);
            Assert.AreEqual(subscriber, subscribe.Subscriber);
            Assert.AreEqual(addd.Uid, subscribe.Uid);
            Assert.AreEqual(true, subscribe.CanSendOnBehalf);

            var scsob = await context.MailList.SetCanSendToMailList(maillistName, subscriber, false);
            ValidateBasicResponse(scsob);
            Assert.IsFalse(scsob.CanSendOnBehalf);

            var subscribers = await context.MailList.Subscribers(addd.Uid).ConfigureAwait(false);
            ValidateBasicResponse(subscribers);
            Assert.AreEqual(maillistAddress, subscribers.Maillist);
            Assert.NotNull(subscribers.Subscribers);
            Assert.IsNotEmpty(subscribers.Subscribers);
            Assert.IsTrue(subscribers.Subscribers.Contains(subscriber));

            var delete = await context.MailList.Delete(addd.Uid).ConfigureAwait(false);
            ValidateBasicResponse(delete);
            Assert.AreEqual(maillistAddress, delete.Maillist);
        }

        private void ValidateBasicResponse(Response addResponse)
        {
            Assert.AreEqual(AccessData.Domain, addResponse.Domain);
            Assert.AreEqual(null, addResponse.Error);
            Assert.AreEqual(true, addResponse.Success);
        }
    }
}
