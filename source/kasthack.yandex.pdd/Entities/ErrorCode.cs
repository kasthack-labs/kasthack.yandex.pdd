namespace kasthack.yandex.pdd.Entities
{
    /// <summary>
    /// Error code
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Unknown error
        /// </summary>
        Unknown,
        /// <summary>
        /// Token has not been provided
        /// </summary>
        NoToken,
        /// <summary>
        /// Invalid domain
        /// </summary>
        BadDomain,
        /// <summary>
        /// Prohibited
        /// </summary>
        Prohibited,
        /// <summary>
        /// Invalid token
        /// </summary>
        BadToken,
        /// <summary>
        /// Auth has not been provided
        /// </summary>
        NoAuth,
        /// <summary>
        /// Not allowed
        /// </summary>
        NotAllowed,
        /// <summary>
        /// Blocked
        /// </summary>
        Blocked,
        /// <summary>
        /// Address is already occupied
        /// </summary>
        Occupied,
        /// <summary>
        /// Domain limit reached
        /// </summary>
        DomainLimitReached,
        /// <summary>
        /// Failed to get reply
        /// </summary>
        NoReply,
        /// <summary>
        /// Invalid UI
        /// </summary>
        BadUid,
        /// <summary>
        /// Invalid login
        /// </summary>
        BadLogin,
        /// <summary>
        /// Invalid password
        /// </summary>
        BadPasswd,
        /// <summary>
        /// Domain has not been provided
        /// </summary>
        NoDomain,
        NoIp
    }
}