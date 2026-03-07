// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;

namespace Alis.Extension.Network.Sample.SimpleChat.Server
{
    /// <summary>
    ///     Simple chat server sample
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     The server manager
        /// </summary>
        private static NetworkServerManager _serverManager;

        /// <summary>
        ///     The server is client
        /// </summary>
        private static bool _serverIsClient;

        /// <summary>
        ///     The server player name
        /// </summary>
        private static string _serverPlayerName;

        /// <summary>
        ///     Main entry point
        /// </summary>
        public static async Task Main(string[] args)
        {
            try
            {
                Console.Clear();
                Logger.Info("╔══════════════════════════════════════════════════════╗");
                Logger.Info("║     ALIS NETWORK - SIMPLE CHAT SERVER SAMPLE         ║");
                Logger.Info("╚══════════════════════════════════════════════════════╝");
                Logger.Info("");

                // Ask if server should participate as a client
                Logger.Log("Should the server also participate in chat? (y/n) [default: n]: ");
                string answer = Console.ReadLine()?.ToLower() ?? "n";
                _serverIsClient = answer.Equals("y") || answer.Equals("yes");
                Logger.Info("");

                // If server is client, ask for player name
                if (_serverIsClient)
                {
                    Logger.Log("Enter server player name: ");
                    _serverPlayerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(_serverPlayerName))
                    {
                        _serverPlayerName = $"Player_{Guid.NewGuid().ToString().Substring(0, 8)}";
                    }

                    Logger.Info("");
                }

                _serverManager = new NetworkServerManager();

                NetworkConfig config = new NetworkConfig
                {
                    MaxPlayers = 32,
                    TickRate = 60,
                    ServerAuthoritative = true
                };

                await _serverManager.InitializeAsync(config);
                Logger.Info("✓ Server initialized");

                NetworkSession session = await _serverManager.CreateSessionAsync("Chat Room", 32);
                Logger.Info($"✓ Session created: {session.SessionName} (Max: {session.MaxPlayers} players)");

                if (_serverIsClient)
                {
                    // Change server name to the player name
                    _serverManager.LocalPlayer.PlayerName = _serverPlayerName;
                    Logger.Info($"📡 Server mode: SERVER + CLIENT (Server nickname: '{_serverPlayerName}')");
                }
                else
                {
                    // Remove server from session if it's not participating as a client
                    session.Players.RemoveAll(p => p.IsHost);
                    session.PlayerCount = session.Players.Count;
                    Logger.Info("📡 Server mode: SERVER ONLY (pure dedicated server)");
                }

                Logger.Info("");

                RegisterHandlers();
                RegisterEvents();

                Uri listenUri = new Uri("ws://127.0.0.1:8888/");
                await _serverManager.StartAsync();
                await _serverManager.ListenAsync(listenUri);

                Logger.Info($"✓ Server listening on {listenUri}");
                Logger.Info("");
                Logger.Info("═══════════════════════════════════════════════════════");
                if (_serverIsClient)
                {
                    Logger.Info("Server Commands:");
                    Logger.Info("  /players  - Show connected players");
                    Logger.Info("  /sessions - Show active sessions");
                    Logger.Info("  /quit     - Stop server");
                    Logger.Info("  Or type a message to broadcast to all clients");
                }
                else
                {
                    Logger.Info("Server Commands:");
                    Logger.Info("  /players  - Show connected players");
                    Logger.Info("  /sessions - Show active sessions");
                    Logger.Info("  /quit     - Stop server");
                }

                Logger.Info("═══════════════════════════════════════════════════════");
                Logger.Info("");

                // Interactive server loop
                while (true)
                {
                    Logger.Log(_serverIsClient ? $"[{_serverPlayerName}]: " : "> ");
                    string input = Console.ReadLine();
                    if (input?.Equals("/quit", StringComparison.OrdinalIgnoreCase) ?? false)
                    {
                        break;
                    }

                    if (input?.Equals("/players", StringComparison.OrdinalIgnoreCase) ?? false)
                    {
                        IReadOnlyList<NetworkPlayer> players = _serverManager.GetConnectedPlayers();
                        Logger.Info($"Connected players: {players.Count}");
                        foreach (NetworkPlayer player in players)
                        {
                            Logger.Log($"  - {player.PlayerName} ({(player.IsHost ? "HOST/SERVER" : "CLIENT")})");
                        }

                        Logger.Info("");
                        continue;
                    }

                    if (input?.Equals("/sessions", StringComparison.OrdinalIgnoreCase) ?? false)
                    {
                        IReadOnlyList<NetworkSession> sessions = _serverManager.GetActiveSessions();
                        Logger.Info($"Active sessions: {sessions.Count}");
                        foreach (NetworkSession s in sessions)
                        {
                            Logger.Log($"  - {s.SessionName}: {s.Players.Count}/{s.MaxPlayers} players");
                        }

                        Logger.Info("");
                        continue;
                    }

                    // If server is in client mode and input is a message, broadcast it
                    if (_serverIsClient && !string.IsNullOrEmpty(input) && !input.StartsWith("/"))
                    {
                        try
                        {
                            ChatMessage chatMessage = new ChatMessage
                            {
                                SenderName = _serverPlayerName,
                                Content = input,
                                Timestamp = DateTime.Now.ToString("HH:mm:ss")
                            };
                            await _serverManager.BroadcastMessageAsync("chat.message", chatMessage);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error($"Error broadcasting message: {ex.Message}");
                        }
                    }

                    await Task.Delay(10);
                }

                Logger.Info("Stopping server...");
                await _serverManager.StopAsync();
                Logger.Info("✓ Server stopped");
            }
            catch (Exception ex)
            {
                Logger.Exception($"Fatal error: {ex.Message}");
            }
        }

        /// <summary>
        ///     Register message handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _serverManager.RegisterMessageHandler("chat.message", OnChatMessage);
            _serverManager.RegisterMessageHandler("system.join", OnPlayerJoin);
        }

        /// <summary>
        ///     Register events
        /// </summary>
        private static void RegisterEvents()
        {
            _serverManager.PlayerJoined += (s, e) =>
            {
                Logger.Info($"→ {e.Player.PlayerName} joined the chat");
                Logger.Log($"   Total players: {_serverManager.GetConnectedPlayers().Count}");
            };

            _serverManager.PlayerLeft += (s, e) =>
            {
                Logger.Info($"← {e.Player.PlayerName} left the chat");
                Logger.Log($"   Total players: {_serverManager.GetConnectedPlayers().Count}");
            };

            _serverManager.Error += (s, e) =>
                Logger.Error($"⚠ Error: {e.Message}");
        }

        /// <summary>
        ///     Handle chat messages and broadcast
        /// </summary>
        private static async Task OnChatMessage(string senderId, string payload)
        {
            try
            {
                Logger.Log($"[CHAT] {payload}");

                // Get the sender player
                NetworkPlayer sender = _serverManager.GetPlayer(senderId);
                if (sender != null)
                {
                    // We need to create a new envelope with the sender's info
                    // Since we're receiving raw payload, we need to reconstruct the message
                    ChatMessage chatMessage = new ChatMessage
                    {
                        SenderName = sender.PlayerName,
                        Content = payload,
                        Timestamp = DateTime.Now.ToString("HH:mm:ss")
                    };

                    // Broadcast to all connected players
                    await _serverManager.BroadcastMessageAsync("chat.message", chatMessage);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error processing message: {ex.Message}");
            }
        }

        /// <summary>
        ///     Handle player join
        /// </summary>
        private static async Task OnPlayerJoin(string senderId, string payload)
        {
            try
            {
                // Extract player ID and name from handshake payload
                string playerId = ExtractJsonField(payload, "playerId");
                string playerName = ExtractJsonField(payload, "playerName");

                if (!string.IsNullOrEmpty(playerId) && !string.IsNullOrEmpty(playerName))
                {
                    _serverManager.RegisterPlayerInSession(playerId, playerName);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error processing join: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Extract JSON field value
        /// </summary>
        private static string ExtractJsonField(string json, string fieldName)
        {
            try
            {
                string search = $"\"{fieldName}\":\"";
                int startIndex = json.IndexOf(search);
                if (startIndex == -1)
                {
                    return null;
                }

                startIndex += search.Length;
                int endIndex = json.IndexOf("\"", startIndex);
                if (endIndex == -1)
                {
                    return null;
                }

                return json.Substring(startIndex, endIndex - startIndex);
            }
            catch
            {
                return null;
            }
        }
    }
}