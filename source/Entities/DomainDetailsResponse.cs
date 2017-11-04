namespace kasthack.yandex.pdd.Entities
{

    public class DomainDetailsResponse : Response
    {
        public DomainStatus Status { get; set; }
        public RegistrationStage Stage { get; set; }
        public bool Delegated { get; set; }
        public Country Country { get; set; }
        public bool PopEnabled { get; set; }
        public bool ImapEnabled { get; set; }
        public string DefaultTheme { get; set; }
    }
}