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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.SimpleGame.Server
{
    /// <summary>
    /// Server-side game state
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
        /// Gets or sets the current tick
        /// </summary>
        public long CurrentTick { get; set; }
        
        /// <summary>
        /// Gets or sets the events
        /// </summary>
        public Queue<GameEvent> Events { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the GameState class
        /// </summary>
        public GameState()
        {
            Arena = new Arena();
            Players = new Dictionary<string, PlayerData>();
            Events = new Queue<GameEvent>();
            CurrentTick = 0;
        }
        
        /// <summary>
        /// Adds or updates a player
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="playerName">The player name</param>
        public void AddPlayer(string playerId, string playerName)
        {
            if (!Players.ContainsKey(playerId))
            {
                Random rand = new Random();
                Players[playerId] = new PlayerData
                {
                    PlayerId = playerId,
                    PlayerName = playerName,
                    X = rand.Next(0, Arena.Width),
                    Y = rand.Next(0, Arena.Height),
                    Health = 100,
                    MaxHealth = 100,
                    Level = 1,
                    Score = 0,
                    Kills = 0,
                    Deaths = 0,
                    IsAlive = true
                };
            }
        }
        
        /// <summary>
        /// Removes a player
        /// </summary>
        /// <param name="playerId">The player id</param>
        public void RemovePlayer(string playerId)
        {
            Players.Remove(playerId);
        }
        
        /// <summary>
        /// Processes a move command
        /// </summary>
        /// <param name="playerId">The player id</param>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>True if successful</returns>
        public bool ProcessMove(string playerId, int x, int y)
        {
            if (!Players.TryGetValue(playerId, out var player))
                return false;
            
            if (!MoveSystem.IsValidMove(x, y))
                return false;
            
            player.X = x;
            player.Y = y;
            
            AddEvent(new GameEvent
            {
                EventType = "move",
                SourcePlayer = playerId,
                Description = $"{player.PlayerName} moved to ({x}, {y})"
            });
            
            return true;
        }
        
        /// <summary>
        /// Processes an attack command
        /// </summary>
        /// <param name="attackerId">The attacker id</param>
        /// <param name="targetName">The target name</param>
        /// <returns>The damage dealt</returns>
        public int ProcessAttack(string attackerId, string targetName)
        {
            if (!Players.TryGetValue(attackerId, out var attacker) || !attacker.IsAlive)
                return 0;
            
            // Find target by name
            PlayerData target = null;
            foreach (var player in Players.Values)
            {
                if (player.PlayerName == targetName && player.PlayerId != attackerId)
                {
                    target = player;
                    break;
                }
            }
            
            if (target == null || !target.IsAlive)
                return 0;
            
            // Calculate damage
            int damage = CombatSystem.CalculateDamage(attacker, target);
            if (damage <= 0)
                return 0;
            
            // Apply damage
            target.Health = Math.Max(0, target.Health - damage);
            attacker.Score += damage;
            
            AddEvent(new GameEvent
            {
                EventType = "attack",
                SourcePlayer = attackerId,
                TargetPlayer = target.PlayerId,
                Description = $"{attacker.PlayerName} attacked {target.PlayerName} for {damage} damage!"
            });
            
            if (target.Health == 0)
            {
                target.IsAlive = false;
                target.Deaths++;
                attacker.Kills++;
                attacker.Score += 50;
                
                // Award experience
                int xp = CombatSystem.GetExperienceReward(target.Level);
                attacker.Experience += xp;
                
                // Level up
                if (attacker.Experience >= attacker.Level * 100)
                {
                    attacker.Level++;
                    attacker.MaxHealth = 100 + (attacker.Level * 10);
                    attacker.Health = attacker.MaxHealth;
                }
                
                AddEvent(new GameEvent
                {
                    EventType = "death",
                    SourcePlayer = attackerId,
                    TargetPlayer = target.PlayerId,
                    Description = $"{target.PlayerName} was defeated!"
                });
            }
            
            return damage;
        }
        
        /// <summary>
        /// Processes a spawn command
        /// </summary>
        /// <param name="playerId">The player id</param>
        public void ProcessSpawn(string playerId)
        {
            if (Players.TryGetValue(playerId, out var player))
            {
                Random rand = new Random();
                player.X = rand.Next(0, Arena.Width);
                player.Y = rand.Next(0, Arena.Height);
                player.Health = player.MaxHealth;
                player.IsAlive = true;
                
                AddEvent(new GameEvent
                {
                    EventType = "spawn",
                    SourcePlayer = playerId,
                    Description = $"{player.PlayerName} respawned!"
                });
            }
        }
        
        /// <summary>
        /// Adds an event
        /// </summary>
        /// <param name="gameEvent">The game event</param>
        public void AddEvent(GameEvent gameEvent)
        {
            Events.Enqueue(gameEvent);
        }
        
        /// <summary>
        /// Gets all pending events
        /// </summary>
        /// <returns>The list of events</returns>
        public List<GameEvent> GetPendingEvents()
        {
            var result = new List<GameEvent>();
            while (Events.Count > 0)
            {
                result.Add(Events.Dequeue());
            }
            return result;
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
    }
    
    /// <summary>
    /// Player data
    /// </summary>
    public class PlayerData : IJsonSerializable
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
        /// Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public System.Collections.Generic.IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(PlayerId), PlayerId);
            yield return (nameof(PlayerName), PlayerName);
            yield return (nameof(X), X.ToString());
            yield return (nameof(Y), Y.ToString());
            yield return (nameof(Health), Health.ToString());
            yield return (nameof(MaxHealth), MaxHealth.ToString());
            yield return (nameof(Level), Level.ToString());
            yield return (nameof(Experience), Experience.ToString());
            yield return (nameof(Score), Score.ToString());
            yield return (nameof(Kills), Kills.ToString());
            yield return (nameof(Deaths), Deaths.ToString());
            yield return (nameof(IsAlive), IsAlive.ToString());
        }
    }
    
    /// <summary>
    /// Game event
    /// </summary>
    public class GameEvent : IJsonSerializable
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
        /// Initializes a new instance of the GameEvent class
        /// </summary>
        public GameEvent()
        {
            Timestamp = DateTime.UtcNow.Ticks;
        }
        
        /// <summary>
        /// Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public System.Collections.Generic.IEnumerable<(string, string)> GetSerializableProperties()
        {
            yield return (nameof(Timestamp), Timestamp.ToString());
            yield return (nameof(EventType), EventType ?? "");
            yield return (nameof(Description), Description ?? "");
            yield return (nameof(SourcePlayer), SourcePlayer ?? "");
            yield return (nameof(TargetPlayer), TargetPlayer ?? "");
        }
    }
}

