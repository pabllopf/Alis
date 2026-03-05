// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Program.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using System.Linq;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Network.Client;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Sample.SimpleGame.Client
{
    /// <summary>
    /// Simple multiplayer game client (console-based arena)
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
        /// The player id
        /// </summary>
        private static string _playerId;
        /// <summary>
        /// The connected
        /// </summary>
        private static bool _connected;
        /// <summary>
        /// The game state
        /// </summary>
        private static GameState _gameState;
        /// <summary>
        /// The console renderer
        /// </summary>
        private static ConsoleRenderer _renderer;
        /// <summary>
        /// The render task running
        /// </summary>
        private static bool _renderRunning;
        /// <summary>
        /// Flag to trigger render on next opportunity
        /// </summary>
        private static bool _needsRender = true;
        /// <summary>
        /// Last render tick
        /// </summary>
        private static long _lastRenderTick;

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
                _gameState = new GameState();

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
                    _playerId = _playerName; // Use player name as ID
                    
                    // Initialize local player
                    _gameState.LocalPlayerId = _playerId;
                    _gameState.Players[_playerId] = new PlayerData 
                    { 
                        PlayerId = _playerId, 
                        PlayerName = _playerName,
                        X = 20,
                        Y = 12
                    };

                    Logger.Info("✓ Joined the battle!");
                    Logger.Info("Starting game...");
                    await Task.Delay(1000);

                    _renderer = new ConsoleRenderer(_gameState, _playerId);
                    _renderRunning = true;

                    // Start render task in background
                    _ = RenderLoopAsync();

                    // Run game loop
                    await GameLoopAsync();

                    _renderRunning = false;
                    await Task.Delay(100);
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
        /// Render loop for updating the screen only when needed
        /// </summary>
        private static async Task RenderLoopAsync()
        {
            int frameCounter = 0;
            while (_renderRunning && _connected)
            {
                try
                {
                    // Render every 5 frames (roughly every 500ms) or on demand
                    if (_needsRender || frameCounter % 5 == 0)
                    {
                        _renderer?.Render();
                        _needsRender = false;
                        _lastRenderTick = _gameState.LastUpdateTick;
                    }
                    
                    frameCounter++;
                    await Task.Delay(100);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Render error: {ex.Message}");
                }
            }
        }
        
        /// <summary>
        /// Trigger a screen refresh
        /// </summary>
        private static void TriggerRender()
        {
            _needsRender = true;
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
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Logger.Log($"[{_playerName}]> ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                        continue;

                    if (input.Equals("/quit", StringComparison.OrdinalIgnoreCase))
                    {
                        _connected = false;
                        break;
                    }

                    if (input.Equals("/help", StringComparison.OrdinalIgnoreCase))
                    {
                        Logger.Info("═══════════════════════════════════════════════════════");
                        Logger.Info("Available Commands:");
                        Logger.Info("  /move <x> <y>  - Move to coordinates (0-39, 0-24)");
                        Logger.Info("  /attack <name> - Attack a player by name");
                        Logger.Info("  /spawn          - Respawn in arena");
                        Logger.Info("  /chat <msg>     - Send message to all players");
                        Logger.Info("  /stats          - Show your stats");
                        Logger.Info("  /players        - List all connected players");
                        Logger.Info("  /help           - Show this help");
                        Logger.Info("  /quit           - Leave the game");
                        Logger.Info("═══════════════════════════════════════════════════════");
                        Logger.Info("");
                        continue;
                    }

                    if (input.StartsWith("/move "))
                    {
                        var parts = input.Substring(6).Split(' ');
                        if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                        {
                            if (MoveSystem.IsValidMove(x, y))
                            {
                                _gameState.UpdatePlayerPosition(_playerId, x, y);
                                var moveMsg = new GameMessage { MessageType = "move", Content = $"{x},{y}" };
                                await _clientManager.BroadcastMessageAsync("game.move", moveMsg);
                                Logger.Log("→ Moved to position");
                            }
                            else
                            {
                                Logger.Error("✗ Invalid coordinates!");
                            }
                        }
                        else
                        {
                            Logger.Error("✗ Usage: /move <x> <y>");
                        }
                    }

                    if (input.StartsWith("/attack "))
                    {
                        var targetName = input.Substring(8);
                        if (_gameState.Players.Values.Any(p => p.PlayerName == targetName && p.IsAlive))
                        {
                            var attackMsg = new GameMessage { MessageType = "attack", Content = targetName };
                            await _clientManager.BroadcastMessageAsync("game.attack", attackMsg);
                            Logger.Log("→ Attacking...");
                        }
                        else
                        {
                            Logger.Error($"✗ Player '{targetName}' not found or is dead!");
                        }
                    }

                    if (input.Equals("/spawn", StringComparison.OrdinalIgnoreCase))
                    {
                        if (_gameState.Players.TryGetValue(_playerId, out var player) && !player.IsAlive)
                        {
                            var spawnMsg = new GameMessage { MessageType = "spawn", Content = "respawning" };
                            await _clientManager.BroadcastMessageAsync("game.spawn", spawnMsg);
                            Logger.Log("→ Respawning...");
                        }
                        else
                        {
                            Logger.Error("✗ You are already alive!");
                        }
                    }

                    if (input.StartsWith("/chat "))
                    {
                        var message = input.Substring(6);
                        var chatMsg = new GameMessage { MessageType = "chat", Content = message };
                        await _clientManager.BroadcastMessageAsync("game.chat", chatMsg);
                    }

                    if (input.Equals("/stats", StringComparison.OrdinalIgnoreCase))
                    {
                        if (_gameState.Players.TryGetValue(_playerId, out var player))
                        {
                            Logger.Info("═ YOUR STATS ═");
                            Logger.Log($"Name: {player.PlayerName}");
                            Logger.Log($"Position: ({player.X}, {player.Y})");
                            Logger.Log($"Health: {player.Health}/{player.MaxHealth}");
                            Logger.Log($"Level: {player.Level} | XP: {player.Experience}");
                            Logger.Log($"Score: {player.Score} | Kills: {player.Kills} | Deaths: {player.Deaths}");
                            Logger.Log($"Status: {(player.IsAlive ? "✓ Alive" : "✕ Dead")}");
                            Logger.Info("");
                        }
                    }

                    if (input.Equals("/players", StringComparison.OrdinalIgnoreCase))
                    {
                        Logger.Info("═ CONNECTED PLAYERS ═");
                        foreach (var player in _gameState.Players.Values.OrderByDescending(p => p.Score))
                        {
                            string status = player.IsAlive ? "✓" : "✕";
                            Logger.Log($"{status} {player.PlayerName,-15} HP:{player.Health}/{player.MaxHealth} Score:{player.Score} Lvl:{player.Level}");
                        }
                        Logger.Info("");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error: {ex.Message}");
                }

                await Task.Delay(10);
            }
        }

        /// <summary>
        /// Registers the handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _clientManager.RegisterMessageHandler("game.update", OnGameUpdate);
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
            _clientManager.PlayerJoined += (_, e) =>
            {
                if (e.Player.PlayerId != _playerId)
                {
                    _gameState.Players[e.Player.PlayerId] = new PlayerData
                    {
                        PlayerId = e.Player.PlayerId,
                        PlayerName = e.Player.PlayerName,
                        X = 20,
                        Y = 12
                    };
                }
                Logger.Info($"→ {e.Player.PlayerName} entered the arena");
                _gameState.AddEvent(new GameEvent
                {
                    EventType = "join",
                    Description = $"{e.Player.PlayerName} joined!"
                });
                TriggerRender();
            };

            _clientManager.PlayerLeft += (_, e) =>
            {
                _gameState.Players.Remove(e.Player.PlayerId);
                Logger.Info($"← {e.Player.PlayerName} left the arena");
                _gameState.AddEvent(new GameEvent
                {
                    EventType = "leave",
                    Description = $"{e.Player.PlayerName} left!"
                });
                TriggerRender();
            };

            _clientManager.Connected += (_, _) =>
                Logger.Info("✓ Connected to game server");

            _clientManager.Disconnected += (_, _) =>
            {
                Logger.Info("✗ Disconnected from game");
                _connected = false;
            };

            _clientManager.Error += (_, e) =>
                Logger.Error($"⚠ Error: {e.Message}");
        }

        /// <summary>
        /// On game update message
        /// </summary>
        private static async Task OnGameUpdate(string senderId, string payload)
        {
            try
            {
                // Parse state update from server
                var parts = payload.Split('|');
                bool stateChanged = false;
                
                foreach (var part in parts)
                {
                    var kvp = part.Split(':');
                    if (kvp.Length >= 3)
                    {
                        string playerId = kvp[0];
                        string field = kvp[1];
                        string value = kvp[2];

                        if (_gameState.Players.TryGetValue(playerId, out var player))
                        {
                            if (field == "x" && int.TryParse(value, out int x))
                            {
                                player.X = x;
                                stateChanged = true;
                            }
                            else if (field == "y" && int.TryParse(value, out int y))
                            {
                                player.Y = y;
                                stateChanged = true;
                            }
                            else if (field == "health" && int.TryParse(value, out int health))
                            {
                                player.Health = health;
                                stateChanged = true;
                            }
                            else if (field == "score" && int.TryParse(value, out int score))
                            {
                                player.Score = score;
                                stateChanged = true;
                            }
                            else if (field == "alive" && bool.TryParse(value, out bool alive))
                            {
                                player.IsAlive = alive;
                                stateChanged = true;
                            }
                        }
                    }
                }
                
                if (stateChanged)
                {
                    TriggerRender();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error updating game state: {ex.Message}");
            }

            await Task.CompletedTask;
        }


        /// <summary>
        /// Ons the game event using the specified sender id
        /// </summary>
        private static async Task OnGameEvent(string senderId, string payload)
        {
            try
            {
                _gameState.AddEvent(new GameEvent
                {
                    EventType = "game_event",
                    Description = payload.Length > 50 ? payload.Substring(0, 50) + "..." : payload
                });
                TriggerRender();
            }
            catch (Exception ex)
            {
                Logger.Error($"Error handling game event: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Ons the game chat using the specified sender id
        /// </summary>
        private static async Task OnGameChat(string senderId, string payload)
        {
            try
            {
                var parts = payload.Split(':', 2);
                string playerName = parts.Length > 0 ? parts[0] : "Unknown";
                string message = parts.Length > 1 ? parts[1] : payload;

                Logger.Log($"[CHAT] {playerName}: {message}");
                _gameState.AddEvent(new GameEvent
                {
                    EventType = "chat",
                    Description = $"{playerName}: {message}"
                });
                TriggerRender();
            }
            catch (Exception ex)
            {
                Logger.Error($"Error handling chat: {ex.Message}");
            }

            await Task.CompletedTask;
        }
    }
}

