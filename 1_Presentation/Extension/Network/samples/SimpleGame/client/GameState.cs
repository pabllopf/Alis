// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: GameState.cs
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

namespace Alis.Extension.Network.Sample.SimpleGame.Client
{
    /// <summary>
    /// Local game state for the client
    /// </summary>
    public class GameState
    {
        /// <summary>
        /// Gets or sets the arena
        /// </summary>
        public Arena Arena { get; set; }
        
        /// <summary>
        /// Gets or sets the players
        /// </summary>
        public Dictionary<string, PlayerData> Players { get; set; }
        
        /// <summary>
        /// Gets or sets the local player id
        /// </summary>
        public string LocalPlayerId { get; set; }
        
        /// <summary>
        /// Gets or sets the game events log
        /// </summary>
        public List<GameEvent> EventLog { get; set; }
        
        /// <summary>
        /// Gets or sets the last update tick
        /// </summary>
        public long LastUpdateTick { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the GameState class
        /// </summary>
        public GameState()
        {
            Arena = new Arena();
            Players = new Dictionary<string, PlayerData>();
            EventLog = new List<GameEvent>();
            LastUpdateTick = 0;
        }
        
        /// <summary>
        /// Updates player position
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        public void UpdatePlayerPosition(string playerId, int x, int y)
        {
            if (Players.TryGetValue(playerId, out var player))
            {
                player.X = x;
                player.Y = y;
            }
        }
        
        /// <summary>
        /// Updates player health
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="health">The health</param>
        public void UpdatePlayerHealth(string playerId, int health)
        {
            if (Players.TryGetValue(playerId, out var player))
            {
                player.Health = Math.Max(0, health);
                if (player.Health == 0)
                {
                    player.IsAlive = false;
                }
            }
        }
        
        /// <summary>
        /// Adds event to log
        /// </summary>
        /// <param name="gameEvent">The game event</param>
        public void AddEvent(GameEvent gameEvent)
        {
            EventLog.Add(gameEvent);
            if (EventLog.Count > 100)
            {
                EventLog.RemoveAt(0);
            }
        }
    }
}

