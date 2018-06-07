namespace kasthack.yandex.pdd
{
    /// <summary>
    /// Main api factory
    /// </summary>
    public static class ApiFactory
    {
        /// <summary>
        /// Creates PDD api instance
        /// </summary>
        public static IPddApi GetApi() => new PddApi();
        /// <summary>
        /// Creates PDD api instance
        /// </summary>
        /// <param name="pddtoken">PDD token</param>
        /// <param name="authtoken">Auth token</param>
        public static IPddApi GetApi(string pddtoken, YaToken authtoken = null) => new PddApi(pddtoken, authtoken);
        /// <summary>
        /// Creates PDD RAW api instance
        /// </summary>
        public static IPddRawApi GetRawApi() => new PddRawApi();
        /// <summary>
        /// Creates PDD RAW api instance
        /// </summary>
        /// <param name="pddtoken">PDD token</param>
        /// <param name="authtoken">Auth token</param>
        public static IPddRawApi GetRawApi(string pddtoken, YaToken authtoken = null) => new PddRawApi(pddtoken, authtoken);

    }
}
