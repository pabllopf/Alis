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
    
    /// <summary>
    /// Arena data
    /// </summary>
    public class Arena
    {
        /// <summary>
        /// The width
        /// </summary>
        public const int Width = 40;
        /// <summary>
        /// The height
        /// </summary>
        public const int Height = 25;
        
        /// <summary>
        /// Gets the grid occupancy
        /// </summary>
        public Dictionary<(int, int), string> OccupancyMap { get; } = new Dictionary<(int, int), string>();
    }
    
    /// <summary>
    /// Player data
    /// </summary>
    public class PlayerData
    {
        /// <summary>
        /// Gets or sets the player id
        /// </summary>
        public string PlayerId { get; set; }
        
        /// <summary>
        /// Gets or sets the player name
        /// </summary>
        public string PlayerName { get; set; }
        
        /// <summary>
        /// Gets or sets the x position
        /// </summary>
        public int X { get; set; }
        
        /// <summary>
        /// Gets or sets the y position
        /// </summary>
        public int Y { get; set; }
        
        /// <summary>
        /// Gets or sets the health
        /// </summary>
        public int Health { get; set; }
        
        /// <summary>
        /// Gets or sets the max health
        /// </summary>
        public int MaxHealth { get; set; }
        
        /// <summary>
        /// Gets or sets the level
        /// </summary>
        public int Level { get; set; }
        
        /// <summary>
        /// Gets or sets the experience
        /// </summary>
        public int Experience { get; set; }
        
        /// <summary>
        /// Gets or sets the score
        /// </summary>
        public int Score { get; set; }
        
        /// <summary>
        /// Gets or sets the kills
        /// </summary>
        public int Kills { get; set; }
        
        /// <summary>
        /// Gets or sets the deaths
        /// </summary>
        public int Deaths { get; set; }
        
        /// <summary>
        /// Gets or sets if the player is alive
        /// </summary>
        public bool IsAlive { get; set; }
        
        /// <summary>
        /// Gets or sets the last action time
        /// </summary>
        public long LastActionTime { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the PlayerData class
        /// </summary>
        public PlayerData()
        {
            MaxHealth = 100;
            Health = 100;
            Level = 1;
            Experience = 0;
            Score = 0;
            Kills = 0;
            Deaths = 0;
            IsAlive = true;
            LastActionTime = 0;
        }
    }
    
    /// <summary>
    /// Game event
    /// </summary>
    public class GameEvent
    {
        /// <summary>
        /// Gets or sets the timestamp
        /// </summary>
        public long Timestamp { get; set; }
        
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        public string EventType { get; set; }
        
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the source player
        /// </summary>
        public string SourcePlayer { get; set; }
        
        /// <summary>
        /// Gets or sets the target player
        /// </summary>
        public string TargetPlayer { get; set; }
        
        /// <summary>
        /// Gets or sets the data
        /// </summary>
        public Dictionary<string, object> Data { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the GameEvent class
        /// </summary>
        public GameEvent()
        {
            Timestamp = DateTime.UtcNow.Ticks;
            Data = new Dictionary<string, object>();
        }
    }
}

