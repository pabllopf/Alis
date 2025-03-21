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
using Alis.Builder.Core.EcsOld.Entity.Transform;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.EcsOld.Component;
using Alis.Core.EcsOld.System.Scope;

namespace Alis.Builder.Core.EcsOld.Entity.GameObject
{
    /// <summary>
    ///     The game object builder class
    /// </summary>
    public class GameObjectBuilder :
        IBuild<Alis.Core.EcsOld.Entity.GameObject>,
        IName<GameObjectBuilder, string>,
        IIsStatic<GameObjectBuilder, bool>,
        IAddComponent<GameObjectBuilder, AComponent>,
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
        private readonly Alis.Core.EcsOld.Entity.GameObject gameObject = new Alis.Core.EcsOld.Entity.GameObject();

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectBuilder" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public GameObjectBuilder(Context context) => this.context = context;


        /// <summary>
        ///     Adds the component using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder AddComponent<T>(Func<T, AComponent> value) where T : AComponent
        {
            AComponent aComponent = value.Invoke((T) Activator.CreateInstance(typeof(T)));
            gameObject.Add(aComponent);
            gameObject.SetContext(context);
            aComponent.Attach(gameObject);
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder AddComponent<T>(T value) where T : AComponent
        {
            gameObject.Add(value);
            value.Attach(gameObject);
            gameObject.SetContext(context);
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The game object</returns>
        public Alis.Core.EcsOld.Entity.GameObject Build() => gameObject;

        /// <summary>
        ///     Ises the static
        /// </summary>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder IsStatic()
        {
            gameObject.IsStatic = true;
            return this;
        }

        /// <summary>
        ///     Ises the static using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder IsStatic(bool value)
        {
            gameObject.IsStatic = value;
            return this;
        }

        /// <summary>
        ///     Names the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Name(string value)
        {
            gameObject.Name = value;
            return this;
        }

        /// <summary>
        ///     Transforms the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Transform(Func<TransformBuilder, Alis.Core.Aspect.Math.Transform> value)
        {
            gameObject.Transform = value.Invoke(new TransformBuilder());
            return this;
        }

        /// <summary>
        ///     Adds the tag using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder WithTag(string value)
        {
            gameObject.Tag = value;
            return this;
        }
    }
}