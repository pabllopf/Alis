// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Scene.cs
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
namespace Alis
{
    /// <summary>
    /// The scene class
    /// </summary>
    /// <seealso cref="Alis.Core.Entities.Scene"/>
    public class Scene : Alis.Core.Entities.Scene
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scene"/> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="gameObjects">The game objects</param>
        public Scene(string name, System.Collections.Generic.List<Core.Entities.GameObject> gameObjects) : base(name, gameObjects)
        {
        }
    }
}