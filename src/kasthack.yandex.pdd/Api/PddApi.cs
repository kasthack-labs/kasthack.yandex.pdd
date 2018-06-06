using System.Threading.Tasks;
using kasthack.yandex.pdd.Helpers;
using kasthack.yandex.pdd.Methods;
using Newtonsoft.Json;
using kasthack.yandex.pdd.Entities;

namespace kasthack.yandex.pdd
{
    /// <summary>
    /// PDD typed API
    /// </summary>
    public class PddApi : IPddApi
    {
        internal static readonly JsonSerializer Serializer = SerializerFactory.GetSerializer();
        internal readonly PddRawApi Raw;
        private readonly DomainsMethods DomainsMethods;

        /// <inheritdoc/>
        public ApiMode Mode
        {
            get => Raw.Mode;
            set => Raw.Mode= value;
        }
        /// <inheritdoc/>
        public string PddToken {
            get => Raw.PddToken;
            set => Raw.PddToken = value;
        }
        /// <inheritdoc/>
        public YaToken AuthToken {
            get => Raw.AuthToken;
            set => Raw.AuthToken = value;
        }
        /// <summary>
        /// PDD api instance
        /// </summary>
        public PddApi() : this(null, null) { }
        /// <summary>
        /// Creates PDD api instance
        /// </summary>
        /// <param name="pddtoken">PDD token</param>
        /// <param name="authtoken">Auth token</param>
        public PddApi(string pddtoken, YaToken authtoken = null)
        {
            Raw = new PddRawApi();
            PddToken = pddtoken;
            if (authtoken != null) AuthToken = authtoken;
            Mode = authtoken == null ? ApiMode.Admin : ApiMode.Registar;
            DomainsMethods = new DomainsMethods(Raw.DomainMethods);
        }
        /// <inheritdoc/>
        public IDomainContext Domain(string domain) => new DomainContext(this, domain);

        /// <inheritdoc/>
        public async Task<DomainsResponse> GetDomains(int? page = null, int? onPage = null) => await DomainsMethods.GetDomains(page, onPage).ConfigureAwait(false);
    }
}