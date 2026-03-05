namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Network manager state enumeration
    /// </summary>
    public enum NetworkManagerState
    {
        /// <summary>
        ///     Not initialized
        /// </summary>
        Uninitialized,

        /// <summary>
        ///     Initialized but not running
        /// </summary>
        Idle,

        /// <summary>
        ///     Connecting
        /// </summary>
        Connecting,

        /// <summary>
        ///     Connected
        /// </summary>
        Connected,

        /// <summary>
        ///     Disconnecting
        /// </summary>
        Disconnecting,

        /// <summary>
        ///     Disconnected
        /// </summary>
        Disconnected,

        /// <summary>
        ///     Error state
        /// </summary>
        Error
    }
}