// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Runtime.cs
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
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Alis.Core.Ecs.Systems.Execution
{
    /// <summary>
    ///     The runtime class
    /// </summary>
    public class Runtime<T> where T : IRuntime
    {
        /// <summary>
        ///     The type
        /// </summary>
        private readonly ConcurrentDictionary<Type, T> _cachedItems;

        /// <summary>
        ///     The dictionary
        /// </summary>
        private readonly List<T> runtimes;

        /// <summary>
        /// </summary>
        /// <param name="array"></param>
        public Runtime(params T[] array)
        {
            runtimes = new List<T>(array);
            _cachedItems = new ConcurrentDictionary<Type, T>();
            foreach (T runtime in runtimes)
            {
                _cachedItems[runtime.GetType()] = runtime;
            }
        }

        /// <summary>
        ///     Gets this instance
        /// </summary>
        /// <typeparam name="TGet">The get</typeparam>
        /// <exception cref="InvalidOperationException">No item of type {type} found.</exception>
        /// <returns>The get</returns>
        public TGet Get<TGet>() where TGet : T
        {
            if (_cachedItems.TryGetValue(typeof(TGet), out T item))
            {
                return (TGet) item;
            }

            throw new InvalidOperationException($"No item of type {typeof(TGet)} found.");
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public void OnInit() => runtimes.ForEach(x => x.OnInit());

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public void OnAwake() => runtimes.ForEach(x => x.OnAwake());

        /// <summary>
        ///     Ons the start
        /// </summary>
        public void OnStart() => runtimes.ForEach(x => x.OnStart());

        /// <summary>
        ///     Ons the physic update
        /// </summary>
        public void OnPhysicUpdate() => runtimes.ForEach(x => x.OnPhysicUpdate());

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public void OnBeforeUpdate() => runtimes.ForEach(x => x.OnBeforeUpdate());

        /// <summary>
        ///     Ons the update
        /// </summary>
        public void OnUpdate() => runtimes.ForEach(x => x.OnUpdate());

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public void OnAfterUpdate() => runtimes.ForEach(x => x.OnAfterUpdate());

        /// <summary>
        ///     Ons the process pending changes
        /// </summary>
        public void OnProcessPendingChanges() => runtimes.ForEach(x => x.OnProcessPendingChanges());

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public void OnBeforeFixedUpdate() => runtimes.ForEach(x => x.OnBeforeFixedUpdate());

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public void OnFixedUpdate() => runtimes.ForEach(x => x.OnFixedUpdate());

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public void OnAfterFixedUpdate() => runtimes.ForEach(x => x.OnAfterFixedUpdate());

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public void OnDispatchEvents() => runtimes.ForEach(x => x.OnDispatchEvents());

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public void OnCalculate() => runtimes.ForEach(x => x.OnCalculate());

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        public void OnBeforeDraw() => runtimes.ForEach(x => x.OnBeforeDraw());

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public void OnDraw() => runtimes.ForEach(x => x.OnDraw());

        /// <summary>
        ///     Ons the after draw
        /// </summary>
        public void OnAfterDraw() => runtimes.ForEach(x => x.OnAfterDraw());

        /// <summary>
        ///     Ons the render present
        /// </summary>
        public void OnRenderPresent() => runtimes.ForEach(x => x.OnRenderPresent());

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public void OnGui() => runtimes.ForEach(x => x.OnGui());

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public void OnStop() => runtimes.ForEach(x => x.OnStop());

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public void OnExit() => runtimes.ForEach(x => x.OnExit());

        /// <summary>
        ///     Ons the save
        /// </summary>
        public void OnSave() => runtimes.ForEach(x => x.OnSave());

        /// <summary>
        ///     Ons the load
        /// </summary>
        public void OnLoad() => runtimes.ForEach(x => x.OnLoad());

        /// <summary>
        ///     Ons the load using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public void OnLoad(string path) => runtimes.ForEach(x => x.OnLoad(path));

        /// <summary>
        ///     Ons the save using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public void OnSave(string path) => runtimes.ForEach(x => x.OnSave(path));
    }
}