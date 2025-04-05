// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectBuilder.cs
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
using Alis.Core.Ecs;
using Alis.Core.Ecs.System.Scope;

namespace Alis.Builder.Core.Ecs.Entity
{
    /// <summary>
    ///     The game object builder class
    /// </summary>
    public class GameObjectBuilder :
        IBuild<GameObject>,
        IName<GameObjectBuilder, string>,
        IIsStatic<GameObjectBuilder, bool>,
        ITransform<GameObjectBuilder, Func<TransformBuilder, Alis.Core.Aspect.Math.Transform>>,
        IWithTag<GameObjectBuilder, string>
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context context;

        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        private readonly GameObject gameObject = new GameObject();

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public GameObjectBuilder(Context context) => this.context = context;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The game object</returns>
        public GameObject Build() => gameObject;

        /// <summary>
        ///     Ises the static
        /// </summary>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder IsStatic()
        {
            return this;
        }

        /// <summary>
        ///     Ises the static using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder IsStatic(bool value)
        {
            return this;
        }

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Name(string value)
        {
            return this;
        }

        /// <summary>
        ///     Transforms the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Transform(Func<TransformBuilder, Alis.Core.Aspect.Math.Transform> value)
        {
            return this;
        }

        /// <summary>
        ///     Adds the tag using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithTag(string value)
        {
            return this;
        }
    }
}