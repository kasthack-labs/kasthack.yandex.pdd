namespace kasthack.yandex.pdd
{
    /// <summary>
    /// Api with tokens &amp; mode
    /// </summary>
    public interface ITokenModedApi
    {

        /// <summary>
        /// Current OAuth token
        /// </summary>
        YaToken AuthToken { get; set; }
        /// <summary>
        /// Current PDD Token
        /// </summary>
        string PddToken { get; set; }
        /// <summary>
        /// Reuqest mode
        /// </summary>
        ApiMode Mode { get; set; }
    }
}