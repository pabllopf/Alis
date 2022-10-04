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
using Alis.Core.Component;
using Alis.Core.Entity;

namespace Alis.Core.Builder.Entity
{
    /// <summary>
    ///     The game object builder class
    /// </summary>
    public class GameObjectBuilder :
        IBuild<GameObject>,
        IName<GameObjectBuilder, string>,
        IAddComponent<GameObjectBuilder, ComponentBase>,
        ITransform<GameObjectBuilder, Func<TransformBuilder, Transform>>,
        IWithTag<GameObjectBuilder, string>
    {
        /// <summary>
        ///     Gets or sets the value of the game object
        /// </summary>
        private GameObject gameObject = new GameObject();


        /// <summary>
        ///     Adds the component using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder AddComponent<T>(Func<T, ComponentBase> value) where T : ComponentBase
        {
            ComponentBase componentBase = value.Invoke((T) Activator.CreateInstance(typeof(T)));
            gameObject.Add(componentBase);
            componentBase.AttachGameObject(gameObject);
            return this;
        }

        /// <summary>
        ///     Adds the component using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder AddComponent<T>(T value) where T : ComponentBase
        {
            ComponentBase componentBase = (T) Activator.CreateInstance(typeof(T));
            gameObject.Add(componentBase);
            componentBase.AttachGameObject(gameObject);
            return this;
        }

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The game object</returns>
        public GameObject Build() => gameObject;

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
        public GameObjectBuilder Transform(Func<TransformBuilder, Transform> value)
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