using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Methods;
using Newtonsoft.Json;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd
{
    public class PddApi
    {
        internal static readonly JsonSerializer Serializer = SerializerFactory.GetSerializer();
        internal readonly PddRawApi Raw;
        private readonly DomainsMethods DomainsMethods;

        public string PddToken {
            get => Raw.PddToken;
            set => Raw.PddToken = value;
        }

        public YaToken AuthToken {
            get => Raw.AuthToken;
            set => Raw.AuthToken = value;
        }

        public PddApi() : this(null, null) { }

        public PddApi(string pddtoken = null, YaToken authtoken = null)
        {
            Raw = new PddRawApi();
            if (pddtoken != null) PddToken = pddtoken;
            if (authtoken != null) AuthToken = authtoken;
            DomainsMethods = new DomainsMethods(Raw.DomainMethods);
        }

        public IDomainContext Domain(string domain) => new DomainContext(this, domain);

        public async Task<DomainsResponse> GetDomains(int? page = null, int? onPage = null) => await DomainsMethods.GetDomains(page, onPage).ConfigureAwait(false);
    }
}