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
using System.Linq;
using System.Threading.Tasks;
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
        ///     The client manager
        /// </summary>
        private static NetworkClientManager _clientManager;

        /// <summary>
        ///     The player name
        /// </summary>
        private static string _playerName;

        /// <summary>
        ///     The player id
        /// </summary>
        private static string _playerId;

        /// <summary>
        ///     The connected
        /// </summary>
        private static bool _connected;

        /// <summary>
        ///     The game state
        /// </summary>
        private static GameState _gameState;

        /// <summary>
        ///     The console renderer
        /// </summary>
        private static ConsoleRenderer _renderer;

        /// <summary>
        ///     The render task running
        /// </summary>
        private static bool _renderRunning;

        /// <summary>
        ///     Flag to trigger render on next opportunity
        /// </summary>
        private static bool _needsRender = true;

        /// <summary>
        ///     Last render tick
        /// </summary>
        private static long _lastRenderTick;

        /// <summary>
        ///     Current input buffer being typed
        /// </summary>
        private static string _currentInput = "";

        /// <summary>
        ///     Main the args
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

                NetworkConfig config = new NetworkConfig
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
                {
                    _playerName = $"Warrior_{Guid.NewGuid().ToString().Substring(0, 8)}";
                }

                Uri serverUri = new Uri("ws://127.0.0.1:8889/");
                Logger.Info($"Joining battle at {serverUri}...");

                try
                {
                    await _clientManager.ConnectAsync(serverUri, _playerName);
                    _connected = true;
                    _playerId = _clientManager.LocalPlayer?.PlayerId ?? _playerName;

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
                    await Task.Delay(400);

                    _renderer = new ConsoleRenderer(_gameState, _playerId);
                    _renderRunning = true;

                    _ = RenderLoopAsync();
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
        ///     Renders the loop
        /// </summary>
        private static async Task RenderLoopAsync()
        {
            while (_renderRunning && _connected)
            {
                try
                {
                    if (_needsRender || _gameState.LastUpdateTick > _lastRenderTick)
                    {
                        _renderer?.Render(_currentInput);
                        _needsRender = false;
                        _lastRenderTick = _gameState.LastUpdateTick;
                    }

                    await Task.Delay(100);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Render error: {ex.Message}");
                }
            }
        }

        /// <summary>
        ///     Triggers the render
        /// </summary>
        private static void TriggerRender()
        {
            _needsRender = true;
        }

        /// <summary>
        ///     Games the loop
        /// </summary>
        private static async Task GameLoopAsync()
        {
            _currentInput = "";

            while (_connected)
            {
                try
                {
                    // Non-blocking input: check if key is available
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            string input = _currentInput;
                            _currentInput = "";
                            TriggerRender();

                            // Process command
                            await ProcessCommandAsync(input);
                        }
                        else if (keyInfo.Key == ConsoleKey.Backspace)
                        {
                            if (_currentInput.Length > 0)
                            {
                                _currentInput = _currentInput.Substring(0, _currentInput.Length - 1);
                                TriggerRender();
                            }
                        }
                        else if ((keyInfo.KeyChar >= ' ') && (keyInfo.KeyChar < '\x7F'))
                        {
                            _currentInput += keyInfo.KeyChar;
                            TriggerRender();
                        }
                    }

                    await Task.Delay(10);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error: {ex.Message}");
                    _currentInput = "";
                }
            }
        }

        /// <summary>
        ///     Processes the command using the specified input
        /// </summary>
        /// <param name="input">The input</param>
        private static async Task ProcessCommandAsync(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                TriggerRender();
                return;
            }

            if (input.Equals("/quit", StringComparison.OrdinalIgnoreCase))
            {
                _connected = false;
                return;
            }

            if (input.Equals("/help", StringComparison.OrdinalIgnoreCase))
            {
                Logger.Info("═══════════════════════════════════════════════════════");
                Logger.Info("Available Commands:");
                Logger.Info("  /move <x> <y>  - Move to coordinates (0-39, 0-24)");
                Logger.Info("  /attack <name> - Attack a player by name (your turn)");
                Logger.Info("  /spawn         - Respawn in arena");
                Logger.Info("  /endturn       - End your turn (skip to next player)");
                Logger.Info("  /chat <msg>    - Send message to all players");
                Logger.Info("  /stats         - Show your stats");
                Logger.Info("  /players       - List known players from server state");
                Logger.Info("  /help          - Show this help");
                Logger.Info("  /quit          - Leave the game");
                Logger.Info("═══════════════════════════════════════════════════════");
                Logger.Info("");
                TriggerRender();
                return;
            }

            if (input.StartsWith("/move "))
            {
                string[] parts = input.Substring(6).Split(' ');
                if ((parts.Length == 2) && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                {
                    if (MoveSystem.IsValidMove(x, y))
                    {
                        _gameState.UpdatePlayerPosition(_playerId, x, y);
                        GameMessage moveMsg = new GameMessage {MessageType = "move", Content = $"{x},{y}"};
                        await _clientManager.BroadcastMessageAsync("game.move", moveMsg);
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
                if (!IsLocalPlayerTurn())
                {
                    string turnName = string.IsNullOrEmpty(_gameState.CurrentTurnPlayerName) ? "Unknown" : _gameState.CurrentTurnPlayerName;
                    Logger.Error($"✗ It is not your turn. Current turn: {turnName}");
                }
                else
                {
                    string targetName = input.Substring(8);
                    if (_gameState.Players.Values.Any(p => (p.PlayerName == targetName) && p.IsAlive))
                    {
                        GameMessage attackMsg = new GameMessage {MessageType = "attack", Content = targetName};
                        await _clientManager.BroadcastMessageAsync("game.attack", attackMsg);
                    }
                    else
                    {
                        Logger.Error($"✗ Player '{targetName}' not found or is dead!");
                    }
                }
            }

            if (input.Equals("/spawn", StringComparison.OrdinalIgnoreCase))
            {
                if (_gameState.Players.TryGetValue(_playerId, out PlayerData player) && !player.IsAlive)
                {
                    GameMessage spawnMsg = new GameMessage {MessageType = "spawn", Content = "respawning"};
                    await _clientManager.BroadcastMessageAsync("game.spawn", spawnMsg);
                }
                else
                {
                    Logger.Error("✗ You are already alive!");
                }
            }

            if (input.Equals("/endturn", StringComparison.OrdinalIgnoreCase))
            {
                if (IsLocalPlayerTurn())
                {
                    GameMessage endTurnMsg = new GameMessage {MessageType = "endturn", Content = ""};
                    await _clientManager.BroadcastMessageAsync("game.endturn", endTurnMsg);
                    Logger.Log("→ Turn ended, waiting for next turn...");
                }
                else
                {
                    Logger.Error("✗ It is not your turn!");
                }
            }

            if (input.StartsWith("/chat "))
            {
                string message = input.Substring(6);
                GameMessage chatMsg = new GameMessage {MessageType = "chat", Content = message};
                await _clientManager.BroadcastMessageAsync("game.chat", chatMsg);
            }

            if (input.Equals("/stats", StringComparison.OrdinalIgnoreCase))
            {
                // Stats are already displayed in the UI, no need for separate command
                Logger.Info("Stats are displayed at the top of the screen!");
                return;
            }

            if (input.Equals("/players", StringComparison.OrdinalIgnoreCase))
            {
                Logger.Info($"═ PLAYERS ({_gameState.Players.Count}) ═");
                foreach (PlayerData player in _gameState.Players.Values.OrderByDescending(p => p.Score))
                {
                    string status = player.IsAlive ? "✓" : "✕";
                    string turn = player.PlayerId == _gameState.CurrentTurnPlayerId ? " <- TURN" : string.Empty;
                    Logger.Log($"{status} {player.PlayerName,-15} HP:{player.Health}/{player.MaxHealth} Score:{player.Score} Lvl:{player.Level}{turn}");
                }

                Logger.Info("");
            }

            TriggerRender();
        }

        /// <summary>
        ///     Registers the handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _clientManager.RegisterMessageHandler("game.update", OnGameUpdate);
            _clientManager.RegisterMessageHandler("game.move", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.attack", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.spawn", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.chat", OnGameChat);
            _clientManager.RegisterMessageHandler("game.join", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.leave", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.death", OnGameEvent);
            _clientManager.RegisterMessageHandler("game.levelup", OnGameEvent);
        }

        /// <summary>
        ///     Registers the events
        /// </summary>
        private static void RegisterEvents()
        {
            _clientManager.PlayerJoined += (_, e) =>
            {
                EnsurePlayerExists(e.Player.PlayerId, e.Player.PlayerName);
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
        ///     Ons the game update using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnGameUpdate(string senderId, string payload)
        {
            try
            {
                string content = ExtractGameMessageContent(payload);
                string[] parts = content.Split('|');
                bool stateChanged = false;

                foreach (string part in parts)
                {
                    if (string.IsNullOrWhiteSpace(part))
                    {
                        continue;
                    }

                    string[] kvp = part.Split(':');
                    if (kvp.Length < 3)
                    {
                        continue;
                    }

                    string entityId = kvp[0];
                    string field = kvp[1];
                    string value = string.Join(":", kvp.Skip(2));

                    if (entityId == "__meta__")
                    {
                        if (field == "turn")
                        {
                            _gameState.CurrentTurnPlayerId = value;
                            stateChanged = true;
                        }
                        else if (field == "turn_name")
                        {
                            _gameState.CurrentTurnPlayerName = value;
                            stateChanged = true;
                        }
                        else if ((field == "turn_ticks") && int.TryParse(value, out int turnTicks))
                        {
                            _gameState.TurnTicksRemaining = turnTicks;
                            stateChanged = true;
                        }
                        else if ((field == "tick") && long.TryParse(value, out long tick))
                        {
                            _gameState.LastUpdateTick = tick;
                        }
                        else if (field.StartsWith("event_") && !field.Equals("event_count"))
                        {
                            // Parse event: "eventType|sourceId|targetId|description"
                            string[] eventParts = value.Split('|');
                            if (eventParts.Length >= 4)
                            {
                                string eventType = eventParts[0];
                                string sourceId = eventParts[1];
                                string targetId = eventParts[2];
                                string description = eventParts[3];

                                // Try to get player names
                                string sourceName = sourceId;
                                if (!string.IsNullOrEmpty(sourceId) && _gameState.Players.TryGetValue(sourceId, out PlayerData sourcePlayer))
                                {
                                    sourceName = sourcePlayer.PlayerName;
                                }

                                // Clean description if it contains IDs
                                if (!string.IsNullOrEmpty(sourceId) && description.Contains(sourceId))
                                {
                                    description = description.Replace(sourceId, sourceName);
                                }

                                // Add event if not already present
                                if (!_gameState.EventLog.Any(e => e.Description == description))
                                {
                                    _gameState.AddEvent(new GameEvent
                                    {
                                        EventType = eventType,
                                        Description = description
                                    });
                                    stateChanged = true;
                                }
                            }
                        }

                        continue;
                    }

                    if (!_gameState.Players.TryGetValue(entityId, out PlayerData player))
                    {
                        player = new PlayerData {PlayerId = entityId, PlayerName = entityId};
                        _gameState.Players[entityId] = player;
                    }

                    if (field == "name")
                    {
                        player.PlayerName = value;
                        stateChanged = true;
                    }
                    else if ((field == "x") && int.TryParse(value, out int x))
                    {
                        player.X = x;
                        stateChanged = true;
                    }
                    else if ((field == "y") && int.TryParse(value, out int y))
                    {
                        player.Y = y;
                        stateChanged = true;
                    }
                    else if ((field == "health") && int.TryParse(value, out int health))
                    {
                        player.Health = health;
                        stateChanged = true;
                    }
                    else if ((field == "maxhealth") && int.TryParse(value, out int maxHealth))
                    {
                        player.MaxHealth = maxHealth;
                        stateChanged = true;
                    }
                    else if ((field == "score") && int.TryParse(value, out int score))
                    {
                        player.Score = score;
                        stateChanged = true;
                    }
                    else if ((field == "level") && int.TryParse(value, out int level))
                    {
                        player.Level = level;
                        stateChanged = true;
                    }
                    else if ((field == "kills") && int.TryParse(value, out int kills))
                    {
                        player.Kills = kills;
                        stateChanged = true;
                    }
                    else if ((field == "deaths") && int.TryParse(value, out int deaths))
                    {
                        player.Deaths = deaths;
                        stateChanged = true;
                    }
                    else if ((field == "alive") && bool.TryParse(value, out bool alive))
                    {
                        player.IsAlive = alive;
                        stateChanged = true;
                    }
                }

                if (_gameState.LastUpdateTick == 0)
                {
                    _gameState.LastUpdateTick = DateTime.UtcNow.Ticks;
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
        ///     Ons the game event using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnGameEvent(string senderId, string payload)
        {
            try
            {
                string content = ExtractGameMessageContent(payload);

                // Events are formatted as: "eventType|sourcePlayerId|targetPlayerId|description"
                string[] parts = content.Split('|');

                if (parts.Length >= 4)
                {
                    string eventType = parts[0];
                    string sourceId = parts[1];
                    string targetId = parts[2];
                    string description = parts[3];

                    // Try to get player names from game state instead of using IDs
                    string sourceName = sourceId;
                    string targetName = targetId;

                    if (_gameState.Players.TryGetValue(sourceId, out PlayerData sourcePlayer))
                    {
                        sourceName = sourcePlayer.PlayerName;
                    }

                    if (!string.IsNullOrEmpty(targetId) && _gameState.Players.TryGetValue(targetId, out PlayerData targetPlayer))
                    {
                        targetName = targetPlayer.PlayerName;
                    }

                    // Clean description and replace IDs with names if needed
                    string cleanDescription = description;
                    if (description.Contains(sourceId))
                    {
                        cleanDescription = cleanDescription.Replace(sourceId, sourceName);
                    }

                    if (!string.IsNullOrEmpty(targetId) && description.Contains(targetId))
                    {
                        cleanDescription = cleanDescription.Replace(targetId, targetName);
                    }

                    _gameState.AddEvent(new GameEvent
                    {
                        EventType = eventType,
                        Description = cleanDescription.Length > 65 ? cleanDescription.Substring(0, 62) + "..." : cleanDescription
                    });
                }
                else
                {
                    // Fallback for chat and other messages
                    _gameState.AddEvent(new GameEvent
                    {
                        EventType = "event",
                        Description = content.Length > 65 ? content.Substring(0, 62) + "..." : content
                    });
                }

                TriggerRender();
            }
            catch (Exception ex)
            {
                Logger.Error($"Error handling game event: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Ons the game chat using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnGameChat(string senderId, string payload)
        {
            try
            {
                string content = ExtractGameMessageContent(payload);

                // Server messages are formatted as "Server: message"
                string playerName = "Unknown";
                string message = content;

                if (content.StartsWith("Server:"))
                {
                    playerName = "Server";
                    message = content.Substring(7).Trim();
                    _gameState.LastServerMessage = message;
                    _gameState.LastServerMessageTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
                }
                else
                {
                    // Regular player chat: "PlayerName:message" (NOT UUID:message)
                    string[] parts = content.Split(':', 2);
                    if (parts.Length >= 2)
                    {
                        playerName = parts[0].Trim();
                        message = parts[1].Trim();
                    }
                    else
                    {
                        // If format is unexpected, try to extract from current game state
                        if (_gameState.Players.TryGetValue(senderId, out PlayerData player))
                        {
                            playerName = player.PlayerName;
                            message = content;
                        }
                    }
                }

                // Add event with clean name
                _gameState.AddEvent(new GameEvent
                {
                    EventType = "chat",
                    Description = $"{playerName}: {message}".Length > 65
                        ? $"{playerName}: {message}".Substring(0, 62) + "..."
                        : $"{playerName}: {message}"
                });
                TriggerRender();
            }
            catch (Exception ex)
            {
                Logger.Error($"Error handling chat: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Ises the local player turn
        /// </summary>
        /// <returns>The bool</returns>
        private static bool IsLocalPlayerTurn() => !string.IsNullOrEmpty(_playerId) && (_playerId == _gameState.CurrentTurnPlayerId);

        /// <summary>
        ///     Ensures the player exists using the specified player id
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="playerName">The player name</param>
        private static void EnsurePlayerExists(string playerId, string playerName)
        {
            if (!_gameState.Players.TryGetValue(playerId, out PlayerData player))
            {
                _gameState.Players[playerId] = new PlayerData
                {
                    PlayerId = playerId,
                    PlayerName = string.IsNullOrEmpty(playerName) ? playerId : playerName,
                    X = 20,
                    Y = 12
                };
                return;
            }

            if (!string.IsNullOrEmpty(playerName))
            {
                player.PlayerName = playerName;
            }
        }

        /// <summary>
        ///     Extracts the game message content using the specified payload
        /// </summary>
        /// <param name="payload">The payload</param>
        /// <returns>The string</returns>
        private static string ExtractGameMessageContent(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
            {
                return string.Empty;
            }

            string content = ExtractJsonField(payload, "Content") ?? ExtractJsonField(payload, "content");
            return string.IsNullOrEmpty(content) ? payload : content;
        }

        /// <summary>
        ///     Extracts the json field using the specified json
        /// </summary>
        /// <param name="json">The json</param>
        /// <param name="fieldName">The field name</param>
        /// <returns>The string</returns>
        private static string ExtractJsonField(string json, string fieldName)
        {
            try
            {
                string search = $"\"{fieldName}\":\"";
                int startIndex = json.IndexOf(search, StringComparison.Ordinal);
                if (startIndex == -1)
                {
                    return null;
                }

                startIndex += search.Length;
                int endIndex = json.IndexOf("\"", startIndex, StringComparison.Ordinal);
                if (endIndex == -1)
                {
                    return null;
                }

                return json.Substring(startIndex, endIndex - startIndex)
                    .Replace("\\\"", "\"")
                    .Replace("\\n", "\n")
                    .Replace("\\r", "\r");
            }
            catch
            {
                return null;
            }
        }
    }
}