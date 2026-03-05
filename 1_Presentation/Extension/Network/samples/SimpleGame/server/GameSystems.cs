// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: GameSystems.cs
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

namespace Alis.Extension.Network.Sample.SimpleGame.Server
{
    /// <summary>
    /// Movement system for server-side validation
    /// </summary>
    public class MoveSystem
    {
        /// <summary>
        /// Validates if a move is legal
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns>True if the move is valid</returns>
        public static bool IsValidMove(int x, int y)
        {
            return x >= 0 && x < Arena.Width && y >= 0 && y < Arena.Height;
        }
        
        /// <summary>
        /// Gets distance between two points
        /// </summary>
        /// <param name="x1">The x1 coordinate</param>
        /// <param name="y1">The y1 coordinate</param>
        /// <param name="x2">The x2 coordinate</param>
        /// <param name="y2">The y2 coordinate</param>
        /// <returns>The distance</returns>
        public static float GetDistance(int x1, int y1, int x2, int y2)
        {
            return (float)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
    
    /// <summary>
    /// Combat system for server-side calculations
    /// </summary>
    public class CombatSystem
    {
        /// <summary>
        /// The base damage
        /// </summary>
        public const int BaseDamage = 10;
        /// <summary>
        /// The critical hit chance (percent)
        /// </summary>
        public const int CriticalChance = 20;
        /// <summary>
        /// The critical multiplier
        /// </summary>
        public const float CriticalMultiplier = 1.5f;
        /// <summary>
        /// The max attack distance
        /// </summary>
        public const float MaxAttackDistance = 10f;
        
        /// <summary>
        /// The random generator
        /// </summary>
        private static readonly Random Random = new Random();
        
        /// <summary>
        /// Calculates damage for an attack
        /// </summary>
        /// <param name="attacker">The attacker</param>
        /// <param name="defender">The defender</param>
        /// <returns>The damage amount</returns>
        public static int CalculateDamage(PlayerData attacker, PlayerData defender)
        {
            // Check range
            float distance = MoveSystem.GetDistance(attacker.X, attacker.Y, defender.X, defender.Y);
            if (distance > MaxAttackDistance)
                return 0;
            
            // Base damage with level scaling
            int damage = BaseDamage + (attacker.Level * 2);
            
            // Critical hit chance
            if (Random.Next(100) < CriticalChance)
            {
                damage = (int)(damage * CriticalMultiplier);
            }
            
            return damage;
        }
        
        /// <summary>
        /// Gets experience reward
        /// </summary>
        /// <param name="defenderLevel">The defender level</param>
        /// <returns>The experience</returns>
        public static int GetExperienceReward(int defenderLevel)
        {
            return Math.Max(10, 50 * defenderLevel / 10);
        }
    }
}

