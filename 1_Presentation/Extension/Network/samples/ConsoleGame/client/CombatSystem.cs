using System;

namespace Alis.Extension.Network.Sample.ConsoleGame.Client
{
    /// <summary>
    /// Combat system for combat calculations
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