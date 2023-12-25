// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Scene.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Ecs.Entity.GameObject;

namespace Alis.Core.Ecs.Entity.Scene
{
    /// <summary>
    ///     The scene class
    /// </summary>
    public class Scene : IScene
    {
        /// <summary>
        ///     Gets or sets the value of the is enable
        /// </summary>
        public bool IsEnable { get; set; } = true;

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; } = "Scene";

        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>
        public string Id { get; set; } = "0";

        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>
        public string Tag { get; set; } = "Untagged";

        /// <summary>
        ///     Gets or sets the value of the game objects
        /// </summary>
        public List<IGameObject> GameObjects { get; set; } = new List<IGameObject>();

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public void OnEnable() => GameObjects.ForEach(i => i.OnEnable());

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit() => GameObjects.ForEach(i => i.OnInit());

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake() => GameObjects.ForEach(i => i.OnAwake());

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart() => GameObjects.ForEach(i => i.OnStart());

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate() => GameObjects.ForEach(i => i.OnBeforeUpdate());

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate() => GameObjects.ForEach(i => i.OnUpdate());

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate() => GameObjects.ForEach(i => i.OnAfterUpdate());

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate() => GameObjects.ForEach(i => i.OnBeforeFixedUpdate());

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate() => GameObjects.ForEach(i => i.OnFixedUpdate());

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate() => GameObjects.ForEach(i => i.OnAfterFixedUpdate());

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents() => GameObjects.ForEach(i => i.OnDispatchEvents());

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate() => GameObjects.ForEach(i => i.OnCalculate());

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw() => GameObjects.ForEach(i => i.OnDraw());

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui() => GameObjects.ForEach(i => i.OnGui());

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public void OnDisable() => GameObjects.ForEach(i => i.OnDisable());

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public void OnReset() => GameObjects.ForEach(i => i.OnReset());

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop() => GameObjects.ForEach(i => i.OnStop());

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit() => GameObjects.ForEach(i => i.OnExit());

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public void OnDestroy() => GameObjects.ForEach(i => i.OnDestroy());

        /// <summary>
        ///     Adds the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Add<T>(T component) where T : IGameObject => GameObjects.Add(component);

        /// <summary>
        ///     Removes the component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        public void Remove<T>(T component) where T : IGameObject => GameObjects.Remove(component);

        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The</returns>
        public T Get<T>() where T : IGameObject => (T) GameObjects.Find(i => i.GetType() == typeof(T));

        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        public bool Contains<T>() where T : IGameObject => Get<T>() != null;

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        public void Clear<T>() where T : IGameObject => GameObjects.Clear();
    }
}