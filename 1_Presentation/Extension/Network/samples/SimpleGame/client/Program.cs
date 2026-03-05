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
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Sample.SimpleGame.Client
{
    /// <summary>
    ///     Simple multiplayer game client (console-based arena)
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
        /// Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static async Task Main(string[] args)
        {
            try
            {
                Console.Clear();
                Logger.Info("╔══════════════════════════════════════════════════════╗");
                Logger.Info("║     ALIS NETWORK - SIMPLE GAME CLIENT SAMPLE         ║");
                Logger.Info("║     Console-Based Arena Battle System                ║");
                Logger.Info("╚══════════════════════════════════════════════════════╝");
                Logger.Info("");

                _clientManager = new NetworkClientManager();

                var config = new NetworkConfig
                {
                    MaxPlayers = 8,
                    TickRate = 60,
                    ServerAuthoritative = true
                };

                await _clientManager.InitializeAsync(config);
                Logger.Info("✓ Client initialized");

                RegisterHandlers();
                RegisterEvents();

                await _clientManager.StartAsync();

                Logger.Log("Enter your warrior name: ");
                _playerName = Console.ReadLine();
                if (string.IsNullOrEmpty(_playerName))
                    _playerName = $"Warrior_{Guid.NewGuid().ToString().Substring(0, 8)}";

                var serverUri = new Uri("ws://127.0.0.1:8889/");
                Logger.Info($"Joining battle at {serverUri}...");

                try
                {
                    await _clientManager.ConnectAsync(serverUri, _playerName);
                    _connected = true;
                    Logger.Info("✓ Joined the battle!");
                    Logger.Info("");
                    Logger.Info("═══════════════════════════════════════════════════════");
                    Logger.Info("Game Commands:");
                    Logger.Info("  /move <x> <y>  - Move to coordinates");
                    Logger.Info("  /attack <name> - Attack player");
                    Logger.Info("  /spawn          - Respawn in arena");
                    Logger.Info("  /chat <msg>     - Send message to all");
                    Logger.Info("  /stats          - Show your stats");
                    Logger.Info("  /quit           - Leave battle");
                    Logger.Info("═══════════════════════════════════════════════════════");
                    Logger.Info("");

                    await GameLoopAsync();
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to join: {ex.Message}");
                }

                if (_connected)
                {
                    await _clientManager.DisconnectAsync();
                }

                Logger.Info("✓ Left the battle");
            }
            catch (Exception ex)
            {
                Logger.Exception($"Fatal error: {ex.Message}");
            }
        }

        /// <summary>
        /// Games the loop
        /// </summary>
        private static async Task GameLoopAsync()
        {
            while (_connected)
            {
                try
                {
                    Logger.Log($"[{_playerName}]> ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                        continue;

                    if (input.Equals("/quit", StringComparison.OrdinalIgnoreCase))
                    {
                        _connected = false;
                        break;
                    }

                    if (input.StartsWith("/move "))
                    {
                        var parts = input.Substring(6).Split(' ');
                        if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                        {
                            var moveMsg = new GameMessage {MessageType = "move", Content = $"{x},{y}"};
                            await _clientManager.BroadcastMessageAsync("game.move", moveMsg);
                            Logger.Log("→ Moving...");
                        }
                    }

                    if (input.StartsWith("/attack "))
                    {
                        var targetName = input.Substring(8);
                        var attackMsg = new GameMessage {MessageType = "attack", Content = targetName};
                        await _clientManager.BroadcastMessageAsync("game.attack", attackMsg);
                        Logger.Log("→ Attacking...");
                    }

                    if (input.Equals("/spawn", StringComparison.OrdinalIgnoreCase))
                    {
                        var spawnMsg = new GameMessage {MessageType = "spawn", Content = "respawning"};
                        await _clientManager.BroadcastMessageAsync("game.spawn", spawnMsg);
                        Logger.Log("→ Respawning...");
                    }

                    if (input.StartsWith("/chat "))
                    {
                        var message = input.Substring(6);
                        var chatMsg = new GameMessage {MessageType = "chat", Content = message};
                        await _clientManager.BroadcastMessageAsync("game.chat", chatMsg);
                    }

                    if (input.Equals("/stats", StringComparison.OrdinalIgnoreCase))
                    {
                        Logger.Info("═ YOUR STATS ═");
                        Logger.Log($"Name: {_playerName}");
                        Logger.Log($"Connected Players: {_clientManager.GetConnectedPlayers().Count}");
                        Logger.Info("");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error: {ex.Message}");
                    _connected = false;
                }

                await Task.Delay(10);
            }
        }

        /// <summary>
        /// Registers the handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _clientManager.RegisterMessageHandler("game.move", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.attack", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.spawn", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.chat", OnGameChat);
        }

        /// <summary>
        /// Registers the events
        /// </summary>
        private static void RegisterEvents()
        {
            _clientManager.PlayerJoined += (s, e) =>
                Logger.Info($"→ {e.Player.PlayerName} entered the arena");

            _clientManager.PlayerLeft += (s, e) =>
                Logger.Info($"← {e.Player.PlayerName} left the arena");

            _clientManager.Connected += (s, e) =>
                Logger.Info("✓ Connected to game server");

            _clientManager.Disconnected += (s, e) =>
            {
                Logger.Info("✗ Disconnected from game");
                _connected = false;
            };

            _clientManager.Error += (s, e) =>
                Logger.Error($"⚠ Error: {e.Message}");
        }

        /// <summary>
        /// Ons the game event using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnGameEvent(string senderId, string payload)
        {
            Logger.Log($"[GAME EVENT] {payload.Substring(0, Math.Min(40, payload.Length))}");
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ons the game chat using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnGameChat(string senderId, string payload)
        {
            Logger.Log($"[CHAT] {payload}");
            await Task.CompletedTask;
        }
    }
}
