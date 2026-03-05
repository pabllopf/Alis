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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Sample.SimpleChat.Client
{
    /// <summary>
    ///     Simple chat client sample
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The client manager
        /// </summary>
        private static NetworkClientManager _clientManager;
        /// <summary>
        /// The player name
        /// </summary>
        private static string _playerName;
        /// <summary>
        /// The connected
        /// </summary>
        private static bool _connected = false;

        /// <summary>
        ///     Main entry point
        /// </summary>
        public static async Task Main(string[] args)
        {
            try
            {
                Console.Clear();
                Logger.Info("╔══════════════════════════════════════════════════════╗");
                Logger.Info("║     ALIS NETWORK - SIMPLE CHAT CLIENT SAMPLE         ║");
                Logger.Info("╚══════════════════════════════════════════════════════╝");
                Logger.Info("");

                _clientManager = new NetworkClientManager();

                NetworkConfig config = new NetworkConfig
                {
                    MaxPlayers = 32,
                    TickRate = 60,
                    ServerAuthoritative = true
                };

                await _clientManager.InitializeAsync(config);
                Logger.Info("✓ Client initialized");

                RegisterHandlers();
                RegisterEvents();

                await _clientManager.StartAsync();

                // Get player name
                Logger.Log("Enter your player name: ");
                _playerName = Console.ReadLine();
                if (string.IsNullOrEmpty(_playerName))
                    _playerName = $"Player_{Guid.NewGuid().ToString().Substring(0, 8)}";

                // Connect to server
                Uri serverUri = new Uri("ws://127.0.0.1:8888/");
                Logger.Info($"Connecting to {serverUri} as '{_playerName}'...");

                try
                {
                    await _clientManager.ConnectAsync(serverUri, _playerName);
                    _connected = true;
                    Logger.Info("✓ Connected to server!");
                    Logger.Info("");
                    Logger.Info("═══════════════════════════════════════════════════════");
                    Logger.Info("Type messages and press Enter to send");
                    Logger.Info("Type '/quit' to exit");
                    Logger.Info("═══════════════════════════════════════════════════════");
                    Logger.Info("");

                    await ChatLoopAsync();
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to connect: {ex.Message}");
                }

                if (_connected)
                {
                    await _clientManager.DisconnectAsync();
                }

                Logger.Info("✓ Client closed");
            }
            catch (Exception ex)
            {
                Logger.Exception($"Fatal error: {ex.Message}");
            }
        }

        /// <summary>
        ///     Chat loop - handles user input
        /// </summary>
        private static async Task ChatLoopAsync()
        {
            while (_connected)
            {
                try
                {
                    Logger.Log($"[{_playerName}]: ");
                    string message = Console.ReadLine();

                    if (string.IsNullOrEmpty(message))
                        continue;

                    if (message.Equals("/quit", StringComparison.OrdinalIgnoreCase))
                    {
                        _connected = false;
                        break;
                    }

                    ChatMessage chatMessage = new ChatMessage
                    {
                        SenderName = _playerName,
                        Content = message,
                        Timestamp = DateTime.Now.ToString("HH:mm:ss")
                    };

                    await _clientManager.BroadcastMessageAsync("chat.message", chatMessage);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error sending message: {ex.Message}");
                    _connected = false;
                }

                await Task.Delay(10);
            }
        }

        /// <summary>
        ///     Register message handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _clientManager.RegisterMessageHandler("chat.message", OnChatMessage);
            _clientManager.RegisterMessageHandler("chat.notification", OnNotification);
        }

        /// <summary>
        ///     Register events
        /// </summary>
        private static void RegisterEvents()
        {
            _clientManager.PlayerJoined += (s, e) =>
                Logger.Info($"→ {e.Player.PlayerName} joined the chat");

            _clientManager.PlayerLeft += (s, e) =>
                Logger.Info($"← {e.Player.PlayerName} left the chat");

            _clientManager.Connected += (s, e) =>
                Logger.Info("✓ Connected to server");

            _clientManager.Disconnected += (s, e) =>
            {
                Logger.Info("✗ Disconnected from server");
                _connected = false;
            };

            _clientManager.Error += (s, e) =>
                Logger.Error($"⚠ Error: {e.Message}");
        }

        /// <summary>
        ///     Handle incoming chat messages
        /// </summary>
        private static async Task OnChatMessage(string senderId, string payload)
        {
            try
            {
                // Try to parse JSON to extract message details
                // Format: {"SenderName":"name","Content":"message","Timestamp":"HH:mm:ss"}
                
                // Simple JSON parsing to extract fields
                string senderName = ExtractJsonField(payload, "SenderName");
                string content = ExtractJsonField(payload, "Content");
                string timestamp = ExtractJsonField(payload, "Timestamp");

                if (!string.IsNullOrEmpty(senderName) && !string.IsNullOrEmpty(content))
                {
                    Logger.Info($"[{senderName}] ({timestamp ?? ""}): {content}");
                }
                else
                {
                    // Fallback if parsing fails
                    Logger.Log($"[MESSAGE] {payload}");
                }
            }
            catch
            {
                // Fallback display
                Logger.Log($"[MESSAGE] {payload}");
            }
            await Task.CompletedTask;
        }

        /// <summary>
        ///     Extract value from JSON field
        /// </summary>
        private static string ExtractJsonField(string json, string fieldName)
        {
            try
            {
                string search = $"\"{fieldName}\":\"";
                int startIndex = json.IndexOf(search);
                if (startIndex == -1)
                    return null;

                startIndex += search.Length;
                int endIndex = json.IndexOf("\"", startIndex);
                if (endIndex == -1)
                    return null;

                return json.Substring(startIndex, endIndex - startIndex);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Handle notifications
        /// </summary>
        private static async Task OnNotification(string senderId, string payload)
        {
            Logger.Info($"[NOTIFICATION] {payload}");
            await Task.CompletedTask;
        }
    }
}

