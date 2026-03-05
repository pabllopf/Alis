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
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;

namespace Alis.Extension.Network.Sample.SimpleGame.Server
{
    /// <summary>
    /// Simple multiplayer game server (console-based arena)
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The server manager
        /// </summary>
        private static NetworkServerManager _serverManager;
        /// <summary>
        /// The game state
        /// </summary>
        private static GameState _gameState;
        /// <summary>
        /// The tick counter
        /// </summary>
        private static long _tickCounter;
        /// <summary>
        /// The game running
        /// </summary>
        private static bool _gameRunning;
        /// <summary>
        /// Whether server is also a player
        /// </summary>
        private static bool _serverIsPlayer;

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

                // Ask if server is also a player
                Logger.Log("Run as pure server or as player+server? (s/p): ");
                string modeInput = Console.ReadLine()?.ToLower() ?? "s";
                _serverIsPlayer = modeInput == "p";
                Logger.Info(_serverIsPlayer ? "✓ Running as Player+Server" : "✓ Running as Pure Server");
                Logger.Info("");

                _serverManager = new NetworkServerManager();
                _gameState = new GameState();
                
                // If server is also a player, add server as a player
                if (_serverIsPlayer)
                {
                    Logger.Log("Enter server player name: ");
                    string serverPlayerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(serverPlayerName))
                        serverPlayerName = $"ServerPlayer_{Guid.NewGuid().ToString().Substring(0, 4)}";
                    
