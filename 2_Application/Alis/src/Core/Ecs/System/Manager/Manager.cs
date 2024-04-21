// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Manager.cs
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

using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Entity.Property;

namespace Alis.Core.Ecs.System.Manager
{
    /// <summary>
    ///     The manager class
    /// </summary>
    /// <seealso cref="IManager" />
    public class Manager : IManager, IHasContext<Context>
    {
        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        protected Context Context { get; private set; }
        
        /// <summary>
        ///     Sets the context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        public void SetContext(Context context) => Context = context;
        
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
        public virtual void OnEnable() => Logger.Trace("Manager enabled.");
        
        /// <summary>
        ///     Ons the init
        /// </summary>
        public virtual void OnInit() => Logger.Trace("Manager initialized.");
        
        /// <summary>
        ///     Ons the awake
        /// </summary>
        public virtual void OnAwake() => Logger.Trace("Manager awake.");
        
        /// <summary>
        ///     Ons the start
        /// </summary>
        public virtual void OnStart() => Logger.Trace("Manager started.");
        
        /// <summary>
        ///     Ons the before update
        /// </summary>
        public virtual void OnBeforeUpdate() => Logger.Trace("Manager before update.");
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public virtual void OnUpdate() => Logger.Trace("Manager update.");
        
        /// <summary>
        ///     Ons the after update
        /// </summary>
        public virtual void OnAfterUpdate() => Logger.Trace("Manager after update.");
        
        /// <summary>
        ///     Ons the before fixed update
        /// </summary>
        public virtual void OnBeforeFixedUpdate() => Logger.Trace("Manager before fixed update.");
        
        /// <summary>
        ///     Ons the fixed update
        /// </summary>
        public virtual void OnFixedUpdate() => Logger.Trace("Manager fixed update.");
        
        /// <summary>
        ///     Ons the after fixed update
        /// </summary>
        public virtual void OnAfterFixedUpdate() => Logger.Trace("Manager after fixed update.");
        
        /// <summary>
        ///     Ons the dispatch events
        /// </summary>
        public virtual void OnDispatchEvents() => Logger.Trace("Manager dispatch events.");
        
        /// <summary>
        ///     Ons the calculate
        /// </summary>
        public virtual void OnCalculate() => Logger.Trace("Manager calculate.");
        
        /// <summary>
        ///     Ons the draw
        /// </summary>
        public virtual void OnDraw() => Logger.Trace("Manager draw.");
        
        /// <summary>
        ///     Ons the gui
        /// </summary>
        public virtual void OnGui() => Logger.Trace("Manager GUI.");
        
        /// <summary>
        ///     Ons the disable
        /// </summary>
        public virtual void OnDisable() => Logger.Trace("Manager disabled.");
        
        /// <summary>
        ///     Ons the reset
        /// </summary>
        public virtual void OnReset() => Logger.Trace("Manager reset.");
        
        /// <summary>
        ///     Ons the stop
        /// </summary>
        public virtual void OnStop() => Logger.Trace("Manager stopped.");
        
        /// <summary>
        ///     Ons the exit
        /// </summary>
        public virtual void OnExit() => Logger.Trace("Manager exited.");
        
        /// <summary>
        ///     Ons the destroy
        /// </summary>
        public virtual void OnDestroy() => Logger.Trace("Manager destroyed.");
    }
}