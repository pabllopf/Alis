// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AManager.cs
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
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems.Manager
{
    /// <summary>
    ///     The manager class
    /// </summary>
    /// <seealso cref="IManager" />
    public abstract class AManager : IManager
    {
        /// <summary>
        ///     The context
        /// </summary>
        private readonly Context _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AManager" /> class
        /// </summary>
        protected AManager(Context context)
        {
            _context = context;
            Id = Guid.NewGuid().ToString();
            Name = "Manager";
            Tag = "Untagged";
            IsEnable = true;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context"></param>
        protected AManager(string id, string name, string tag, bool isEnable, Context context)
        {
            Id = id;
            Name = name;
            Tag = tag;
            IsEnable = isEnable;
            _context = context;
        }

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>

        public Context Context => _context;

        /// <summary>
        ///     Gets or sets the value of the is enable
        /// </summary>

        public bool IsEnable { get; set; }

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the value of the id
        /// </summary>

        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tag
        /// </summary>

        public string Tag { get; set; }

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public virtual void OnEnable()
        {
        }

        /// <summary>
        ///     Ons the init
        /// </summary>
        public virtual void OnInit()
        {
        }

        /// <summary>
        ///     Ons the awake
        /// </summary>
        public virtual void OnAwake()
        {
        }

        /// <summary>
        ///     Ons the start
        /// </summary>
        public virtual void OnStart()
        {
        }

        /// <summary>
        ///     Ons the before update
        /// </summary>
        public virtual void OnBeforeUpdate()
        {
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public virtual void OnUpdate()
        {
        }

        /// <summary>
        ///     Ons the after update
        /// </summary>
        public virtual void OnAfterUpdate()
        {
        }

        /// <summary>
        ///     Ons the process pending changes
        /// </summary>
        public virtual void OnProcessPendingChanges()
        {
        }

        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public virtual void OnBeforeFixedUpdate()
        {
        }

        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public virtual void OnFixedUpdate()
        {
        }

        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public virtual void OnAfterFixedUpdate()
        {
        }

        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public virtual void OnDispatchEvents()
        {
        }

        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public virtual void OnCalculate()
        {
        }

        /// <summary>
        ///     Ons the before draw
        /// </summary>
        public virtual void OnBeforeDraw()
        {
        }

        /// <summary>
        ///     Ons the draw
        /// </summary>
        public virtual void OnDraw()
        {
        }

        /// <summary>
        ///     Ons the after draw
        /// </summary>
        public virtual void OnAfterDraw()
        {
        }

        /// <summary>
        ///     Ons the gui
        /// </summary>
        public virtual void OnGui()
        {
        }

        /// <summary>
        ///     Ons the render present
        /// </summary>
        public virtual void OnRenderPresent()
        {
        }

        /// <summary>
        ///     Ons the disable
        /// </summary>
        public virtual void OnDisable()
        {
        }

        /// <summary>
        ///     Ons the reset
        /// </summary>
        public virtual void OnReset()
        {
        }

        /// <summary>
        ///     Ons the stop
        /// </summary>
        public virtual void OnStop()
        {
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public virtual void OnExit()
        {
        }

        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public virtual void OnDestroy()
        {
        }

        /// <summary>
        ///     Ons the save
        /// </summary>
        public virtual void OnSave()
        {
        }

        /// <summary>
        ///     Ons the load
        /// </summary>
        public virtual void OnLoad()
        {
        }

        /// <summary>
        ///     Ons the save using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public virtual void OnSave(string path)
        {
        }

        /// <summary>
        ///     Ons the load using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        public virtual void OnLoad(string path)
        {
        }

        /// <summary>
        ///     Ons the physics update
        /// </summary>
        public virtual void OnPhysicUpdate()
        {
        }
    }
}