

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Client-specific network manager interface
    /// </summary>
    public interface INetworkClientManager : INetworkManager
    {
        /// <summary>
        ///     Gets server URI
        /// </summary>
        Uri ServerUri { get; }

        /// <summary>
        ///     Connects to server
        /// </summary>
        Task ConnectAsync(Uri serverUri, string playerName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Disconnects from server
        /// </summary>
        Task DisconnectAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Occurs on server message received
        /// </summary>
        event EventHandler<ServerMessageEventArgs> ServerMessageReceived;
    }
}