namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Email import settings. <see href="https://tech.yandex.ru/pdd/doc/reference/import-settings-docpage/">Yandex doc</see>
    /// </summary>
    public class ImportSettings
    {
        /// <summary>
        /// Import method
        /// </summary>
        public ImportMethod Method { get; set; }
        /// <summary>
        /// Server address
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Server port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Enable SSL
        /// </summary>
        public bool Ssl { get; set; }
    }
}