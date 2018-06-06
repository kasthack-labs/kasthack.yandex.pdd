namespace kasthack.yandex.pdd.Entities
{
    public class ListEmailResponse : PageableResponse
    {
        public EmailAccount[] Accounts { get; set; }
    }
}