namespace kasthack.yandex.pdd.Entities
{
    public class Dkim : DkimBase
    {
        public bool Nsready { get; set; }
        public bool Mailready { get; set; }
        public string Secretkey { get; set; }
    }
}