// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: ConsoleRenderer.cs
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
using System.Collections.Generic;
using System.Linq;

namespace Alis.Extension.Network.Sample.ConsoleGame.Client
{
    /// <summary>
    /// Console renderer for the game
    /// </summary>
    public class ConsoleRenderer
    {
        /// <summary>
        /// The game state
        /// </summary>
        private readonly GameState _gameState;
        /// <summary>
        /// The local player id
        /// </summary>
        private readonly string _localPlayerId;
        /// <summary>
        /// The display buffer
        /// </summary>
        private List<string> _displayBuffer;
        
        /// <summary>
        /// Arena size for compact display
        /// </summary>
        private const int CompactWidth = 30;
        /// <summary>
        /// The compact height
        /// </summary>
        private const int CompactHeight = 12;
        
        /// <summary>
        /// Initializes a new instance of the ConsoleRenderer class
        /// </summary>
        /// <param name="gameState">The game state</param>
        /// <param name="localPlayerId">The local player id</param>
        public ConsoleRenderer(GameState gameState, string localPlayerId)
        {
            _gameState = gameState;
            _localPlayerId = localPlayerId;
            _displayBuffer = new List<string>();
        }
        
        /// <summary>
        /// Renders the game screen (compact version for 800x600)
        /// </summary>
        public void Render(string currentInput = "")
        {
            _displayBuffer.Clear();
            
            // Clear console
            Console.Clear();

            string turnName = string.IsNullOrEmpty(_gameState.CurrentTurnPlayerName) ? "No one" : _gameState.CurrentTurnPlayerName;
            int turnSeconds = Math.Max(0, _gameState.TurnTicksRemaining / 30);
            bool isMyTurn = _gameState.CurrentTurnPlayerId != null && _gameState.Players.TryGetValue(_gameState.CurrentTurnPlayerId, out PlayerData turnPlayer) && turnPlayer.PlayerId == _localPlayerId;
            string turnIndicator = isMyTurn ? "🎮 YOUR TURN!" : $"Waiting for {turnName}";
            _displayBuffer.Add($"╔ Turn: {turnName} ({turnSeconds}s) - {turnIndicator} ╗");
            _displayBuffer.Add("");
            
            // Draw compact arena (30x12) with player initials
            _displayBuffer.Add("┌" + new string('─', CompactWidth * 2) + "┐");
            
            for (int y = 0; y < CompactHeight; y++)
            {
                string line = "│ ";
                
                for (int x = 0; x < CompactWidth; x++)
                {
                    string cell = ".";
                    
                    // Map arena coordinates to compact display
                    int arenaX = (int)((float)x / CompactWidth * Arena.Width);
                    int arenaY = (int)((float)y / CompactHeight * Arena.Height);
                    
                    // Find exact player at this position
                    List<PlayerData> playersAtPosition = _gameState.Players.Values
                        .Where(p => p.X == arenaX && p.Y == arenaY && p.IsAlive)
                        .ToList();
                    
                    if (playersAtPosition.Count > 0)
                    {
                        PlayerData player = playersAtPosition[0];
                        if (player.PlayerId == _localPlayerId)
                            cell = char.ToUpper(player.PlayerName[0]).ToString();
                        else
                            cell = char.ToLower(player.PlayerName[0]).ToString();
                    }
                    else
                    {
                        // Check for dead players
                        List<PlayerData> deadPlayers = _gameState.Players.Values
                            .Where(p => p.X == arenaX && p.Y == arenaY && !p.IsAlive)
                            .ToList();
                        if (deadPlayers.Count > 0)
                            cell = "✕";
                    }
                    
                    line += cell + " ";
                }
                
                line += "│";
                _displayBuffer.Add(line);
            }
            
            _displayBuffer.Add("└" + new string('─', CompactWidth * 2) + "┘");
            _displayBuffer.Add("");
            
            // Compact your stats on one line
            if (_gameState.Players.TryGetValue(_localPlayerId, out PlayerData localPlayer))
            {
                string healthBar = GetSmallHealthBar(localPlayer.Health, localPlayer.MaxHealth);
                _displayBuffer.Add($"YOU: {localPlayer.PlayerName} | HP:{healthBar} {localPlayer.Health}/{localPlayer.MaxHealth} | Lvl:{localPlayer.Level} | Score:{localPlayer.Score} | Kills:{localPlayer.Kills}/{localPlayer.Deaths} | Pos:({localPlayer.X},{localPlayer.Y})");
            }
            
            _displayBuffer.Add("");
            
            // Compact all players in ranking (one line each)
            _displayBuffer.Add("PLAYERS: " + string.Join(" | ",
                _gameState.Players.Values
                    .OrderByDescending(p => p.Score)
                    .Select(p =>
                    {
                        string healthBar = GetSmallHealthBar(p.Health, p.MaxHealth);
                        string turn = p.PlayerId == _gameState.CurrentTurnPlayerId ? " ◄" : "";
                        string status = p.IsAlive ? "✓" : "✕";
                        return $"{status} {p.PlayerName}({p.Score}){turn}";
                    })));
            
            _displayBuffer.Add("");
            
            // Recent events (last 5 with full descriptions)
            _displayBuffer.Add("╭─ RECENT EVENTS ─────────────────────────────────────────────╮");
            List<GameEvent> recentEvents = _gameState.EventLog
                .Skip(Math.Max(0, _gameState.EventLog.Count - 5))
                .ToList();
            
            if (recentEvents.Count == 0)
            {
                _displayBuffer.Add("│ [Waiting for events...]");
            }
            else
            {
                foreach (GameEvent evt in recentEvents)
                {
                    // Clean event display: extract just the useful part
                    string eventLine = evt.Description;
                    
                    // If it contains pipes (|), it's formatted as eventType|sourceId|targetId|description
                    // Extract just the description part
                    if (eventLine.Contains("|"))
                    {
                        string[] parts = eventLine.Split('|');
                        if (parts.Length >= 4)
                        {
                            eventLine = parts[3]; // description
                        }
                    }
                    
                    if (eventLine.Length > 62)
                        eventLine = eventLine.Substring(0, 59) + "...";
                    
                    _displayBuffer.Add($"│ {eventLine}");
                }
            }
            _displayBuffer.Add($"╰────────────────────────────────────────────────────────────────╯");
            
            _displayBuffer.Add("");
            
            // Compact recent events (show up to 4)
            _displayBuffer.Add("EVENTS: " + string.Join(" | ",
                _gameState.EventLog
                    .Skip(Math.Max(0, _gameState.EventLog.Count - 4))
                    .Select(e =>
                    {
                        string desc = e.Description;
                        if (desc.Contains("|"))
                        {
                            string[] evtParts = desc.Split('|');
                            if (evtParts.Length >= 4)
                                desc = evtParts[3];
                        }
                        return desc.Length > 35 ? desc.Substring(0, 32) + "..." : desc;
                    })));
            
            _displayBuffer.Add("");
            
            // Server feedback message (if recent)
            long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            if (!string.IsNullOrEmpty(_gameState.LastServerMessage) && (currentTime - _gameState.LastServerMessageTime) < 3000)
            {
                _displayBuffer.Add($"SERVER: {_gameState.LastServerMessage.Substring(0, Math.Min(58, _gameState.LastServerMessage.Length))}");
            }
            
            _displayBuffer.Add("Commands: /move X Y | /attack NAME | /spawn | /endturn | /chat | /help | /quit");
            _displayBuffer.Add("");
            
            // Show current input with player name
            string playerName = "Unknown";
            if (_gameState.Players.TryGetValue(_localPlayerId, out PlayerData localData))
            {
                playerName = localData.PlayerName;
            }
            _displayBuffer.Add($"[{playerName}]> {currentInput}");
            
            // Render all
            foreach (string line in _displayBuffer)
            {
                Console.WriteLine(line);
            }
        }
        
        /// <summary>
        /// Gets a small health bar
        /// </summary>
        /// <param name="current">The current health</param>
        /// <param name="max">The max health</param>
        /// <returns>The small health bar</returns>
        private string GetSmallHealthBar(int current, int max)
        {
            int barLength = 8;
            int filledLength = (int)((float)current / max * barLength);
            
            string bar = "";
            for (int i = 0; i < barLength; i++)
            {
                if (i < filledLength)
                    bar += "█";
                else
                    bar += "░";
            }
            
            return bar;
        }
    }
}

