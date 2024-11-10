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
using Alis.Builder.Core.Ecs.Entity.GameObject;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Builder.Core.Ecs.Entity.Scene
{
    /// <summary>
    ///     The scene builder class
    /// </summary>
    /// <seealso cref="IBuild{Scene}" />
    public class SceneBuilder :
        IBuild<Alis.Core.Ecs.Entity.Scene>,
        IName<SceneBuilder, string>,
        IAdd<SceneBuilder, Func<GameObjectBuilder, Alis.Core.Ecs.Entity.GameObject>>
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly Context context;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneBuilder"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public SceneBuilder(Context context)
        { 
            this.context    = context;    
        }

        /// <summary>
        ///     Gets the value of the scene
        /// </summary>
        private Alis.Core.Ecs.Entity.Scene Scene { get; } = new Alis.Core.Ecs.Entity.Scene();

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The scene builder</returns>
        public SceneBuilder Add<T>(Func<GameObjectBuilder, Alis.Core.Ecs.Entity.GameObject> value)
        {
            Scene.Add(value.Invoke(new GameObjectBuilder(context)));
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The scene</returns>
        public Alis.Core.Ecs.Entity.Scene Build() => Scene;

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