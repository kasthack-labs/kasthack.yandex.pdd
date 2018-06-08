namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Domain details response
    /// </summary>
    public class DomainDetailsResponse : Response
    {
        /// <summary>
        /// Domain status.
        /// </summary>
        public DomainStatus Status { get; set; }
        /// <summary>
        /// The key duplicates status for internal use.
        /// </summary>
        public RegistrationStage Stage { get; set; }
        /// <summary>
        /// Status of domain delegation to the Yandex servers (dns1.yandex.net and dns2.yandex.net).
        /// </summary>
        public bool Delegated { get; set; }
        /// <summary>
        /// The default language of the mailbox interface for the domain.
        /// </summary>
        public Country Country { get; set; }
        /// <summary>
        /// Status of POP operation on the domain.
        /// Included in the response if the domain has been verified(the status value is set to mx-activate or added).
        /// </summary>
        public bool PopEnabled { get; set; }
        /// <summary>
        /// Status of IMAP operation on the domain.
        /// Included in the response if the domain has been verified(the status value is set to mx-activate or added).
        /// </summary>
        public bool ImapEnabled { get; set; }
        /// <summary>
        /// ID of the default design theme for all the domain mailboxes (for example, starwars is the ID for the “Star Wars” theme).
        /// </summary>
        public string DefaultTheme { get; set; }
        
        //undocumented
        public bool CanUsersChangePassword { get; set; }
        public long DefaultUid { get; set; }
        public bool MasterAdmin { get; set; }
        public bool FromRegistar { get; set; }
        public bool RosterEnabled { get; set; }
        public bool WsTechnical { get; set; }
    }
}