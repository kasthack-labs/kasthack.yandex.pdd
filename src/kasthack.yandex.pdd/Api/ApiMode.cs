namespace kasthack.yandex.pdd
{
    /// <summary>
    /// API requests mode
    /// </summary>
    public enum ApiMode
    {
        /// <summary>
        /// Admin mode (only PDD-token is passed, requesting /admin/ methods)
        /// </summary>
        Admin,
        /// <summary>
        /// Registar mode (PDD and OAuth tokens are passed, requesting /registar/ methods)
        /// </summary>
        Registar
    }
}