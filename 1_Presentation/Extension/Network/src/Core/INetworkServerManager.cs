

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     Server-specific network manager interface
    /// </summary>
    public interface INetworkServerManager : INetworkManager
    {
        /// <summary>
        ///     Gets listening URI
        /// </summary>
        Uri ListenUri { get; }

        /// <summary>
        ///     Starts listening for connections
        /// </summary>
        Task ListenAsync(Uri address, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Stops listening
        /// </summary>
        Task StopListeningAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Creates a session
        /// </summary>
        Task<NetworkSession> CreateSessionAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Gets session by ID
        /// </summary>
        NetworkSession GetSession(string sessionId);

        /// <summary>
        ///     Gets all active sessions
        /// </summary>
        IReadOnlyList<NetworkSession> GetActiveSessions();

        /// <summary>
        ///     Closes session
        /// </summary>
        Task CloseSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Kicks player from session
        /// </summary>
        Task KickPlayerAsync(string playerId, string sessionId, string reason = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Occurs when client connects
        /// </summary>
        event EventHandler<ClientConnectionEventArgs> ClientConnected;

        /// <summary>
        ///     Occurs when client disconnects
        /// </summary>
        event EventHandler<ClientDisconnectionEventArgs> ClientDisconnected;
    }
}