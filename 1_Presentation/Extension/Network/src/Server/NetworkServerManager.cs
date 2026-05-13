// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NetworkServerManager.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Server
{
    /// <summary>
    ///     Server-side network manager implementation
    /// </summary>
    public class NetworkServerManager : INetworkServerManager
    {
        /// <summary>
        ///     The client to session map
        /// </summary>
        private readonly ConcurrentDictionary<string, string> _clientToSessionMap;

        /// <summary>
        ///     The id
        /// </summary>
        private readonly string _id;

        /// <summary>
        ///     The lock object
        /// </summary>
        private readonly object _lockObject = new object();

        /// <summary>
        ///     The message handlers
        /// </summary>
        private readonly ConcurrentDictionary<string, Func<string, string, Task>> _messageHandlers;

        /// <summary>
        ///     The sessions
        /// </summary>
        private readonly ConcurrentDictionary<string, NetworkSession> _sessions;

        /// <summary>
        ///     The cancellation token source
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        ///     The config
        /// </summary>
        private NetworkConfig _config;

        /// <summary>
        ///     The current session
        /// </summary>
        private NetworkSession _currentSession;

        /// <summary>
        ///     The is disposed
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        ///     The listen uri
        /// </summary>
        private Uri _listenUri;

        /// <summary>
        ///     The local player
        /// </summary>
        private NetworkPlayer _localPlayer;

        /// <summary>
        ///     The serializer
        /// </summary>
        private INetworkSerializer _serializer;

        /// <summary>
        ///     The uninitialized
        /// </summary>
        private NetworkManagerState _state = NetworkManagerState.Uninitialized;

        /// <summary>
        ///     The transport
        /// </summary>
        private INetworkTransport _transport;

        /// <summary>
        ///     Initializes server manager
        /// </summary>
        public NetworkServerManager()
        {
            _id = Guid.NewGuid().ToString();
            _messageHandlers = new ConcurrentDictionary<string, Func<string, string, Task>>();
            _sessions = new ConcurrentDictionary<string, NetworkSession>();
            _clientToSessionMap = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        ///     Gets manager identifier
        /// </summary>
        public string Id => _id;

        /// <summary>
        ///     Gets current network state
        /// </summary>
        public NetworkManagerState State => _state;

        /// <summary>
        ///     Gets current session
        /// </summary>
        public NetworkSession CurrentSession => _currentSession;

        /// <summary>
        ///     Gets local player (server)
        /// </summary>
        public NetworkPlayer LocalPlayer => _localPlayer;

        /// <summary>
        ///     Gets configuration
        /// </summary>
        public NetworkConfig Config => _config;

        /// <summary>
        ///     Gets listening URI
        /// </summary>
        public Uri ListenUri => _listenUri;

        /// <summary>
        ///     Player joined event
        /// </summary>
        public event EventHandler<PlayerEventArgs> PlayerJoined;

        /// <summary>
        ///     Player left event
        /// </summary>
        public event EventHandler<PlayerEventArgs> PlayerLeft;

        /// <summary>
        ///     Connected event
        /// </summary>
        public event EventHandler<EventArgs> Connected;

        /// <summary>
        ///     Disconnected event
        /// </summary>
        public event EventHandler<EventArgs> Disconnected;

        /// <summary>
        ///     Error event
        /// </summary>
        public event EventHandler<NetworkErrorEventArgs> Error;

        /// <summary>
        ///     Client connected event
        /// </summary>
        public event EventHandler<ClientConnectionEventArgs> ClientConnected;

        /// <summary>
        ///     Client disconnected event
        /// </summary>
        public event EventHandler<ClientDisconnectionEventArgs> ClientDisconnected;

        /// <summary>
        ///     Initializes manager
        /// </summary>
        public async Task InitializeAsync(NetworkConfig config, CancellationToken cancellationToken = default(CancellationToken))
        {
            lock (_lockObject)
            {
                if (_state != NetworkManagerState.Uninitialized)
                {
                    throw new InvalidOperationException("Already initialized");
                }

                _state = NetworkManagerState.Idle;
                _config = config ?? new NetworkConfig();
                _serializer = new NetworkSerializer();

                _localPlayer = new NetworkPlayer
                {
                    PlayerId = Guid.NewGuid().ToString(),
                    PlayerName = "Server",
                    IsHost = true,
                    ConnectionState = PlayerConnectionState.Connected,
                    JoinedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                };
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Starts manager
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            lock (_lockObject)
            {
                if ((_state != NetworkManagerState.Idle) && (_state != NetworkManagerState.Disconnected))
                {
                    throw new InvalidOperationException("Cannot start in current state");
                }
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Stops manager
        /// </summary>
        public async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await StopListeningAsync(cancellationToken);
        }

        /// <summary>
        ///     Starts listening for connections
        /// </summary>
        public async Task ListenAsync(Uri address, CancellationToken cancellationToken = default(CancellationToken))
        {
            lock (_lockObject)
            {
                if ((_state != NetworkManagerState.Idle) && (_state != NetworkManagerState.Disconnected))
                {
                    throw new InvalidOperationException("Cannot listen in current state");
                }

                _state = NetworkManagerState.Connecting;
            }

            try
            {
                _listenUri = address;
                _transport = new WebSocketNetworkTransport(address);
                _cancellationTokenSource = new CancellationTokenSource();

                await _transport.StartAsync(cancellationToken);

                lock (_lockObject)
                {
                    _state = NetworkManagerState.Connected;
                }

                Connected?.Invoke(this, EventArgs.Empty);
                _ = ProcessMessagesAsync(_cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                lock (_lockObject)
                {
                    _state = NetworkManagerState.Error;
                }

                Error?.Invoke(this, new NetworkErrorEventArgs("Failed to start listening", ex));
                throw;
            }
        }

        /// <summary>
        ///     Stops listening
        /// </summary>
        public async Task StopListeningAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            lock (_lockObject)
            {
                if (_state == NetworkManagerState.Disconnected || _state == NetworkManagerState.Uninitialized)
                {
                    return;
                }

                _state = NetworkManagerState.Disconnecting;
            }

            try
            {
                _cancellationTokenSource?.Cancel();
                if (_transport != null)
                {
                    await _transport.StopAsync(cancellationToken);
                }

                lock (_lockObject)
                {
                    _state = NetworkManagerState.Disconnected;
                }

                Disconnected?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new NetworkErrorEventArgs("Error during stop listening", ex));
            }
        }

        /// <summary>
        ///     Creates a session
        /// </summary>
        public async Task<NetworkSession> CreateSessionAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default(CancellationToken))
        {
            NetworkSession session = new NetworkSession
            {
                SessionId = Guid.NewGuid().ToString(),
                SessionName = sessionName,
                OwnerId = _localPlayer.PlayerId,
                MaxPlayers = maxPlayers,
                State = SessionState.Waiting,
                CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                PlayerCount = 1
            };

            session.Players.Add(_localPlayer);
            _sessions.TryAdd(session.SessionId, session);
            _currentSession = session;

            return await Task.FromResult(session);
        }

        /// <summary>
        ///     Gets session by ID
        /// </summary>
        public NetworkSession GetSession(string sessionId)
        {
            _sessions.TryGetValue(sessionId, out NetworkSession session);
            return session;
        }

        /// <summary>
        ///     Gets all active sessions
        /// </summary>
        public IReadOnlyList<NetworkSession> GetActiveSessions()
        {
            return _sessions.Values.Where(s => s.State != SessionState.Closed).ToList();
        }

        /// <summary>
        ///     Closes session
        /// </summary>
        public async Task CloseSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_sessions.TryGetValue(sessionId, out NetworkSession session))
            {
                session.State = SessionState.Closed;
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Kicks player from session
        /// </summary>
        public async Task KickPlayerAsync(string playerId, string sessionId, string reason = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_sessions.TryGetValue(sessionId, out NetworkSession session))
            {
                NetworkPlayer player = session.Players.FirstOrDefault(p => p.PlayerId == playerId);
                if (player != null)
                {
                    session.Players.Remove(player);
                    PlayerLeft?.Invoke(this, new PlayerEventArgs(player));
                }
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Sends message to specific player
        /// </summary>
        public async Task SendMessageAsync<T>(string targetPlayerId, string channel, T message, bool reliable = true) where T : IJsonSerializable
        {
            string payload = _serializer.Serialize(message);
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = typeof(T).Name,
                SenderId = _localPlayer?.PlayerId,
                TargetId = targetPlayerId,
                Channel = channel,
                Payload = payload,
                ServerTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                IsReliable = reliable,
                SequenceNumber = (uint) (DateTime.UtcNow.Ticks % uint.MaxValue)
            };

            if (_clientToSessionMap.TryGetValue(targetPlayerId, out string clientId))
            {
                await _transport.SendAsync(clientId, envelope);
            }
        }

        /// <summary>
        ///     Broadcasts message to all players
        /// </summary>
        public async Task BroadcastMessageAsync<T>(string channel, T message, bool reliable = true, string exceptPlayerId = null) where T : IJsonSerializable
        {
            string payload = _serializer.Serialize(message);
            NetworkMessageEnvelope envelope = new NetworkMessageEnvelope
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = typeof(T).Name,
                SenderId = _localPlayer?.PlayerId,
                TargetId = null,
                Channel = channel,
                Payload = payload,
                ServerTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                IsReliable = reliable,
                SequenceNumber = (uint) (DateTime.UtcNow.Ticks % uint.MaxValue)
            };

            // Broadcast to all connected clients through transport
            await _transport.BroadcastAsync(envelope);
        }

        /// <summary>
        ///     Registers message handler
        /// </summary>
        public void RegisterMessageHandler(string channel, Func<string, string, Task> handler)
        {
            _messageHandlers.AddOrUpdate(channel, handler, (key, old) => handler);
        }

        /// <summary>
        ///     Unregisters message handler
        /// </summary>
        public void UnregisterMessageHandler(string channel)
        {
            _messageHandlers.TryRemove(channel, out _);
        }

        /// <summary>
        ///     Gets connected players
        /// </summary>
        public IReadOnlyList<NetworkPlayer> GetConnectedPlayers() => _currentSession?.Players ?? new List<NetworkPlayer>();

        /// <summary>
        ///     Gets player by ID
        /// </summary>
        public NetworkPlayer GetPlayer(string playerId)
        {
            return _currentSession?.Players.Find(p => p.PlayerId == playerId);
        }

        /// <summary>
        ///     Disposes manager
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

            try
            {
                StopListeningAsync().Wait(TimeSpan.FromSeconds(5));
            }
            catch (Exception)
            {
                // Ignore disposal errors
            }

            _cancellationTokenSource?.Dispose();
            _transport?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Registers a player in the session
        /// </summary>
        public void RegisterPlayerInSession(string playerId, string playerName)
        {
            if (_currentSession != null)
            {
                NetworkPlayer player = new NetworkPlayer
                {
                    PlayerId = playerId,
                    PlayerName = playerName,
                    ConnectionState = PlayerConnectionState.Connected,
                    JoinedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                };

                if (!_currentSession.Players.Exists(p => p.PlayerId == playerId))
                {
                    _currentSession.Players.Add(player);
                    _currentSession.PlayerCount = _currentSession.Players.Count;
                }

                PlayerJoined?.Invoke(this, new PlayerEventArgs(player));
            }
        }

        /// <summary>
        ///     Processes messages from transport
        /// </summary>
        private async Task ProcessMessagesAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    (string clientId, NetworkMessageEnvelope message) = await _transport.ReceiveAsync(cancellationToken);

                    if (_messageHandlers.TryGetValue(message.Channel, out Func<string, string, Task> handler))
                    {
                        await handler(message.SenderId, message.Payload);
                    }
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new NetworkErrorEventArgs("Error processing messages", ex));
            }
        }
    }
}