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
using System.Linq;

namespace Alis.Extension.Network.Sample.ConsoleGame.Server
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

        private static readonly Random Random = new Random();
        private const long TurnDurationTicks = 1800;  // 60 segundos a 30 ticks/segundo

        /// <summary>
        /// Gets the player id that can currently act.
        /// </summary>
        public string CurrentTurnPlayerId { get; private set; }

        /// <summary>
        /// Gets the tick when the current turn expires.
        /// </summary>
        public long TurnEndsAtTick { get; private set; }
        
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
                Players[playerId] = new PlayerData
                {
                    PlayerId = playerId,
                    PlayerName = playerName,
                    X = Random.Next(0, Arena.Width),
                    Y = Random.Next(0, Arena.Height),
                    Health = 100,
                    MaxHealth = 100,
                    Level = 1,
                    Score = 0,
                    Kills = 0,
                    Deaths = 0,
                    IsAlive = true
                };
            }

            EnsureTurnAssigned(CurrentTick);
        }
        
        /// <summary>
        /// Removes a player
        /// </summary>
        /// <param name="playerId">The player id</param>
        public void RemovePlayer(string playerId)
        {
            Players.Remove(playerId);

            if (CurrentTurnPlayerId == playerId)
            {
                CurrentTurnPlayerId = null;
            }

            EnsureTurnAssigned(CurrentTick);
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
            if (!Players.TryGetValue(playerId, out PlayerData player))
                return false;

            if (!MoveSystem.IsValidMove(x, y))
                return false;

            if (!player.IsAlive)
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
            if (!Players.TryGetValue(attackerId, out PlayerData attacker) || !attacker.IsAlive)
                return 0;
            
            // Find target by name
            PlayerData target = null;
            foreach (PlayerData player in Players.Values)
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
            if (Players.TryGetValue(playerId, out PlayerData player))
            {
                player.X = Random.Next(0, Arena.Width);
                player.Y = Random.Next(0, Arena.Height);
                player.Health = player.MaxHealth;
                player.IsAlive = true;

                AddEvent(new GameEvent
                {
                    EventType = "spawn",
                    SourcePlayer = playerId,
                    Description = $"{player.PlayerName} respawned!"
                });

                EnsureTurnAssigned(CurrentTick);
            }
        }

        /// <summary>
        /// Updates the active turn based on current tick and alive players.
        /// </summary>
        public void UpdateTurn(long currentTick)
        {
            CurrentTick = currentTick;
            EnsureTurnAssigned(currentTick);

            if (string.IsNullOrEmpty(CurrentTurnPlayerId))
                return;

            if (currentTick >= TurnEndsAtTick)
            {
                AdvanceTurn(currentTick);
            }
        }

        /// <summary>
        /// Advances the turn to the next alive player.
        /// </summary>
        public void AdvanceTurn(long currentTick)
        {
            List<PlayerData> alivePlayers = Players.Values
                .Where(p => p.IsAlive)
                .OrderBy(p => p.PlayerId)
                .ToList();

            if (alivePlayers.Count == 0)
            {
                CurrentTurnPlayerId = null;
                TurnEndsAtTick = 0;
                return;
            }

            int currentIndex = alivePlayers.FindIndex(p => p.PlayerId == CurrentTurnPlayerId);
            int nextIndex = currentIndex < 0 ? 0 : (currentIndex + 1) % alivePlayers.Count;

            CurrentTurnPlayerId = alivePlayers[nextIndex].PlayerId;
            TurnEndsAtTick = currentTick + TurnDurationTicks;
        }

        private void EnsureTurnAssigned(long currentTick)
        {
            if (!string.IsNullOrEmpty(CurrentTurnPlayerId) && Players.TryGetValue(CurrentTurnPlayerId, out PlayerData current) && current.IsAlive)
            {
                if (TurnEndsAtTick <= 0)
                {
                    TurnEndsAtTick = currentTick + TurnDurationTicks;
                }
                return;
            }

            AdvanceTurn(currentTick);
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
            List<GameEvent> result = new List<GameEvent>();
            while (Events.Count > 0)
            {
                result.Add(Events.Dequeue());
            }
            return result;
        }
    }
}

