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
    /// The network server manager class
    /// </summary>
    /// <seealso cref="INetworkServerManager"/>
    public sealed class NetworkServerManager : INetworkServerManager
    {



        /// <summary>
        /// The client to session map
        /// </summary>
        private readonly ConcurrentDictionary<string, string> _clientToSessionMap;




        /// <summary>
        /// The id
        /// </summary>
        private readonly string _id;




        /// <summary>
        /// The lock object
        /// </summary>
        private readonly object _lockObject = new object();




        /// <summary>
        /// The message handlers
        /// </summary>
        private readonly ConcurrentDictionary<string, Func<string, string, Task>> _messageHandlers;




        /// <summary>
        /// The sessions
        /// </summary>
        private readonly ConcurrentDictionary<string, NetworkSession> _sessions;




        /// <summary>
        /// The cancellation token source
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;




        /// <summary>
        /// The config
        /// </summary>
        private NetworkConfig _config;




        /// <summary>
        /// The current session
        /// </summary>
        private NetworkSession _currentSession;




        /// <summary>
        /// The is disposed
        /// </summary>
        private bool _isDisposed;




        /// <summary>
        /// The listen uri
        /// </summary>
        private Uri _listenUri;




        /// <summary>
        /// The local player
        /// </summary>
        private NetworkPlayer _localPlayer;




        /// <summary>
        /// The serializer
        /// </summary>
        private INetworkSerializer _serializer;




        /// <summary>
        /// The uninitialized
        /// </summary>
        private NetworkManagerState _state = NetworkManagerState.Uninitialized;




        /// <summary>
        /// The transport
        /// </summary>
        private INetworkTransport _transport;




        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkServerManager"/> class
        /// </summary>
        public NetworkServerManager()
        {
            _id = Guid.NewGuid().ToString();
            _messageHandlers = new ConcurrentDictionary<string, Func<string, string, Task>>();
            _sessions = new ConcurrentDictionary<string, NetworkSession>();
            _clientToSessionMap = new ConcurrentDictionary<string, string>();
        }




        /// <summary>
        /// Gets the value of the id
        /// </summary>
        public string Id => _id;




        /// <summary>
        /// Gets the value of the state
        /// </summary>
        public NetworkManagerState State => _state;




        /// <summary>
        /// Gets the value of the current session
        /// </summary>
        public NetworkSession CurrentSession => _currentSession;




        /// <summary>
        /// Gets the value of the local player
        /// </summary>
        public NetworkPlayer LocalPlayer => _localPlayer;




        /// <summary>
        /// Gets the value of the config
        /// </summary>
        public NetworkConfig Config => _config;




        /// <summary>
        /// Gets the value of the listen uri
        /// </summary>
        public Uri ListenUri => _listenUri;




        public event EventHandler<PlayerEventArgs> PlayerJoined;




        public event EventHandler<PlayerEventArgs> PlayerLeft;




        public event EventHandler<EventArgs> Connected;




        public event EventHandler<EventArgs> Disconnected;




        public event EventHandler<NetworkErrorEventArgs> Error;




        public event EventHandler<ClientConnectionEventArgs> ClientConnected;




        public event EventHandler<ClientDisconnectionEventArgs> ClientDisconnected;




        /// <summary>
        /// Initializes the config
        /// </summary>
        /// <param name="config">The config</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="InvalidOperationException">Already initialized</exception>
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
        /// Starts the cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="InvalidOperationException">Cannot start in current state</exception>
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
        /// Stops the cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        public async Task StopAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await StopListeningAsync(cancellationToken);
        }




        /// <summary>
        /// Listens the address
        /// </summary>
        /// <param name="address">The address</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="InvalidOperationException">Cannot listen in current state</exception>
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
        /// Stops the listening using the specified cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
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
                if (_cancellationTokenSource != null)
                {
                    #if NET8_0_OR_GREATER
                    await _cancellationTokenSource.CancelAsync();
                    #else
                    _cancellationTokenSource.Cancel();
                    #endif
                }
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
        /// Creates the session using the specified session name
        /// </summary>
        /// <param name="sessionName">The session name</param>
        /// <param name="maxPlayers">The max players</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the network session</returns>
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
        /// Gets the session using the specified session id
        /// </summary>
        /// <param name="sessionId">The session id</param>
        /// <returns>The session</returns>
        public NetworkSession GetSession(string sessionId)
        {
            _sessions.TryGetValue(sessionId, out NetworkSession session);
            return session;
        }




        /// <summary>
        /// Gets the active sessions
        /// </summary>
        /// <returns>A read only list of network session</returns>
        public IReadOnlyList<NetworkSession> GetActiveSessions()
        {
            return _sessions.Values.Where(s => s.State != SessionState.Closed).ToList();
        }




        /// <summary>
        /// Closes the session using the specified session id
        /// </summary>
        /// <param name="sessionId">The session id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public async Task CloseSessionAsync(string sessionId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_sessions.TryGetValue(sessionId, out NetworkSession session))
            {
                session.State = SessionState.Closed;
            }

            await Task.CompletedTask;
        }




        /// <summary>
        /// Kicks the player using the specified player id
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="sessionId">The session id</param>
        /// <param name="reason">The reason</param>
        /// <param name="cancellationToken">The cancellation token</param>
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
        /// Sends the message using the specified target player id
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="targetPlayerId">The target player id</param>
        /// <param name="channel">The channel</param>
        /// <param name="message">The message</param>
        /// <param name="reliable">The reliable</param>
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
        /// Broadcasts the message using the specified channel
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="channel">The channel</param>
        /// <param name="message">The message</param>
        /// <param name="reliable">The reliable</param>
        /// <param name="exceptPlayerId">The except player id</param>
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


            await _transport.BroadcastAsync(envelope);
        }




        /// <summary>
        /// Registers the message handler using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        /// <param name="handler">The handler</param>
        public void RegisterMessageHandler(string channel, Func<string, string, Task> handler)
        {
            _messageHandlers.AddOrUpdate(channel, handler, (key, old) => handler);
        }




        /// <summary>
        /// Unregisters the message handler using the specified channel
        /// </summary>
        /// <param name="channel">The channel</param>
        public void UnregisterMessageHandler(string channel)
        {
            _messageHandlers.TryRemove(channel, out _);
        }




        /// <summary>
        /// Gets the connected players
        /// </summary>
        /// <returns>A read only list of network player</returns>
        public IReadOnlyList<NetworkPlayer> GetConnectedPlayers() => _currentSession?.Players ?? new List<NetworkPlayer>();




        /// <summary>
        /// Gets the player using the specified player id
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <returns>The network player</returns>
        public NetworkPlayer GetPlayer(string playerId)
        {
            return _currentSession?.Players.Find(p => p.PlayerId == playerId);
        }




        /// <summary>
        /// Disposes this instance
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
                // Swallow exception during dispose
            }

            _cancellationTokenSource?.Dispose();
            _transport?.Dispose();
            GC.SuppressFinalize(this);
        }




        /// <summary>
        /// Registers the player in session using the specified player id
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="playerName">The player name</param>
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
        /// Processes the messages using the specified cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        private async Task ProcessMessagesAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    (_, NetworkMessageEnvelope message) = await _transport.ReceiveAsync(cancellationToken);

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