// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectBase.cs
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
using Alis.Core.Aspect.Base;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The game object base class
    /// </summary>
    public class GameObjectBase : AlisObject
    {
        /// <summary>
        ///     The components
        /// </summary>
        public List<ComponentBase> Components;

        /// <summary>
        ///     The transform
        /// </summary>
        public TransformBase Transform { get; set; } = new TransformBase();

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <param name="component">The component</param>
        public void AddComponent<T>(T component) where T : ComponentBase => Components.Add(component);

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <param name="component">The component</param>
        public void RemoveComponent<T>(T component) where T : ComponentBase => Components.Remove(component);

        /// <summary>
        ///     Describes whether this instance contain component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The bool</returns>
        public bool ContainComponent(ComponentBase component) => Components.Contains(component);

        /// <summary>
        ///     Gets the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T GetComponent<T>() where T : ComponentBase => (T) Components.Find(i => i.GetType() == typeof(T));

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : ComponentBase => Components.Find(i => i.GetType() == typeof(T)) != null;
    }
}