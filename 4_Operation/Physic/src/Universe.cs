// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Universe.cs
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

namespace Alis.Core.Physic
{
    /// <summary>
    /// The universe class
    /// </summary>
    public class Universe
    {
        /// <summary>
        /// The worlds
        /// </summary>
        private readonly List<World> worlds;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Universe"/> class
        /// </summary>
        public Universe() => worlds = new List<World>();

        /// <summary>
        /// Adds the world using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        public void AddWorld(World world) => worlds.Add(world);

        /// <summary>
        /// Removes the world using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        public void RemoveWorld(World world) => worlds.Remove(world);
        
        /// <summary>
        /// Describes whether this instance contains world
        /// </summary>
        /// <param name="world">The world</param>
        /// <returns>The bool</returns>
        public bool ContainsWorld(World world) => worlds.Contains(world);
        
        /// <summary>
        /// Counts the worlds
        /// </summary>
        /// <returns>The int</returns>
        public int CountWorlds() => worlds.Count;

        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update()
        {
        }
    }
}