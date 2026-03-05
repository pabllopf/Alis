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

namespace Alis.Extension.Network.Sample.SimpleGame.Server
{
    /// <summary>
    ///     Simple multiplayer game server (console-based arena)
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The server manager
        /// </summary>
        private static NetworkServerManager _serverManager;
        /// <summary>
        /// The player state
        /// </summary>
        private static Dictionary<string, PlayerState> _playerStates = new Dictionary<string, PlayerState>();

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
                Logger.Info("║     ALIS NETWORK - SIMPLE GAME SERVER SAMPLE         ║");
                Logger.Info("║     Console-Based Arena Battle System                ║");
                Logger.Info("╚══════════════════════════════════════════════════════╝");
                Logger.Info("");

                _serverManager = new NetworkServerManager();

                var config = new NetworkConfig
                {
                    MaxPlayers = 8,
                    TickRate = 60,
                    ServerAuthoritative = true
                };

                await _serverManager.InitializeAsync(config);
                Logger.Info("✓ Server initialized");

                var session = await _serverManager.CreateSessionAsync("Battle Arena", 8);
                Logger.Info($"✓ Session created: {session.SessionName}");
                Logger.Info("");

                RegisterHandlers();
                RegisterEvents();

                var listenUri = new Uri("ws://127.0.0.1:8889/");
                await _serverManager.StartAsync();
                await _serverManager.ListenAsync(listenUri);

                Logger.Info($"✓ Server listening on {listenUri}");
                Logger.Info("");
                Logger.Info("═══════════════════════════════════════════════════════");
                Logger.Info("Game Server Commands:");
                Logger.Info("  /players   - Show connected players");
                Logger.Info("  /status    - Show game status");
                Logger.Info("  /reset     - Reset game state");
                Logger.Info("  /quit      - Stop server");
                Logger.Info("═══════════════════════════════════════════════════════");
                Logger.Info("");

                await GameLoopAsync();

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
        /// Games the loop
        /// </summary>
        private static async Task GameLoopAsync()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    continue;

                if (input.Equals("/quit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (input.Equals("/players", StringComparison.OrdinalIgnoreCase))
                {
                    var players = _serverManager.GetConnectedPlayers();
                    Logger.Info($"Connected players: {players.Count}/{_serverManager.Config.MaxPlayers}");
                    foreach (var player in players)
                    {
                        if (_playerStates.TryGetValue(player.PlayerId, out var state))
                        {
                            Logger.Log($"  {player.PlayerName}: HP={state.Health}/100, Score={state.Score}, Lvl={state.Level}");
                        }
                    }
                    Logger.Info("");
                }

                if (input.Equals("/status", StringComparison.OrdinalIgnoreCase))
                {
                    Logger.Info("═ GAME STATUS ═");
                    Logger.Log($"Active Players: {_serverManager.GetConnectedPlayers().Count}");
                    Logger.Log($"Active Sessions: {_serverManager.GetActiveSessions().Count}");
                    Logger.Log($"State Entries: {_playerStates.Count}");
                    Logger.Info("");
                }

                if (input.Equals("/reset", StringComparison.OrdinalIgnoreCase))
                {
                    _playerStates.Clear();
                    Logger.Info("✓ Game state reset");
                }

                await Task.Delay(10);
            }
        }

        /// <summary>
        /// Registers the handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _serverManager.RegisterMessageHandler("game.move", OnPlayerMove);
            _serverManager.RegisterMessageHandler("game.attack", OnPlayerAttack);
            _serverManager.RegisterMessageHandler("game.spawn", OnPlayerSpawn);
            _serverManager.RegisterMessageHandler("game.chat", OnGameChat);
        }

        /// <summary>
        /// Registers the events
        /// </summary>
        private static void RegisterEvents()
        {
            _serverManager.PlayerJoined += (s, e) =>
            {
                Logger.Info($"→ {e.Player.PlayerName} joined!");
                InitializePlayerState(e.Player.PlayerId, e.Player.PlayerName);
            };

            _serverManager.PlayerLeft += (s, e) =>
            {
                Logger.Info($"← {e.Player.PlayerName} left");
                _playerStates.Remove(e.Player.PlayerId);
            };

            _serverManager.Error += (s, e) =>
                Logger.Error($"⚠ Error: {e.Message}");
        }

        /// <summary>
        /// Initializes the player state using the specified player id
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="playerName">The player name</param>
        private static void InitializePlayerState(string playerId, string playerName)
        {
            if (!_playerStates.ContainsKey(playerId))
            {
                _playerStates[playerId] = new PlayerState
                {
                    PlayerId = playerId,
                    PlayerName = playerName,
                    Health = 100,
                    Score = 0,
                    Level = 1,
                    X = new Random().Next(0, 50),
                    Y = new Random().Next(0, 50)
                };
            }
        }

        /// <summary>
        /// Ons the player move using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnPlayerMove(string senderId, string payload)
        {
            Logger.Log($"[MOVE] {senderId}: {payload.Substring(0, Math.Min(30, payload.Length))}");
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ons the player attack using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnPlayerAttack(string senderId, string payload)
        {
            Logger.Log($"[ATTACK] {senderId}");
            if (_playerStates.TryGetValue(senderId, out var state))
                state.Score += 10;
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ons the player spawn using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnPlayerSpawn(string senderId, string payload)
        {
            Logger.Log($"[SPAWN] {senderId}");
            if (_playerStates.TryGetValue(senderId, out var state))
                state.Health = 100;
            await Task.CompletedTask;
        }

        /// <summary>
        /// Ons the game chat using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnGameChat(string senderId, string payload)
        {
            if (_playerStates.TryGetValue(senderId, out var state))
                Logger.Log($"[{state.PlayerName}]: {payload}");
            await Task.CompletedTask;
        }
    }

    /// <summary>
    /// The player state class
    /// </summary>
    public class PlayerState
    {
        /// <summary>
        /// Gets or sets the value of the player id
        /// </summary>
        public string PlayerId { get; set; }
        /// <summary>
        /// Gets or sets the value of the player name
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// Gets or sets the value of the health
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// Gets or sets the value of the score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Gets or sets the value of the level
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Gets or sets the value of the x
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Gets or sets the value of the y
        /// </summary>
        public int Y { get; set; }
    }
}