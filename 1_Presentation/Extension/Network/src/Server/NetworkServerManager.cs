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
using System.Collections.Generic;
using System.Collections.Concurrent;
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
    public class NetworkServerManager : Core.INetworkServerManager
    {
        /// <summary>
        /// The id
        /// </summary>
        private string _id;
        /// <summary>
        /// The uninitialized
        /// </summary>
        private NetworkManagerState _state = NetworkManagerState.Uninitialized;
        /// <summary>
        /// The config
        /// </summary>
        private NetworkConfig _config;
        /// <summary>
        /// The current session
        /// </summary>
        private NetworkSession _currentSession;
        /// <summary>
        /// The local player
        /// </summary>
        private NetworkPlayer _localPlayer;
        /// <summary>
        /// The serializer
        /// </summary>
        private INetworkSerializer _serializer;
        /// <summary>
        /// The transport
        /// </summary>
        private INetworkTransport _transport;
        /// <summary>
        /// The listen uri
        /// </summary>
        private Uri _listenUri;
        /// <summary>
        /// The cancellation token source
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;
        /// <summary>
        /// The message handlers
        /// </summary>
        private readonly ConcurrentDictionary<string, Func<string, string, Task>> _messageHandlers;
        /// <summary>
        /// The sessions
        /// </summary>
        private readonly ConcurrentDictionary<string, NetworkSession> _sessions;
        /// <summary>
        /// The client to session map
        /// </summary>
        private readonly ConcurrentDictionary<string, string> _clientToSessionMap;
        /// <summary>
        /// The lock object
        /// </summary>
        private readonly object _lockObject = new object();
        /// <summary>
        /// The is disposed
        /// </summary>
        private bool _isDisposed;

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
        public event EventHandler<Core.PlayerEventArgs> PlayerJoined;

        /// <summary>
        ///     Player left event
        /// </summary>
        public event EventHandler<Core.PlayerEventArgs> PlayerLeft;

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
        public event EventHandler<Core.NetworkErrorEventArgs> Error;

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
        public async Task InitializeAsync(Core.NetworkConfig config, CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state != Core.NetworkManagerState.Uninitialized)
                    throw new InvalidOperationException("Already initialized");

                _state = Core.NetworkManagerState.Idle;
                _config = config ?? new Core.NetworkConfig();
                _serializer = new Core.NetworkSerializer();

                _localPlayer = new Core.NetworkPlayer
                {
                    PlayerId = Guid.NewGuid().ToString(),
                    PlayerName = "Server",
                    IsHost = true,
                    ConnectionState = Core.PlayerConnectionState.Connected,
                    JoinedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                };
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Starts manager
        /// </summary>
        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state != Core.NetworkManagerState.Idle && _state != Core.NetworkManagerState.Disconnected)
                    throw new InvalidOperationException("Cannot start in current state");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Stops manager
        /// </summary>
        public async Task StopAsync(CancellationToken cancellationToken = default)
        {
            await StopListeningAsync(cancellationToken);
        }

        /// <summary>
        ///     Starts listening for connections
        /// </summary>
        public async Task ListenAsync(Uri address, CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state != NetworkManagerState.Idle && _state != NetworkManagerState.Disconnected)
                    throw new InvalidOperationException("Cannot listen in current state");

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
        public async Task StopListeningAsync(CancellationToken cancellationToken = default)
        {
            lock (_lockObject)
            {
                if (_state == Core.NetworkManagerState.Disconnected || _state == Core.NetworkManagerState.Uninitialized)
                    return;

                _state = Core.NetworkManagerState.Disconnecting;
            }

            try
            {
                _cancellationTokenSource?.Cancel();
                await _transport?.StopAsync(cancellationToken);

                lock (_lockObject)
                {
                    _state = Core.NetworkManagerState.Disconnected;
                }

                Disconnected?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new Core.NetworkErrorEventArgs("Error during stop listening", ex));
            }
        }

        /// <summary>
        ///     Creates a session
        /// </summary>
        public async Task<Core.NetworkSession> CreateSessionAsync(string sessionName, int maxPlayers, CancellationToken cancellationToken = default)
        {
            var session = new Core.NetworkSession
            {
                SessionId = Guid.NewGuid().ToString(),
                SessionName = sessionName,
                OwnerId = _localPlayer.PlayerId,
                MaxPlayers = maxPlayers,
                State = Core.SessionState.Waiting,
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
        public Core.NetworkSession GetSession(string sessionId)
        {
            _sessions.TryGetValue(sessionId, out var session);
            return session;
        }

        /// <summary>
        ///     Gets all active sessions
        /// </summary>
        public IReadOnlyList<Core.NetworkSession> GetActiveSessions()
        {
            return _sessions.Values.Where(s => s.State != Core.SessionState.Closed).ToList();
        }

        /// <summary>
        ///     Closes session
        /// </summary>
        public async Task CloseSessionAsync(string sessionId, CancellationToken cancellationToken = default)
        {
            if (_sessions.TryGetValue(sessionId, out var session))
            {
                session.State = Core.SessionState.Closed;
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Kicks player from session
        /// </summary>
        public async Task KickPlayerAsync(string playerId, string sessionId, string reason = null, CancellationToken cancellationToken = default)
        {
            if (_sessions.TryGetValue(sessionId, out var session))
            {
                var player = session.Players.FirstOrDefault(p => p.PlayerId == playerId);
                if (player != null)
                {
                    session.Players.Remove(player);
                    PlayerLeft?.Invoke(this, new Core.PlayerEventArgs(player));
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
            var envelope = new Core.NetworkMessageEnvelope
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = typeof(T).Name,
                SenderId = _localPlayer?.PlayerId,
                TargetId = targetPlayerId,
                Channel = channel,
                Payload = payload,
                ServerTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                IsReliable = reliable,
                SequenceNumber = (uint)(DateTime.UtcNow.Ticks % uint.MaxValue)
            };

            if (_clientToSessionMap.TryGetValue(targetPlayerId, out string clientId))
            {
                await _transport.SendAsync(clientId, envelope);
            }
        }

        /// <summary>
        ///     Broadcasts message
        /// </summary>
        public async Task BroadcastMessageAsync<T>(string channel, T message, bool reliable = true, string exceptPlayerId = null) where T : IJsonSerializable
        {
            string payload = _serializer.Serialize(message);
            var envelope = new Core.NetworkMessageEnvelope
            {
                MessageId = Guid.NewGuid().ToString(),
                MessageType = typeof(T).Name,
                SenderId = _localPlayer?.PlayerId,
                TargetId = null,
                Channel = channel,
                Payload = payload,
                ServerTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                IsReliable = reliable,
                SequenceNumber = (uint)(DateTime.UtcNow.Ticks % uint.MaxValue)
            };

            string exceptClientId = null;
            if (exceptPlayerId != null)
            {
                _clientToSessionMap.TryGetValue(exceptPlayerId, out exceptClientId);
            }

            await _transport.BroadcastAsync(envelope, exceptClientId);
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
        public IReadOnlyList<Core.NetworkPlayer> GetConnectedPlayers()
        {
            return _currentSession?.Players ?? new List<Core.NetworkPlayer>();
        }

        /// <summary>
        ///     Gets player by ID
        /// </summary>
        public Core.NetworkPlayer GetPlayer(string playerId)
        {
            return _currentSession?.Players.Find(p => p.PlayerId == playerId);
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
                    var (clientId, message) = await _transport.ReceiveAsync(cancellationToken);

                    if (_messageHandlers.TryGetValue(message.Channel, out var handler))
                    {
                        await handler(message.SenderId, message.Payload);
                    }
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new Core.NetworkErrorEventArgs("Error processing messages", ex));
            }
        }

        /// <summary>
        ///     Disposes manager
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
                return;

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
    }
}

