// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GameObjectBuilder.cs
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

using System;
using Alis.FluentApi;
using Alis.FluentApi.Words;

namespace Alis.Builders
{
    /// <summary>
    ///     The game object builder class
    /// </summary>
    public class GameObjectBuilder :
        IBuild<GameObject>,
        IName<GameObjectBuilder, string>
    {
        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        private GameObject GameObject { get; } = new GameObject();

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Add<T>(T value) where T : Core.Components.Component
        {
            GameObject.Add(value);
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The game object</returns>
        public GameObject Build() => GameObject;

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Name(string value)
        {
            GameObject.Name = value;
            return this;
        }

        /// <summary>
        ///     Transforms the transform
        /// </summary>
        /// <param name="transform">The transform</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Transform(Core.Entities.Transform transform)
        {
            GameObject.Transform = transform;
            return this;
        }
    }
}