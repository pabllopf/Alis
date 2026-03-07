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
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Network.Core;
using Alis.Extension.Network.Server;

namespace Alis.Extension.Network.Sample.ConsoleGame.Server
{
    /// <summary>
    ///     Simple multiplayer game server (console-based arena)
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     The server manager
        /// </summary>
        private static NetworkServerManager _serverManager;

        /// <summary>
        ///     The game state
        /// </summary>
        private static GameState _gameState;

        /// <summary>
        ///     The tick counter
        /// </summary>
        private static long _tickCounter;

        /// <summary>
        ///     The game running
        /// </summary>
        private static bool _gameRunning;

        /// <summary>
        ///     Whether server is also a player
        /// </summary>
        private static bool _serverIsPlayer;

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
                    {
                        serverPlayerName = $"ServerPlayer_{Guid.NewGuid().ToString().Substring(0, 4)}";
                    }

                    _gameState.AddPlayer("server_player", serverPlayerName);
                    Logger.Info($"✓ Server player: {serverPlayerName}");
                    Logger.Info("");
                }

                NetworkConfig config = new NetworkConfig
                {
                    MaxPlayers = 8,
                    TickRate = 60,
                    ServerAuthoritative = true
                };

                await _serverManager.InitializeAsync(config);
                Logger.Info("✓ Server initialized");

                NetworkSession session = await _serverManager.CreateSessionAsync("Battle Arena", 8);
                Logger.Info($"✓ Session created: {session.SessionName}");

                if (!_serverIsPlayer)
                {
                    // Dedicated mode: keep session/player counts client-only.
                    session.Players.RemoveAll(p => p.IsHost || p.PlayerId == _serverManager.LocalPlayer?.PlayerId);
                    session.PlayerCount = session.Players.Count;
                }

                Logger.Info("");

                RegisterHandlers();
                RegisterEvents();

                Uri listenUri = new Uri("ws://127.0.0.1:8889/");
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
        ///     Game tick loop that updates game state periodically
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
                    List<GameEvent> events = _gameState.GetPendingEvents();
                    foreach (GameEvent evt in events)
                    {
                        if (!string.IsNullOrEmpty(evt.SourcePlayer))
                        {
                            // Events are propagated via game.update, no need to broadcast individually
                            // await BroadcastGameEventAsync(evt);
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
        ///     Broadcasts full game state to all players
        /// </summary>
        private static async Task BroadcastGameStateAsync()
        {
            try
            {
                List<string> segments = new List<string>();

                foreach (PlayerData player in _gameState.Players.Values)
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

                string turnName = !string.IsNullOrEmpty(_gameState.CurrentTurnPlayerId)
                                  && _gameState.Players.TryGetValue(_gameState.CurrentTurnPlayerId, out PlayerData turnPlayer)
                    ? turnPlayer.PlayerName
                    : "No one";

                int turnTicksRemaining = Math.Max(0, (int) (_gameState.TurnEndsAtTick - _tickCounter));
                segments.Add($"__meta__:turn:{_gameState.CurrentTurnPlayerId ?? string.Empty}");
                segments.Add($"__meta__:turn_name:{turnName}");
                segments.Add($"__meta__:turn_ticks:{turnTicksRemaining}");
                segments.Add($"__meta__:tick:{_tickCounter}");

                // Include recent events in state broadcast
                List<GameEvent> recentEvents = _gameState.Events.ToList();
                if (recentEvents.Count > 0)
                {
                    // Send last 5 events
                    for (int i = Math.Max(0, recentEvents.Count - 5); i < recentEvents.Count; i++)
                    {
                        GameEvent evt = recentEvents[i];
                        string eventKey = $"event_{i}";
                        string eventValue = $"{evt.EventType}|{evt.SourcePlayer ?? ""}|{evt.TargetPlayer ?? ""}|{evt.Description}";
                        segments.Add($"__meta__:{eventKey}:{eventValue}");
                    }

                    segments.Add($"__meta__:event_count:{recentEvents.Count}");
                }

                string stateData = string.Join("|", segments);
                GameMessage msg = new GameMessage {MessageType = "state", Content = stateData};
                await _serverManager.BroadcastMessageAsync("game.update", msg);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error broadcasting state: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Commands the loop
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
                    {
                        continue;
                    }

                    if (input.Equals("/quit", StringComparison.OrdinalIgnoreCase))
                    {
                        _gameRunning = false;
                        break;
                    }

                    if (input.Equals("/players", StringComparison.OrdinalIgnoreCase))
                    {
                        IReadOnlyList<NetworkPlayer> players = _serverManager.GetConnectedPlayers();
                        List<NetworkPlayer> clientPlayers = players
                            .Where(p => !p.IsHost && (p.PlayerId != _serverManager.LocalPlayer?.PlayerId))
                            .ToList();

                        Logger.Info($"Connected players: {clientPlayers.Count}/{_serverManager.Config.MaxPlayers}");

                        foreach (NetworkPlayer connectedPlayer in clientPlayers)
                        {
                            if (_gameState.Players.TryGetValue(connectedPlayer.PlayerId, out PlayerData state))
                            {
                                string status = state.IsAlive ? "✓" : "✕";
                                Logger.Log($"  {status} {state.PlayerName,-15} HP={state.Health}/{state.MaxHealth} Score={state.Score} Lvl={state.Level} Pos=({state.X},{state.Y})");
                            }
                        }

                        Logger.Info("");
                    }

                    if (input.Equals("/status", StringComparison.OrdinalIgnoreCase))
                    {
                        IReadOnlyList<NetworkPlayer> allConnected = _serverManager.GetConnectedPlayers();
                        int clientCount = allConnected
                            .Where(p => !p.IsHost && (p.PlayerId != _serverManager.LocalPlayer?.PlayerId))
                            .Count();

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
                        GameMessage msg = new GameMessage {MessageType = "server_broadcast", Content = message};
                        await _serverManager.BroadcastMessageAsync("game.chat", msg);
                        Logger.Info($"✓ Broadcast: {message}");
                    }

                    if (input.Equals("/reset", StringComparison.OrdinalIgnoreCase))
                    {
                        _gameState = new GameState();
                        _tickCounter = 0;

                        foreach (NetworkPlayer connected in _serverManager.GetConnectedPlayers())
                        {
                            if (!_serverIsPlayer && (connected.IsHost || connected.PlayerId == _serverManager.LocalPlayer?.PlayerId))
                            {
                                continue;
                            }

                            _gameState.AddPlayer(connected.PlayerId, connected.PlayerName);
                        }

                        _gameState.UpdateTurn(_tickCounter);
                        await BroadcastGameStateAsync();
                        Logger.Info("✓ Game state reset and synchronized");
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
        ///     Registers the handlers
        /// </summary>
        private static void RegisterHandlers()
        {
            _serverManager.RegisterMessageHandler("system.join", OnSystemJoin);
            _serverManager.RegisterMessageHandler("game.move", OnPlayerMove);
            _serverManager.RegisterMessageHandler("game.attack", OnPlayerAttack);
            _serverManager.RegisterMessageHandler("game.spawn", OnPlayerSpawn);
            _serverManager.RegisterMessageHandler("game.chat", OnGameChat);
            _serverManager.RegisterMessageHandler("game.endturn", OnPlayerEndTurn);
        }

        /// <summary>
        ///     Registers the events
        /// </summary>
        private static void RegisterEvents()
        {
            _serverManager.PlayerJoined += (_, e) =>
            {
                _gameState.AddPlayer(e.Player.PlayerId, e.Player.PlayerName);

                Logger.Info($"→ {e.Player.PlayerName} connected ({e.Player.PlayerId})");
                Logger.Log($"   Connected players: {_serverManager.GetConnectedPlayers().Where(p => !p.IsHost && (p.PlayerId != _serverManager.LocalPlayer?.PlayerId)).Count()}");

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
                Logger.Log($"   Connected players: {_serverManager.GetConnectedPlayers().Where(p => !p.IsHost && (p.PlayerId != _serverManager.LocalPlayer?.PlayerId)).Count()}");

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
        ///     Ons the player move using the specified sender id
        /// </summary>
        private static async Task OnPlayerMove(string senderId, string payload)
        {
            try
            {
                string content = ExtractGameMessageContent(payload);
                string[] moveParts = content.Split(',');

                if ((moveParts.Length == 2) && int.TryParse(moveParts[0], out int x) && int.TryParse(moveParts[1], out int y))
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
        ///     Ons the player attack using the specified sender id
        /// </summary>
        private static async Task OnPlayerAttack(string senderId, string payload)
        {
            try
            {
                string targetName = ExtractGameMessageContent(payload);

                if (!_gameState.Players.TryGetValue(senderId, out PlayerData attacker) || !attacker.IsAlive)
                {
                    Logger.Error($"[ATTACK] {senderId} is not alive or not found!");
                    return;
                }

                // Check if it's player's turn
                if (!string.IsNullOrWhiteSpace(_gameState.CurrentTurnPlayerId) && (_gameState.CurrentTurnPlayerId != senderId))
                {
                    string turnName = !string.IsNullOrEmpty(_gameState.CurrentTurnPlayerId)
                                      && _gameState.Players.TryGetValue(_gameState.CurrentTurnPlayerId, out PlayerData turnPlayer)
                        ? turnPlayer.PlayerName
                        : "Unknown";

                    Logger.Log($"[ATTACK] {attacker.PlayerName} tried to attack but it's {turnName}'s turn!");

                    GameMessage notice = new GameMessage
                    {
                        MessageType = "chat",
                        Content = $"Server: Not your turn! Current turn: {turnName}."
                    };
                    await _serverManager.BroadcastMessageAsync("game.chat", notice);
                    return;
                }

                // Find target by name
                PlayerData target = null;
                foreach (PlayerData player in _gameState.Players.Values)
                {
                    if ((player.PlayerName == targetName) && (player.PlayerId != senderId) && player.IsAlive)
                    {
                        target = player;
                        break;
                    }
                }

                if (target == null)
                {
                    Logger.Log($"[ATTACK] {attacker.PlayerName} tried to attack {targetName} but target not found!");

                    GameMessage msg = new GameMessage
                    {
                        MessageType = "chat",
                        Content = $"Server: Target '{targetName}' not found or is dead!"
                    };
                    await _serverManager.BroadcastMessageAsync("game.chat", msg);
                    return;
                }

                // Check range
                float distance = MoveSystem.GetDistance(attacker.X, attacker.Y, target.X, target.Y);
                if (distance > CombatSystem.MaxAttackDistance)
                {
                    Logger.Log($"[ATTACK] {attacker.PlayerName} too far from {target.PlayerName} (distance: {distance})!");

                    GameMessage msg = new GameMessage
                    {
                        MessageType = "chat",
                        Content = $"Server: {target.PlayerName} is too far away!"
                    };
                    await _serverManager.BroadcastMessageAsync("game.chat", msg);
                    return;
                }

                // Calculate and apply damage
                int damage = CombatSystem.CalculateDamage(attacker, target);
                if (damage <= 0)
                {
                    Logger.Log($"[ATTACK] {attacker.PlayerName} vs {target.PlayerName}: No damage!");
                    return;
                }

                // Apply damage
                target.Health = Math.Max(0, target.Health - damage);
                attacker.Score += damage;

                _gameState.AddEvent(new GameEvent
                {
                    EventType = "attack",
                    SourcePlayer = senderId,
                    TargetPlayer = target.PlayerId,
                    Description = $"{attacker.PlayerName} dealt {damage} damage to {target.PlayerName}!"
                });

                Logger.Log($"[ATTACK] {attacker.PlayerName} -> {target.PlayerName}: {damage} damage! (HP: {target.Health}/{target.MaxHealth})");

                // Check if target died
                if (target.Health == 0)
                {
                    target.IsAlive = false;
                    target.Deaths++;
                    attacker.Kills++;
                    attacker.Score += 50;

                    int xp = CombatSystem.GetExperienceReward(target.Level);
                    attacker.Experience += xp;

                    // Level up check
                    if (attacker.Experience >= attacker.Level * 100)
                    {
                        attacker.Level++;
                        attacker.MaxHealth = 100 + attacker.Level * 10;
                        attacker.Health = attacker.MaxHealth;

                        _gameState.AddEvent(new GameEvent
                        {
                            EventType = "levelup",
                            SourcePlayer = senderId,
                            Description = $"{attacker.PlayerName} leveled up to {attacker.Level}!"
                        });
                    }

                    _gameState.AddEvent(new GameEvent
                    {
                        EventType = "death",
                        SourcePlayer = senderId,
                        TargetPlayer = target.PlayerId,
                        Description = $"{target.PlayerName} was defeated by {attacker.PlayerName}!"
                    });

                    Logger.Log($"[DEATH] {target.PlayerName} killed by {attacker.PlayerName}!");
                }

                // Advance turn after attack
                _gameState.AdvanceTurn(_tickCounter);

                // Broadcast result to all clients
                GameMessage result = new GameMessage
                {
                    MessageType = "chat",
                    Content = $"Server: {attacker.PlayerName} attacked {target.PlayerName} for {damage} damage!"
                };
                await _serverManager.BroadcastMessageAsync("game.chat", result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Attack error: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Ons the player spawn using the specified sender id
        /// </summary>
        private static async Task OnPlayerSpawn(string senderId, string payload)
        {
            try
            {
                if (_gameState.Players.TryGetValue(senderId, out PlayerData player) && !player.IsAlive)
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
        ///     Ons the game chat using the specified sender id
        /// </summary>
        private static async Task OnGameChat(string senderId, string payload)
        {
            try
            {
                string content = ExtractGameMessageContent(payload);

                if (_gameState.Players.TryGetValue(senderId, out PlayerData state))
                {
                    Logger.Log($"[CHAT] {state.PlayerName}: {content}");

                    GameMessage msg = new GameMessage {MessageType = "chat", Content = $"{state.PlayerName}:{content}"};
                    await _serverManager.BroadcastMessageAsync("game.chat", msg);

                    _gameState.AddEvent(new GameEvent
                    {
                        EventType = "chat",
                        SourcePlayer = senderId,
                        Description = $"{state.PlayerName}: {content}"
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Chat error: {ex.Message}");
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///     Ons the system join using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
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

        /// <summary>
        ///     Ons the player end turn using the specified sender id
        /// </summary>
        /// <param name="senderId">The sender id</param>
        /// <param name="payload">The payload</param>
        private static async Task OnPlayerEndTurn(string senderId, string payload)
        {
            try
            {
                if (_gameState.CurrentTurnPlayerId == senderId)
                {
                    Logger.Log($"[ENDTURN] {senderId} ended their turn");
                    _gameState.AdvanceTurn(_tickCounter);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"EndTurn error: {ex.Message}");
            }

            await Task.CompletedTask;
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