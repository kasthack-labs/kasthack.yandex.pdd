using kasthack.yandex.pdd.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace kasthack.yandex.pdd.RawMethods
{
    internal class DomainRawContext : IDomainRawContext
    {
        protected internal readonly PddRawApi Api;
        protected internal readonly string DomainName;


        public IDeputyMethods Deputy { get; }
        public IDnsMethods Dns { get; }
        public IDkimMethods Dkim { get; }
        public IDomainMethods Domain { get; }
        public IImportMethods Import { get; }
        public IMailListMethods MailList { get; }
        public IMailMethods Mail { get; }
        internal DomainRawContext(PddRawApi api, string domain)
        {
            Api = api;
            DomainName = domain;

            Deputy = new DeputyMethods(this);
            Dns = new DnsMethods(this);
            Dkim = new DkimMethods(this);
            Domain = new DomainMethods(this);
            Import = new ImportMethods(this);
            MailList = new MailListMethods(this);
            Mail = new MailMethods(this);
        }



        private IEnumerable<KeyValuePair<string, string>> PrepareParams(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            var ret = new List<KeyValuePair<string, string>>();
            if (DomainName != null) ret.Add(new KeyValuePair<string, string>("domain", DomainName));
            ret.AddRange(parameters.Where(a => a.Key != null && a.Value != null));
            return ret;
        }

        internal async Task<string> ProcessRequestPost(string method, IEnumerable<KeyValuePair<string, string>> parameters) =>
            await Api.ProcessRequestPost(method, PrepareParams(parameters));

        internal async Task<string> ProcessRequestGet(string method, IEnumerable<KeyValuePair<string, string>> parameters) =>
            await Api.ProcessRequestGet(method, PrepareParams(parameters));

        internal async Task<string> ProcessRequestPostForm(string method, MultipartFormDataContent parameters)
            => await Api.ProcessRequestPostForm(method, PrepareForm(parameters));

        private MultipartFormDataContent PrepareForm(MultipartFormDataContent parameters)
        {
            var ret = new MultipartFormDataContent();
            foreach (var parameter in parameters) ret.Add(parameter);
            ret.Add(MiscTools.StringContent("domain", DomainName));
            return ret;
        }
    }
}
