// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneBuilder.cs
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

using System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Entity;

namespace Alis.Builder.Core.Entity
{
    /// <summary>
    ///     The scene builder class
    /// </summary>
    /// <seealso cref="IBuild{Scene}" />
    public class SceneBuilder :
        IBuild<Scene>,
        IName<SceneBuilder, string>,
        IAdd<SceneBuilder, GameObject, Func<GameObjectBuilder, GameObject>>
    {
        /// <summary>
        ///     Gets the value of the scene
        /// </summary>
        private Scene Scene { get; } = new Scene();

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The scene builder</returns>
        public SceneBuilder Add<T>(Func<GameObjectBuilder, GameObject> value) where T : GameObject
        {
            Scene.Add(value.Invoke(new GameObjectBuilder()));
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The scene</returns>
        public Scene Build() => Scene;

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The scene builder</returns>
        public SceneBuilder Name(string value)
        {
            Scene.Name = value;
            return this;
        }
    }
}