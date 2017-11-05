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

        public ApiMode Mode
        {
            get => Raw.Mode;
            set => Raw.Mode= value;
        }
        public string PddToken {
            get => Raw.PddToken;
            set => Raw.PddToken = value;
        }

        public YaToken AuthToken {
            get => Raw.AuthToken;
            set => Raw.AuthToken = value;
        }

        public PddApi() : this(null, null) { }

        public PddApi(string pddtoken, YaToken authtoken = null)
        {
            Raw = new PddRawApi();
            PddToken = pddtoken;
            if (authtoken != null) AuthToken = authtoken;
            Mode = authtoken == null ? ApiMode.Admin : ApiMode.Registar;
            DomainsMethods = new DomainsMethods(Raw.DomainMethods);
        }

        public IDomainContext Domain(string domain) => new DomainContext(this, domain);

        public async Task<DomainsResponse> GetDomains(int? page = null, int? onPage = null) => await DomainsMethods.GetDomains(page, onPage).ConfigureAwait(false);
    }
}