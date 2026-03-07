// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerData.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Network.Sample.ConsoleGame.Server
{
    /// <summary>
    ///     Player data
    /// </summary>
    public class PlayerData : IJsonSerializable
    {
        /// <summary>
        ///     Gets or sets the player id
        /// </summary>
        public string PlayerId { get; set; }

        /// <summary>
        ///     Gets or sets the player name
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        ///     Gets or sets the x position
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the y position
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the health
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        ///     Gets or sets the max health
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        ///     Gets or sets the level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the experience
        /// </summary>
        public int Experience { get; set; }

        /// <summary>
        ///     Gets or sets the score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        ///     Gets or sets the kills
        /// </summary>
        public int Kills { get; set; }

        /// <summary>
        ///     Gets or sets the deaths
        /// </summary>
        public int Deaths { get; set; }

        /// <summary>
        ///     Gets or sets if the player is alive
        /// </summary>
        public bool IsAlive { get; set; }

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>A system collections generic enumerable of string and string</returns>
        public IEnumerable<(string, string)> GetSerializableProperties()
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
}