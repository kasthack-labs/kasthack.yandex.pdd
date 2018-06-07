namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// List emails response
    /// </summary>
    public class ListEmailResponse : Response
    {
        /// <summary>
        /// Pagination page
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// Number of pagination pages
        /// </summary>
        public int Pages { get; set; }
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
        /// Found accounts
        /// </summary>
        public EmailAccount[] Accounts { get; set; }
    }
}