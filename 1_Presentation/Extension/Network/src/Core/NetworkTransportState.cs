namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Transport state enumeration
    /// </summary>
    public enum NetworkTransportState
    {
        /// <summary>
        ///     Not connected
        /// </summary>
        Disconnected,

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
        Disconnecting
    }
}