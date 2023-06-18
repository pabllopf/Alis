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
using Alis.Builder.Core.Entity;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Logging;
using Alis.Core.Component;
using Alis.Core.Ecs;

namespace Alis.Core.Entity
{
    /// <summary>Represent a object of the game.</summary>
    public class GameObject : GameObjectBase, IBuilder<GameObjectBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        public GameObject() => Components = new List<ComponentBase>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObject" /> class
        /// </summary>
        /// <param name="name">The name</param>
        public GameObject(string name)
        {
            Name = name;
            Components = new List<ComponentBase>();
            Logger.Log($"Created GameObject '{name}'");
        }

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The game object builder</returns>
        public GameObjectBuilder Builder() => new GameObjectBuilder();


        /// <summary>
        ///     Inits this instance
        /// </summary>
        internal void Init() => Components.ForEach(component => component.Init());

        /// <summary>Awakes this instance.</summary>
        internal void Awake() => Components.ForEach(component => component.Awake());

        /// <summary>Starts this instance.</summary>
        internal void Start() => Components.ForEach(component => component.Start());

        /// <summary>Befores the update.</summary>
        internal void BeforeUpdate() => Components.ForEach(component => component.BeforeUpdate());

        /// <summary>Updates this instance.</summary>
        internal void Update() => Components.ForEach(component => component.Update());

        /// <summary>Afters the update.</summary>
        internal void AfterUpdate() => Components.ForEach(component => component.AfterUpdate());

        /// <summary>Afters the update.</summary>
        internal void FixedUpdate() => Components.ForEach(component => component.FixedUpdate());

        /// <summary>
        ///     Dispatches the events.
        /// </summary>
        /// <returns></returns>
        internal void DispatchEvents() => Components.ForEach(component => component.DispatchEvents());

        /// <summary>
        ///     Draws this instance
        /// </summary>
        internal void Draw() => Components.ForEach(component => component.Draw());

        /// <summary>Stops this instance.</summary>
        internal void Stop() => Components.ForEach(component => component.Stop());

        /// <summary>Resets this instance.</summary>
        internal void Reset() => Components.ForEach(component => component.Reset());

        /// <summary>Exits this instance.</summary>
        internal void Exit() => Components.ForEach(component => component.Exit());

        /// <summary>
        ///     Creates the primitive
        /// </summary>
        public static void CreatePrimitive()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Finds
        /// </summary>
        public static GameObject Find(string name) => new GameObject(name);

        /// <summary>
        ///     Finds the game objects with tag
        /// </summary>
        public static void FindGameObjectsWithTag()
        {
            Logger.Trace();
        }

        /// <summary>
        ///     Finds the with tag
        /// </summary>
        public static GameObject FindWithTag(string tag) => new GameObject();
    }
}