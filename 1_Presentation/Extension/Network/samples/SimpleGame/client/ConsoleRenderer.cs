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

namespace Alis.Extension.Network.Sample.SimpleGame.Client
{
    /// <summary>
    /// Console renderer for the game
    /// </summary>
    public class ConsoleRenderer
    {
        private readonly GameState _gameState;
        private readonly string _localPlayerId;
        private List<string> _displayBuffer;
        
        /// <summary>
        /// Arena size for compact display
        /// </summary>
        private const int CompactWidth = 30;
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
        public void Render()
        {
            _displayBuffer.Clear();
            
            // Clear console
            Console.Clear();
            
            // Draw compact arena (30x12)
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
                    
                    foreach (var player in _gameState.Players.Values)
                    {
                        if (Math.Abs(player.X - arenaX) < 2 && Math.Abs(player.Y - arenaY) < 2)
                        {
                            if (player.PlayerId == _localPlayerId)
                                cell = "●";
                            else if (!player.IsAlive)
                                cell = "✕";
                            else
                                cell = "○";
                            break;
                        }
                    }
                    
                    line += cell + " ";
                }
                
                line += "│";
                _displayBuffer.Add(line);
            }
            
            _displayBuffer.Add("└" + new string('─', CompactWidth * 2) + "┘");
            _displayBuffer.Add("");
            
            // Compact stats on one line
            if (_gameState.Players.TryGetValue(_localPlayerId, out var localPlayer))
            {
                string healthBar = GetSmallHealthBar(localPlayer.Health, localPlayer.MaxHealth);
                _displayBuffer.Add($"[{localPlayer.PlayerName}] HP:{healthBar} Lvl:{localPlayer.Level} Score:{localPlayer.Score} Kills:{localPlayer.Kills} Pos:({localPlayer.X},{localPlayer.Y})");
            }
            
            _displayBuffer.Add("");
            
            // Compact player list (top 5)
            _displayBuffer.Add("Players: " + string.Join(" | ", 
                _gameState.Players.Values
                    .OrderByDescending(p => p.Score)
                    .Take(5)
                    .Select(p => $"{(p.IsAlive ? "✓" : "✕")} {p.PlayerName}:{p.Score}")));
            
            _displayBuffer.Add("");
            
            // Last 3 events only
            _displayBuffer.Add("Events: " + string.Join(" > ", 
                _gameState.EventLog
                    .Skip(Math.Max(0, _gameState.EventLog.Count - 3))
                    .Select(e => e.Description)));
            
            _displayBuffer.Add("");
            _displayBuffer.Add("Commands: /move X Y | /attack NAME | /spawn | /chat MSG | /stats | /help | /quit");
            
            // Render all
            foreach (var line in _displayBuffer)
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

