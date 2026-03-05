namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Player connection state enumeration
    /// </summary>
    public enum PlayerConnectionState
    {
        /// <summary>
        ///     Player connected
        /// </summary>
        Connected,

        /// <summary>
        ///     Player idle
        /// </summary>
        Idle,

        /// <summary>
        ///     Player disconnected
        /// </summary>
        Disconnected,

        /// <summary>
        ///     Player timeout
        /// </summary>
        Timeout
    }
}