                    _gameState.AddPlayer("server_player", serverPlayerName);
                    Logger.Info($"✓ Server player: {serverPlayerName}");
                    Logger.Info("");
                }

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
                Logger.Info("  /broadcast <msg> - Send message to all");
                Logger.Info("  /reset     - Reset game state");
                Logger.Info("  /quit      - Stop server");
                Logger.Info("═══════════════════════════════════════════════════════");
                Logger.Info("");

                _gameRunning = true;

                // Start game tick loop in background
                _ = GameTickLoopAsync();

                // Run command loop
                await CommandLoopAsync();

                _gameRunning = false;
                await Task.Delay(100);

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
        /// Game tick loop that updates game state periodically
        /// </summary>
        private static async Task GameTickLoopAsync()
        {
            int tickDelay = 1000 / 30; // 30 ticks per second

            while (_gameRunning)
            {
                try
                {
                    _tickCounter++;
                    _gameState.CurrentTick = _tickCounter;
                    _gameState.UpdateTurn(_tickCounter);

                    // Process any pending game events
                    var events = _gameState.GetPendingEvents();
                    foreach (var evt in events)
                    {
                        if (!string.IsNullOrEmpty(evt.SourcePlayer))
                        {
                            await BroadcastGameEventAsync(evt);
                        }
                    }

                    // Send state updates to all players periodically (every 5 ticks)
                    if (_tickCounter % 5 == 0)
                    {
                        await BroadcastGameStateAsync();
                    }

                    await Task.Delay(tickDelay);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Game tick error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Broadcasts game event to all players
        /// </summary>
        private static async Task BroadcastGameEventAsync(GameEvent evt)
        {
            try
            {
                string eventData = $"{evt.EventType}|{evt.SourcePlayer}|{evt.TargetPlayer ?? ""}|{evt.Description}";
                var msg = new GameMessage { MessageType = evt.EventType, Content = eventData };
                
                foreach (var player in _serverManager.GetConnectedPlayers())
                {
                    await _serverManager.SendMessageAsync(player.PlayerId, $"game.{evt.EventType}", msg);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error broadcasting event: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Broadcasts full game state to all players
        /// </summary>
        private static async Task BroadcastGameStateAsync()
        {
            try
            {
                var segments = new System.Collections.Generic.List<string>();

                foreach (var player in _gameState.Players.Values)
                {
                    segments.Add($"{player.PlayerId}:name:{player.PlayerName}");
                    segments.Add($"{player.PlayerId}:x:{player.X}");
                    segments.Add($"{player.PlayerId}:y:{player.Y}");
                    segments.Add($"{player.PlayerId}:health:{player.Health}");
                    segments.Add($"{player.PlayerId}:maxhealth:{player.MaxHealth}");
                    segments.Add($"{player.PlayerId}:score:{player.Score}");
                    segments.Add($"{player.PlayerId}:level:{player.Level}");
                    segments.Add($"{player.PlayerId}:kills:{player.Kills}");
                    segments.Add($"{player.PlayerId}:deaths:{player.Deaths}");
                    segments.Add($"{player.PlayerId}:alive:{player.IsAlive}");
                }

                string turnName = _gameState.Players.TryGetValue(_gameState.CurrentTurnPlayerId, out var turnPlayer)
                    ? turnPlayer.PlayerName
                    : "No one";

                int turnTicksRemaining = Math.Max(0, (int)(_gameState.TurnEndsAtTick - _tickCounter));
                segments.Add($"__meta__:turn:{_gameState.CurrentTurnPlayerId ?? string.Empty}");
                segments.Add($"__meta__:turn_name:{turnName}");
                segments.Add($"__meta__:turn_ticks:{turnTicksRemaining}");
                segments.Add($"__meta__:tick:{_tickCounter}");

                string stateData = string.Join("|", segments);
                var msg = new GameMessage { MessageType = "state", Content = stateData };

                foreach (var player in _serverManager.GetConnectedPlayers())
                {
                    await _serverManager.SendMessageAsync(player.PlayerId, "game.update", msg);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error broadcasting state: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Commands the loop
        /// </summary>
        private static async Task CommandLoopAsync()
        {
            while (_gameRunning)
            {
                try
                {
                    Logger.Log("server> ");
                    string input = Console.ReadLine();
                    
                    if (string.IsNullOrEmpty(input))
                        continue;

                    if (input.Equals("/quit", StringComparison.OrdinalIgnoreCase))
                    {
                        _gameRunning = false;
                        break;
                    }

                    if (input.Equals("/players", StringComparison.OrdinalIgnoreCase))
                    {
                        var players = _serverManager.GetConnectedPlayers();
                        
                        // Filter out server player if in pure server mode
                        var clientPlayers = players.Where(p => !_serverIsPlayer || p.PlayerId != "server_player").ToList();
                        
                        Logger.Info($"Connected players: {clientPlayers.Count}/{_serverManager.Config.MaxPlayers}");
                        
                        foreach (var connectedPlayer in clientPlayers)
                        {
                            if (_gameState.Players.TryGetValue(connectedPlayer.PlayerId, out var state))
                            {
                                string status = state.IsAlive ? "✓" : "✕";
                                Logger.Log($"  {status} {state.PlayerName,-15} HP={state.Health}/{state.MaxHealth} Score={state.Score} Lvl={state.Level} Pos=({state.X},{state.Y})");
                            }
                        }
                        Logger.Info("");
                    }

                    if (input.Equals("/status", StringComparison.OrdinalIgnoreCase))
                    {
                        var allConnected = _serverManager.GetConnectedPlayers();
                        var clientCount = allConnected.Where(p => !_serverIsPlayer || p.PlayerId != "server_player").Count();
                        
                        Logger.Info("═ GAME STATUS ═");
                        Logger.Log($"Active Players (Clients): {clientCount}");
                        Logger.Log($"Active Sessions: {_serverManager.GetActiveSessions().Count}");
                        Logger.Log($"Game State Entries: {_gameState.Players.Count}");
                        Logger.Log($"Tick: {_gameState.CurrentTick}");
                        Logger.Log($"Pending Events: {_gameState.Events.Count}");
                        Logger.Info("");
                    }

                    if (input.StartsWith("/broadcast "))
                    {
                        string message = input.Substring(11);
                        var msg = new GameMessage { MessageType = "server_broadcast", Content = message };
                        
                        foreach (var player in _serverManager.GetConnectedPlayers())
                        {
                            await _serverManager.SendMessageAsync(player.PlayerId, "game.chat", msg);
                        }
                        
                        Logger.Info($"✓ Broadcast: {message}");
                    }

                    if (input.Equals("/reset", StringComparison.OrdinalIgnoreCase))
                    {
                        _gameState.Players.Clear();
                        _gameState.Events.Clear();
                        Logger.Info("✓ Game state reset");
                    }

                    await Task.Delay(10);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Command error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Registers the handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _serverManager.RegisterMessageHandler("system.join", OnSystemJoin);
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
            _serverManager.PlayerJoined += (_, e) =>
            {
                _gameState.AddPlayer(e.Player.PlayerId, e.Player.PlayerName);

                Logger.Info($"→ {e.Player.PlayerName} connected ({e.Player.PlayerId})");
                Logger.Log($"   Connected players: {_serverManager.GetConnectedPlayers().Count}");

                _gameState.AddEvent(new GameEvent
                {
                    EventType = "join",
                    SourcePlayer = e.Player.PlayerId,
                    Description = $"{e.Player.PlayerName} entered the arena!"
                });
            };

            _serverManager.PlayerLeft += (_, e) =>
            {
                Logger.Info($"← {e.Player.PlayerName} disconnected ({e.Player.PlayerId})");
                _gameState.RemovePlayer(e.Player.PlayerId);
                Logger.Log($"   Connected players: {_serverManager.GetConnectedPlayers().Count}");

                _gameState.AddEvent(new GameEvent
                {
                    EventType = "leave",
                    SourcePlayer = e.Player.PlayerId,
                    Description = $"{e.Player.PlayerName} left the arena"
                });
            };

            _serverManager.Error += (_, e) =>
                Logger.Error($"⚠ Error: {e.Message}");
        }

        /// <summary>
        /// Ons the player move using the specified sender id
        /// </summary>
        private static async Task OnPlayerMove(string senderId, string payload)
        {
            try
            {
                string content = ExtractGameMessageContent(payload);
                var moveParts = content.Split(',');

                if (moveParts.Length == 2 && int.TryParse(moveParts[0], out int x) && int.TryParse(moveParts[1], out int y))
                {
                    if (_gameState.ProcessMove(senderId, x, y))
                    {
                        if (_gameState.CurrentTurnPlayerId == senderId)
                        {
                            _gameState.AdvanceTurn(_tickCounter);
                        }
                        Logger.Log($"[MOVE] {senderId} -> ({x}, {y})");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Move error: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Ons the player attack using the specified sender id
        /// </summary>
        private static async Task OnPlayerAttack(string senderId, string payload)
        {
            try
            {
                string targetName = ExtractGameMessageContent(payload);

                if (!string.IsNullOrWhiteSpace(_gameState.CurrentTurnPlayerId) && _gameState.CurrentTurnPlayerId != senderId)
                {
                    string turnName = _gameState.Players.TryGetValue(_gameState.CurrentTurnPlayerId, out var turnPlayer)
                        ? turnPlayer.PlayerName
                        : "Unknown";

                    var notice = new GameMessage
                    {
                        MessageType = "chat",
                        Content = $"Server: Wait for your turn. Current turn: {turnName}."
                    };

                    await _serverManager.SendMessageAsync(senderId, "game.chat", notice);
                    return;
                }

                int damage = _gameState.ProcessAttack(senderId, targetName);
                if (damage > 0)
                {
                    _gameState.AdvanceTurn(_tickCounter);
                    Logger.Log($"[ATTACK] {senderId} -> {targetName}: {damage} damage!");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Attack error: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Ons the player spawn using the specified sender id
        /// </summary>
        private static async Task OnPlayerSpawn(string senderId, string payload)
        {
            try
            {
                if (_gameState.Players.TryGetValue(senderId, out var player) && !player.IsAlive)
                {
                    _gameState.ProcessSpawn(senderId);
                    Logger.Log($"[SPAWN] {senderId} respawned at ({player.X}, {player.Y})");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Spawn error: {ex.Message}");
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
                string content = ExtractGameMessageContent(payload);

                if (_gameState.Players.TryGetValue(senderId, out var state))
                {
                    Logger.Log($"[CHAT] {state.PlayerName}: {content}");

                    var msg = new GameMessage { MessageType = "chat", Content = $"{state.PlayerName}:{content}" };
                    foreach (var player in _serverManager.GetConnectedPlayers())
                    {
                        await _serverManager.SendMessageAsync(player.PlayerId, "game.chat", msg);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Chat error: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        private static async Task OnSystemJoin(string senderId, string payload)
        {
            try
            {
                string playerId = ExtractJsonField(payload, "playerId") ?? senderId;
                string playerName = ExtractJsonField(payload, "playerName");

                if (string.IsNullOrEmpty(playerName))
                {
                    playerName = _serverManager.GetPlayer(senderId)?.PlayerName ?? senderId;
                }

                _serverManager.RegisterPlayerInSession(playerId, playerName);
                _gameState.AddPlayer(playerId, playerName);

                Logger.Log($"[JOIN] Registered {playerName} ({playerId})");
            }
            catch (Exception ex)
            {
                Logger.Error($"Join error: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        private static string ExtractGameMessageContent(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
                return string.Empty;

            string content = ExtractJsonField(payload, "Content") ?? ExtractJsonField(payload, "content");
            return string.IsNullOrEmpty(content) ? payload : content;
        }

        private static string ExtractJsonField(string json, string fieldName)
        {
            try
            {
                string search = $"\"{fieldName}\":\"";
                int startIndex = json.IndexOf(search, StringComparison.Ordinal);
                if (startIndex == -1)
                    return null;

                startIndex += search.Length;
                int endIndex = json.IndexOf("\"", startIndex, StringComparison.Ordinal);
                if (endIndex == -1)
                    return null;

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

