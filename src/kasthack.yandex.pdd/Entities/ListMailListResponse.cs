namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// List maillists response
    /// </summary>
    public class ListMailListResponse : Response
    {
        /// <summary>
        /// Properties of mailing lists. Each object in the array corresponds to a single mailing list.
        /// </summary>
        public MailList[] Maillists { get; set; }
        /// <summary>
        /// Total number of mailing lists
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Sort field
        /// </summary>
        public string Order { get; set; }
    }
}