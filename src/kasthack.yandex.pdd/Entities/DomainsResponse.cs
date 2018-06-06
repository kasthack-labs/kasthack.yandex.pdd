namespace kasthack.yandex.pdd.Entities
{
    public class DomainsResponse : PageableResponse
    {
        public DomainInfo[] Domains { get; set; }
    }
}