namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Session state enumeration
    /// </summary>
    public enum SessionState
    {
        /// <summary>
        ///     Waiting for players
        /// </summary>
        Waiting,

        /// <summary>
        ///     Game in progress
        /// </summary>
        InProgress,

        /// <summary>
        ///     Game finished
        /// </summary>
        Finished,

        /// <summary>
        ///     Session closed
        /// </summary>
        Closed
    }
}