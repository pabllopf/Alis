// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Game.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
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
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Text.Json.Serialization;
using Alis.Core.Settings;

namespace Alis.Core
{
    /// <summary>Define the main logic of game made with ALIS.</summary>
    public class Game
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Game" /> class
        /// </summary>
        public Game()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class
        /// </summary>
        /// <param name="isRunning">The is running</param>
        [JsonConstructor]
        public Game(bool isRunning)
        {

        }

        /// <summary>Gets a value indicating whether this instance is running.</summary>
        /// <value>
        ///     <c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        [JsonPropertyName("_IsRunning")]
        private static bool IsRunning { get; set; } = true;
        
        /// <summary>Gets or sets the configuration.</summary>
        /// <value>The configuration.</value>
        [JsonPropertyName("_Setting")]
        public static Setting Setting { get; set; } = new Setting();

        /// <summary>Runs this instance.</summary>
        public void Run()
        {
        }


        /// <summary>Resets the game.</summary>
        public void Reset()
        {
        }


        /// <summary>Stops this game.</summary>
        public void Stop()
        {
        }

        /// <summary>
        ///     Exits
        /// </summary>
        public static void Exit()
        {
        }

        ~Game()
        {
            
        }
    }
}