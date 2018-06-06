namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Import state
    /// </summary>
    public enum ImportState
    {
        /// <summary>
        /// Task just created
        /// </summary>
        TaskJustCreated,
        /// <summary>
        /// Paused
        /// </summary>
        Paused,
        /// <summary>
        /// In progress
        /// </summary>
        InProgress,
        /// <summary>
        /// Paused due to an error
        /// </summary>
        PauseCauseOfError,
        /// <summary>
        /// Failed
        /// </summary>
        Failed,
        /// <summary>
        /// Done
        /// </summary>
        Done,
        /// <summary>
        /// Cancelled
        /// </summary>
        Removed
    }
}