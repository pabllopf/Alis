

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Abstract transport layer for network communication
    /// </summary>
    public interface INetworkTransport : IDisposable
    {
        /// <summary>
        ///     Gets transport state
        /// </summary>
        NetworkTransportState State { get; }

        /// <summary>
        ///     Sends message to specific client
        /// </summary>
        Task SendAsync(string clientId, NetworkMessageEnvelope message, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Broadcasts message to all clients
        /// </summary>
        Task BroadcastAsync(NetworkMessageEnvelope message, string exceptClientId = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Receives next message from transport
        /// </summary>
        Task<(string ClientId, NetworkMessageEnvelope Message)> ReceiveAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Starts transport listener
        /// </summary>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Stops transport listener
        /// </summary>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}