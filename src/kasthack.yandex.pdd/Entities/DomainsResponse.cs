namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// GetDomains response
    /// </summary>
    public class DomainsResponse : ResponseBase
    {
        /// <summary>
        /// Pagination page
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Number of items per page
        /// </summary>
        public int OnPage { get; set; }
        /// <summary>
        /// Total items
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Number of items on the current page
        /// </summary>
        public int Found { get; set; }
        /// <summary>
        /// Domains
        /// </summary>
        public DomainInfo[] Domains { get; set; }
    }
}