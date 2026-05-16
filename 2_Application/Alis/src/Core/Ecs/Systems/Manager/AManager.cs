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
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Manager.Time;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Systems.Manager
{
    /// <summary>
    ///     Abstract base class for all managers in the Alis ECS framework.
    ///     Provides a common set of properties (Id, Name, Tag, Enable state) and
    ///     a full lifecycle of virtual callbacks that derived managers can override.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <see cref="AManager" /> implements <see cref="IManager" /> and serves as the
    ///         foundation for all system managers (e.g., <see cref="SceneManager" />,
    ///         <see cref="TimeManager" />, Audio, Graphic, Input, Network, Physic).
    ///     </para>
    ///     <para>
    ///         The lifecycle callbacks are invoked in a specific order by the
    ///         <see cref="ContextHandler" />: OnInit → OnAwake → OnStart →
    ///         each frame (OnBeforeUpdate → OnUpdate → OnAfterUpdate → physics →
    ///         OnBeforeDraw → OnDraw → OnAfterDraw → OnGui) → OnStop → OnExit → OnDestroy.
    ///     </para>
    ///     <para>
    ///         Override the relevant virtual methods in a subclass to hook into
    ///         the desired phase of the game loop.
    ///     </para>
    /// </remarks>
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
        ///     Gets the <see cref="Context" /> that this manager belongs to.
        /// </summary>
        public Context Context => _context;

        /// <summary>
        ///     Gets or sets a value indicating whether this manager is currently enabled.
        /// </summary>
        /// <remarks>
        ///     When disabled, the manager will skip its update and draw callbacks.
        /// </remarks>
        public bool IsEnable { get; set; }

        /// <summary>
        ///     Gets or sets the display name of this manager.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the unique identifier of this manager.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets a tag used to categorize or group this manager.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        ///     Ons the enable
        /// </summary>
        public virtual void OnEnable()
        {
        }

        /// <summary>
        ///     Called when this manager is first initialized and registered within the context.
        /// </summary>
        /// <remarks>
        ///     Use this callback for one-time setup logic that must run before any game objects
        ///     are processed, such as registering services or allocating resources.
        /// </remarks>
        public virtual void OnInit()
        {
        }

        /// <summary>
        ///     Called after all managers have been initialized but before the first update.
        /// </summary>
        /// <remarks>
        ///     Use this for setup that depends on other managers being fully initialized
        ///     (e.g., accessing the SceneManager or registering event handlers).
        /// </remarks>
        public virtual void OnAwake()
        {
        }

        /// <summary>
        ///     Called before the first frame update.
        /// </summary>
        /// <remarks>
        ///     This is the ideal place for one-time initialization of game state or
        ///     spawning initial entities.
        /// </remarks>
        public virtual void OnStart()
        {
        }

        /// <summary>
        ///     Called each frame before all component <c>OnUpdate</c> callbacks are invoked.
        /// </summary>
        public virtual void OnBeforeUpdate()
        {
        }

        /// <summary>
        ///     Called each frame for per-frame logic (physics, movement, AI, etc.).
        /// </summary>
        /// <remarks>
        ///     This is the primary per-frame update callback. Derived managers should
        ///     override this to implement game logic that runs every frame.
        /// </remarks>
        public virtual void OnUpdate()
        {
        }

        /// <summary>
        ///     Called each frame after all component <c>OnUpdate</c> callbacks have been invoked.
        /// </summary>
        public virtual void OnAfterUpdate()
        {
        }

        /// <summary>
        ///     Called each frame to process any queued structural changes (entity creation/destruction, component adds/removes).
        /// </summary>
        public virtual void OnProcessPendingChanges()
        {
        }

        /// <summary>
        ///     Called each frame before all component <c>OnFixedUpdate</c> callbacks are invoked.
        /// </summary>
        public virtual void OnBeforeFixedUpdate()
        {
        }

        /// <summary>
        ///     Called at a fixed time step for deterministic physics and gameplay logic.
        /// </summary>
        /// <remarks>
        ///     Fixed updates run at a fixed interval regardless of frame rate, making them
        ///     suitable for physics calculations and other deterministic logic.
        /// </remarks>
        public virtual void OnFixedUpdate()
        {
        }

        /// <summary>
        ///     Called each fixed update after all component <c>OnFixedUpdate</c> callbacks have been invoked.
        /// </summary>
        public virtual void OnAfterFixedUpdate()
        {
        }

        /// <summary>
        ///     Called each frame to dispatch queued events to listeners.
        /// </summary>
        public virtual void OnDispatchEvents()
        {
        }

        /// <summary>
        ///     Called each frame after events are dispatched, for any deferred calculations.
        /// </summary>
        public virtual void OnCalculate()
        {
        }

        /// <summary>
        ///     Called each frame before all component <c>OnDraw</c> callbacks are invoked.
        /// </summary>
        public virtual void OnBeforeDraw()
        {
        }

        /// <summary>
        ///     Called each frame to render game objects.
        /// </summary>
        /// <remarks>
        ///     This is where render commands are typically issued. Derived managers
        ///     can override this to inject draw calls or modify the render pipeline.
        /// </remarks>
        public virtual void OnDraw()
        {
        }

        /// <summary>
        ///     Called each frame after all component <c>OnDraw</c> callbacks have been invoked.
        /// </summary>
        public virtual void OnAfterDraw()
        {
        }

        /// <summary>
        ///     Called each frame after rendering, to update the display.
        /// </summary>
        public virtual void OnGui()
        {
        }

        /// <summary>
        ///     Called after all rendering is complete, to present the final framebuffer to the screen.
        /// </summary>
        public virtual void OnRenderPresent()
        {
        }

        /// <summary>
        ///     Called when this manager is being disabled or the game is shutting down.
        /// </summary>
        /// <remarks>
        ///     Override this to release resources, unsubscribe from events,
        ///     or perform other cleanup while the game is still running.
        /// </remarks>
        public virtual void OnDisable()
        {
        }

        /// <summary>
        ///     Called when the game is being reset to its initial state.
        /// </summary>
        public virtual void OnReset()
        {
        }

        /// <summary>
        ///     Called when the game loop exits normally.
        /// </summary>
        /// <remarks>
        ///     Override this for shutdown logic that must run before resources are destroyed.
        /// </remarks>
        public virtual void OnStop()
        {
        }

        /// <summary>
        ///     Called as the final cleanup step when the game is exiting.
        /// </summary>
        /// <remarks>
        ///     This is called after <see cref="OnStop" /> and should be used for
        ///     releasing all remaining resources and performing final teardown.
        /// </remarks>
        public virtual void OnExit()
        {
        }

        /// <summary>
        ///     Called when this manager is being destroyed and removed from the context.
        /// </summary>
        /// <remarks>
        ///     Override this to release unmanaged resources and ensure a clean shutdown.
        /// </remarks>
        public virtual void OnDestroy()
        {
        }

        /// <summary>
        ///     Saves manager state to persistent storage.
        /// </summary>
        public virtual void OnSave()
        {
        }

        /// <summary>
        ///     Loads manager state from persistent storage.
        /// </summary>
        public virtual void OnLoad()
        {
        }

        /// <summary>
        ///     Saves manager state to the file at the specified path.
        /// </summary>
        /// <param name="path">The file path where manager state should be saved.</param>
        public virtual void OnSave(string path)
        {
        }

        /// <summary>
        ///     Loads manager state from the file at the specified path.
        /// </summary>
        /// <param name="path">The file path from which manager state should be loaded.</param>
        public virtual void OnLoad(string path)
        {
        }

        /// <summary>
        ///     Called once per frame for physics calculations and other fixed-rate simulations.
        /// </summary>
        public virtual void OnPhysicUpdate()
        {
        }
    }
}