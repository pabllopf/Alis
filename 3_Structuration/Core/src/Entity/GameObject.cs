// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObject.cs
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
using Alis.Core.Builder;
using Alis.Core.Builder.Entity;
using Alis.Core.Component;

namespace Alis.Core.Entity
{
    /// <summary>Represent a object of the game.</summary>
    public class GameObject : AlisObject
    {
        /// <summary>
        /// The transform
        /// </summary>
        public Transform Transform = new Transform();

        /// <summary>
        /// The components
        /// </summary>
        private List<ComponentBase> components;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameObject"/> class
        /// </summary>
        public GameObject() => components = new List<ComponentBase>();

        /// <summary>
        /// Adds the component
        /// </summary>
        /// <param name="component">The component</param>
        public void Add(ComponentBase component) => components.Add(component);

        /// <summary>
        /// Removes the component
        /// </summary>
        /// <param name="component">The component</param>
        public void Remove(ComponentBase component) => components.Remove(component);

        /// <summary>
        /// Builders this instance
        /// </summary>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Builder() => new GameObjectBuilder();
        
        /// <summary>
        /// Inits this instance
        /// </summary>
        public void Init() => components.ForEach(component => component.Init());
        
        /// <summary>Awakes this instance.</summary>
        public void Awake() => components.ForEach(component => component.Awake());

        /// <summary>Starts this instance.</summary>
        public void Start() => components.ForEach(component => component.Start());

        /// <summary>Befores the update.</summary>
        public void BeforeUpdate() => components.ForEach(component => component.BeforeUpdate());

        /// <summary>Updates this instance.</summary>
        public void Update() => components.ForEach(component => component.Update());

        /// <summary>Afters the update.</summary>
        public void AfterUpdate() => components.ForEach(component => component.AfterUpdate());

        /// <summary>Afters the update.</summary>
        public void FixedUpdate() => components.ForEach(component => component.FixedUpdate());

        /// <summary>
        ///     Dispatches the events.
        /// </summary>
        /// <returns></returns>
        public void DispatchEvents() => components.ForEach(component => component.DispatchEvents());

        /// <summary>Stops this instance.</summary>
        public void Stop() => components.ForEach(component => component.Stop());
        
        /// <summary>Resets this instance.</summary>
        public void Reset() => components.ForEach(component => component.Reset());

        /// <summary>Exits this instance.</summary>
        public void Exit() => components.ForEach(component => component.Exit());
    }
}