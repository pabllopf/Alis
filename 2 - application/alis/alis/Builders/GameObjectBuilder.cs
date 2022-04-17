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
using Alis.Core.Components;
using Alis.Core.Entities;
using Alis.Core.FluentApi;
using Alis.Core.FluentApi.Words;

namespace Alis.Core.Builders
{
    /// <summary>
    ///     The game object builder class
    /// </summary>
    public class GameObjectBuilder :
        IBuild<GameObject>,
        IName<GameObjectBuilder, string>,
        ITransform<GameObjectBuilder, Func<TransformBuilder, Transform>>,
        ITransform<GameObjectBuilder, Transform>
    {
        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        private GameObject GameObject { get; } = new GameObject();

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
        ///     Transforms the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Transform(Func<TransformBuilder, Transform> value)
        {
            GameObject.Transform = value(new TransformBuilder());
            return this;
        }

        /// <summary>
        ///     Transforms the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Transform(Transform value)
        {
            GameObject.Transform = value;
            return this;
        }

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Add<T>(T value) where T : Component
        {
            GameObject.Add(value);
            return this;
        }
    }
}